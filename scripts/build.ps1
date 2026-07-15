[CmdletBinding(PositionalBinding=$false)]
Param(
  [ValidateSet("<auto>", "amd64", "x64", "x86", "arm64", "arm")][string] $architecture = "",
  [switch] $build,
  [switch] $ci,
  [ValidateSet("Debug", "Release")][string] $configuration = "Debug",
  [switch] $help,
  [string] $llvm = "",
  [switch] $pack,
  [switch] $regeneratenative,
  [switch] $restore,
  [ValidateSet("", "win-x64", "win-arm64", "linux-x64", "linux-arm64", "osx-arm64")][string] $rid = "",
  [string] $solution = "",
  [ValidateSet("", "libLLVM", "libLLVMSharp")][string] $target = "",
  [switch] $test,
  [ValidateSet("quiet", "minimal", "normal", "detailed", "diagnostic")][string] $verbosity = "minimal",
  [Parameter(ValueFromRemainingArguments=$true)][String[]]$properties
)

Set-StrictMode -Version 2.0
$ErrorActionPreference = "Stop"
[Net.ServicePointManager]::SecurityProtocol = [Net.SecurityProtocolType]::Tls12

function Build() {
  $logFile = Join-Path -Path $LogDir -ChildPath "$configuration\build.binlog"
  & dotnet build -c "$configuration" --no-restore -v "$verbosity" /bl:"$logFile" /err $properties "$solution"

  if ($LastExitCode -ne 0) {
    throw "'Build' failed for '$solution'"
  }
}

function Create-Directory([string[]] $Path) {
  if (!(Test-Path -Path $Path)) {
    New-Item -Path $Path -Force -ItemType "Directory" | Out-Null
  }
}

function Help() {
    Write-Host -Object "Common settings:"
    Write-Host -Object "  -configuration <value>  Build configuration (Debug, Release)"
    Write-Host -Object "  -verbosity <value>      Msbuild verbosity (q[uiet], m[inimal], n[ormal], d[etailed], and diag[nostic])"
    Write-Host -Object "  -help                   Print help and exit"
    Write-Host -Object ""
    Write-Host -Object "Actions:"
    Write-Host -Object "  -restore                Restore dependencies"
    Write-Host -Object "  -build                  Build solution"
    Write-Host -Object "  -test                   Run all tests in the solution"
    Write-Host -Object "  -pack                   Package build artifacts"
    Write-Host -Object "  -regeneratenative       Download the matching LLVM release and stage a native binary"
    Write-Host -Object "                          (use with -target and -rid)"
    Write-Host -Object ""
    Write-Host -Object "Advanced settings:"
    Write-Host -Object "  -solution <value>       Path to solution to build"
    Write-Host -Object "  -ci                     Set when running on CI server"
    Write-Host -Object "  -architecture <value>   Test Architecture (<auto>, amd64, x64, x86, arm64, arm)"
    Write-Host -Object ""
    Write-Host -Object "Command line arguments not listed above are passed through to MSBuild."
    Write-Host -Object "The above arguments can be shortened as much as to be unambiguous (e.g. -co for configuration, -t for test, etc.)."
}

function Pack() {
  $logFile = Join-Path -Path $LogDir -ChildPath "$configuration\pack"

  & dotnet pack -c "$configuration" --no-build --no-restore -v "$verbosity" /bl:"$logFile.binlog" /err $properties "$solution"
  & dotnet pack -c "$configuration" --no-build --no-restore -v "$verbosity" /bl:"$logFile.agnostic.binlog" /err /p:SKIP_USE_CURRENT_RUNTIME=true $properties "$solution"

  if ($ci) {
    & dotnet pack -c "$configuration" --no-build --no-restore -v "$verbosity" /bl:"$logFile.preview.binlog" /err /p:PACKAGE_PUBLISH_MODE=preview $properties "$solution"
    & dotnet pack -c "$configuration" --no-build --no-restore -v "$verbosity" /bl:"$logFile.stable.binlog" /err /p:PACKAGE_PUBLISH_MODE=stable $properties "$solution"

    & dotnet pack -c "$configuration" --no-build --no-restore -v "$verbosity" /bl:"$logFile.agnostic.preview.binlog" /err /p:SKIP_USE_CURRENT_RUNTIME=true /p:PACKAGE_PUBLISH_MODE=preview $properties "$solution"
    & dotnet pack -c "$configuration" --no-build --no-restore -v "$verbosity" /bl:"$logFile.agnostic.stable.binlog" /err /p:SKIP_USE_CURRENT_RUNTIME=true /p:PACKAGE_PUBLISH_MODE=stable $properties "$solution"
  }

  if ($LastExitCode -ne 0) {
    throw "'Pack' failed for '$solution'"
  }
}

function Restore() {
  $logFile = Join-Path -Path $LogDir -ChildPath "$configuration\restore.binlog"
  & dotnet restore -v "$verbosity" /bl:"$logFile" /err $properties "$solution"

  if ($LastExitCode -ne 0) {
    throw "'Restore' failed for '$solution'"
  }
}

function Get-LlvmVersion() {
  if ($llvm -ne "") {
    return $llvm
  }

  $cmakeLists = Join-Path -Path $RepoRoot -ChildPath "CMakeLists.txt"
  $match = Select-String -Path $cmakeLists -Pattern 'project\(LLVMSharp VERSION ([0-9.]+)\)' | Select-Object -First 1

  if (-not $match) {
    throw "Could not parse the LLVM version from '$cmakeLists'"
  }

  return $match.Matches[0].Groups[1].Value
}

function Download-Llvm([string] $version, [string] $runtime, [string] $destination) {
  $asset = switch ($runtime) {
    "win-x64"     { "clang+llvm-$version-x86_64-pc-windows-msvc.tar.xz" }
    "win-arm64"   { "clang+llvm-$version-aarch64-pc-windows-msvc.tar.xz" }
    "linux-x64"   { "LLVM-$version-Linux-X64.tar.xz" }
    "linux-arm64" { "LLVM-$version-Linux-ARM64.tar.xz" }
    "osx-arm64"   { "LLVM-$version-macOS-ARM64.tar.xz" }
    default       { throw "Unsupported runtime identifier '$runtime'" }
  }

  $url = "https://github.com/llvm/llvm-project/releases/download/llvmorg-$version/$asset"
  $archive = Join-Path -Path $ArtifactsDir -ChildPath "llvm-$runtime.tar.xz"

  Create-Directory -Path $destination

  # Windows ships bsdtar (libarchive) as tar.exe, which handles .tar.xz.
  & curl.exe -fSL $url -o $archive

  if ($LastExitCode -ne 0) {
    throw "'curl' failed to download '$url'"
  }

  & tar -xf $archive -C $destination --strip-components=1

  if ($LastExitCode -ne 0) {
    throw "'tar' failed to extract '$archive'"
  }
}

function Extract-LibLLVM([string] $runtime, [string] $source, [string] $destination) {
  # The Windows LLVM release ships the C API shared library under its official name,
  # 'LLVM-C.dll', which is the name the managed resolver in LLVM.cs loads and the name
  # 'libLLVMSharp.dll' imports -- so it is shipped as-is, without renaming. The Linux/macOS
  # releases ship no shared libLLVM (only static archives), so those runtimes are lifted
  # from apt.llvm.org/Homebrew in build.sh instead.
  if ($runtime -notlike "win-*") {
    throw "'$runtime' cannot lift libLLVM here; use build.sh on the matching runner"
  }

  $lib = Get-ChildItem -Recurse -Path $source -Filter "LLVM-C.dll" -File | Sort-Object -Property "Length" -Descending | Select-Object -First 1

  if (-not $lib) {
    throw "'LLVM-C.dll' was not found in the LLVM release for '$runtime'"
  }

  Copy-Item -Path $lib.FullName -Destination (Join-Path -Path $destination -ChildPath "LLVM-C.dll")
}

function Build-LibLLVMSharp([string] $runtime, [string] $source, [string] $destination) {
  $arch = switch ($runtime) {
    "win-x64"   { "x64" }
    "win-arm64" { "ARM64" }
    default     { throw "'$runtime' cannot build libLLVMSharp on Windows; use build.sh on the matching runner" }
  }

  $nativeBuildDir = Join-Path -Path $ArtifactsDir -ChildPath "bin\native\$runtime"
  $pathToLlvm = (Resolve-Path -Path $source).Path

  & cmake -B "$nativeBuildDir" -S "$RepoRoot" -G "Visual Studio 17 2022" -A "$arch" "-Thost=$arch" "-DPATH_TO_LLVM=$pathToLlvm"

  if ($LastExitCode -ne 0) {
    throw "'cmake' configure failed for '$runtime'"
  }

  & cmake --build "$nativeBuildDir" --config Release --target LLVMSharp

  if ($LastExitCode -ne 0) {
    throw "'cmake' build failed for '$runtime'"
  }

  $lib = Get-ChildItem -Recurse -Path $nativeBuildDir -Filter "libLLVMSharp.dll" -File | Select-Object -First 1

  if (-not $lib) {
    throw "'libLLVMSharp.dll' was not produced for '$runtime'"
  }

  Copy-Item -Path $lib.FullName -Destination (Join-Path -Path $destination -ChildPath "libLLVMSharp.dll")
}

function Regenerate-Native() {
  if ($rid -eq "") {
    throw "-rid is required with -regeneratenative"
  }

  if ($target -eq "") {
    throw "-target is required with -regeneratenative"
  }

  $version = Get-LlvmVersion
  $llvmDir = Join-Path -Path $ArtifactsDir -ChildPath "llvm\$rid"
  $stagingDir = Join-Path -Path $ArtifactsDir -ChildPath "native\$rid"

  Download-Llvm -version "$version" -runtime "$rid" -destination "$llvmDir"
  Create-Directory -Path $stagingDir

  if ($target -eq "libLLVM") {
    Extract-LibLLVM -runtime "$rid" -source "$llvmDir" -destination "$stagingDir"
  }
  elseif ($target -eq "libLLVMSharp") {
    Build-LibLLVMSharp -runtime "$rid" -source "$llvmDir" -destination "$stagingDir"
  }
  else {
    throw "Unsupported target '$target'"
  }
}

function Test() {
  $logFile = Join-Path -Path $LogDir -ChildPath "$configuration\test.binlog"
  & dotnet test -c "$configuration" --no-build --no-restore -v "$verbosity" /bl:"$logFile" /err $properties "$solution"

  if ($LastExitCode -ne 0) {
    throw "'Test' failed for '$solution'"
  }
}

try {
  if ($help) {
    Help
    exit 0
  }

  if ($ci) {
    $build = $true
    $pack = $true
    $restore = $true
    $test = $true

    if ($architecture -eq "") {
      $architecture = "<auto>"
    }
  }
  elseif (($architecture -ne "") -and ($architecture -ne "<auto>")) {
    $properties += "/p:PlatformTarget=$architecture"
  }

  $RepoRoot = Join-Path -Path $PSScriptRoot -ChildPath ".."

  if ($solution -eq "") {
    $solution = Join-Path -Path $RepoRoot -ChildPath "LLVMSharp.slnx"
  }

  $ArtifactsDir = Join-Path -Path $RepoRoot -ChildPath "artifacts"
  Create-Directory -Path $ArtifactsDir

  $LogDir = Join-Path -Path $ArtifactsDir -ChildPath "log"
  Create-Directory -Path $LogDir

  if ($architecture -ne "") {
    $env:DOTNET_CLI_TELEMETRY_OPTOUT = 1
    $env:DOTNET_MULTILEVEL_LOOKUP = 0
    $env:DOTNET_SKIP_FIRST_TIME_EXPERIENCE = 1

    $DotNetInstallScript = Join-Path -Path $ArtifactsDir -ChildPath "dotnet-install.ps1"
    Invoke-WebRequest -Uri "https://dot.net/v1/dotnet-install.ps1" -OutFile $DotNetInstallScript -UseBasicParsing

    $DotNetInstallDirectory = Join-Path -Path $ArtifactsDir -ChildPath "dotnet"
    Create-Directory -Path $DotNetInstallDirectory

    & $DotNetInstallScript -Channel 10.0 -Version latest -InstallDir $DotNetInstallDirectory -Architecture $architecture

    $env:PATH="$DotNetInstallDirectory;$env:PATH"
  }

  if ($restore) {
    Restore
  }

  if ($build) {
    Build
  }

  if ($test) {
    Test
  }

  if ($pack) {
    Pack
  }

  if ($regeneratenative) {
    Regenerate-Native
  }
}
catch {
  Write-Host -Object $_
  Write-Host -Object $_.Exception
  Write-Host -Object $_.ScriptStackTrace
  exit 1
}
