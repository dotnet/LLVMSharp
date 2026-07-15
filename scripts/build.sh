#!/bin/bash

SOURCE="${BASH_SOURCE[0]}"
while [ -h "$SOURCE" ]; do # resolve $SOURCE until the file is no longer a symlink
  ScriptRoot="$( cd -P "$( dirname "$SOURCE" )" && pwd )"
  SOURCE="$(readlink "$SOURCE")"
  [[ $SOURCE != /* ]] && SOURCE="$ScriptRoot/$SOURCE" # if $SOURCE was a relative symlink, we need to resolve it relative to the path where the symlink file was located
done
ScriptRoot="$( cd -P "$( dirname "$SOURCE" )" && pwd )"

architecture=''
build=false
ci=false
configuration='Debug'
help=false
llvm=''
pack=false
regeneratenative=false
restore=false
rid=''
solution=''
target=''
test=false
verbosity='minimal'
properties=''

while [[ $# -gt 0 ]]; do
  lower="$(echo "$1" | awk '{print tolower($0)}')"
  case $lower in
    --architecture)
      architecture=$2
      shift 2
      ;;
    --build)
      build=true
      shift 1
      ;;
    --ci)
      ci=true
      shift 1
      ;;
    --configuration)
      configuration=$2
      shift 2
      ;;
    --help)
      help=true
      shift 1
      ;;
    --llvm)
      llvm=$2
      shift 2
      ;;
    --pack)
      pack=true
      shift 1
      ;;
    --regeneratenative)
      regeneratenative=true
      shift 1
      ;;
    --restore)
      restore=true
      shift 1
      ;;
    --rid)
      rid=$2
      shift 2
      ;;
    --solution)
      solution=$2
      shift 2
      ;;
    --target)
      target=$2
      shift 2
      ;;
    --test)
      test=true
      shift 1
      ;;
    --verbosity)
      verbosity=$2
      shift 2
      ;;
    *)
      properties="$properties $1"
      shift 1
      ;;
  esac
done

function Build {
  logFile="$LogDir/$configuration/build.binlog"

  if [[ -z "$properties" ]]; then
    dotnet build -c "$configuration" --no-restore -v "$verbosity" /bl:"$logFile" /err "$solution"
  else
    dotnet build -c "$configuration" --no-restore -v "$verbosity" /bl:"$logFile" /err "${properties[@]}" "$solution"
  fi

  LASTEXITCODE=$?

  if [ "$LASTEXITCODE" != 0 ]; then
    echo "'Build' failed for '$solution'"
    return "$LASTEXITCODE"
  fi
}

function CreateDirectory {
  if [ ! -d "$1" ]
  then
    mkdir -p "$1"
  fi
}

function Help {
  echo "Common settings:"
  echo "  --configuration <value>   Build configuration (Debug, Release)"
  echo "  --verbosity <value>       Msbuild verbosity (q[uiet], m[inimal], n[ormal], d[etailed], and diag[nostic])"
  echo "  --help                    Print help and exit"
  echo ""
  echo "Actions:"
  echo "  --restore                 Restore dependencies"
  echo "  --build                   Build solution"
  echo "  --test                    Run all tests in the solution"
  echo "  --pack                    Package build artifacts"
  echo "  --regeneratenative        Stage a native binary from the matching LLVM release"
  echo "                            (use with --target and --rid)"
  echo ""
  echo "Advanced settings:"
  echo "  --solution <value>        Path to solution to build"
  echo "  --ci                      Set when running on CI server"
  echo "  --architecture <value>    Test Architecture (<auto>, amd64, x64, x86, arm64, arm)"
  echo ""
  echo "Command line arguments not listed above are passed through to MSBuild."
}

function Pack {
  logFile="$LogDir/$configuration/pack"

  if [[ -z "$properties" ]]; then
    dotnet pack -c "$configuration" --no-build --no-restore -v "$verbosity" /bl:"$logFile.binlog" /err "$solution"
    dotnet pack -c "$configuration" --no-build --no-restore -v "$verbosity" /bl:"$logFile.agnostic.binlog" /err /p:SKIP_USE_CURRENT_RUNTIME=true "$solution"
  else
    dotnet pack -c "$configuration" --no-build --no-restore -v "$verbosity" /bl:"$logFile.binlog" /err "${properties[@]}" "$solution"
    dotnet pack -c "$configuration" --no-build --no-restore -v "$verbosity" /bl:"$logFile.agnostic.binlog" /err /p:SKIP_USE_CURRENT_RUNTIME=true "${properties[@]}" "$solution"
  fi

if $ci; then
  if [[ -z "$properties" ]]; then
    dotnet pack -c "$configuration" --no-build --no-restore -v "$verbosity" /bl:"$logFile.preview.binlog" /err /p:PACKAGE_PUBLISH_MODE=preview "$solution"
    dotnet pack -c "$configuration" --no-build --no-restore -v "$verbosity" /bl:"$logFile.stable.binlog" /err /p:PACKAGE_PUBLISH_MODE=stable "$solution"

    dotnet pack -c "$configuration" --no-build --no-restore -v "$verbosity" /bl:"$logFile.agnostic.preview.binlog" /err /p:SKIP_USE_CURRENT_RUNTIME=true /p:PACKAGE_PUBLISH_MODE=preview "$solution"
    dotnet pack -c "$configuration" --no-build --no-restore -v "$verbosity" /bl:"$logFile.agnostic.stable.binlog" /err /p:SKIP_USE_CURRENT_RUNTIME=true /p:PACKAGE_PUBLISH_MODE=stable "$solution"
  else
    dotnet pack -c "$configuration" --no-build --no-restore -v "$verbosity" /bl:"$logFile.preview.binlog" /err /p:PACKAGE_PUBLISH_MODE=preview "${properties[@]}" "$solution"
    dotnet pack -c "$configuration" --no-build --no-restore -v "$verbosity" /bl:"$logFile.stable.binlog" /err /p:PACKAGE_PUBLISH_MODE=stable "${properties[@]}" "$solution"

    dotnet pack -c "$configuration" --no-build --no-restore -v "$verbosity" /bl:"$logFile.agnostic.preview.binlog" /err /p:SKIP_USE_CURRENT_RUNTIME=true /p:PACKAGE_PUBLISH_MODE=preview "${properties[@]}" "$solution"
    dotnet pack -c "$configuration" --no-build --no-restore -v "$verbosity" /bl:"$logFile.agnostic.stable.binlog" /err /p:SKIP_USE_CURRENT_RUNTIME=true /p:PACKAGE_PUBLISH_MODE=stable "${properties[@]}" "$solution"
  fi
fi

  LASTEXITCODE=$?

  if [ "$LASTEXITCODE" != 0 ]; then
    echo "'Build' failed for '$solution'"
    return "$LASTEXITCODE"
  fi
}

function Restore {
  logFile="$LogDir/$configuration/restore.binlog"

  if [[ -z "$properties" ]]; then
    dotnet restore -v "$verbosity" /bl:"$logFile" /err "$solution"
  else
    dotnet restore -v "$verbosity" /bl:"$logFile" /err "${properties[@]}" "$solution"
  fi

  LASTEXITCODE=$?

  if [ "$LASTEXITCODE" != 0 ]; then
    echo "'Restore' failed for '$solution'"
    return "$LASTEXITCODE"
  fi
}

function GetLlvmVersion {
  if [[ -n "$llvm" ]]; then
    LASTEXITCODE=0
    return
  fi

  llvm="$(sed -n 's/^project(LLVMSharp VERSION \([0-9.]*\)).*/\1/p' "$RepoRoot/CMakeLists.txt")"

  if [[ -z "$llvm" ]]; then
    echo "Could not parse the LLVM version from '$RepoRoot/CMakeLists.txt'"
    LASTEXITCODE=1
    return "$LASTEXITCODE"
  fi

  LASTEXITCODE=0
}

function DownloadLlvm {
  runtime="$1"
  destination="$2"

  case "$runtime" in
    win-x64)     asset="clang+llvm-${llvm}-x86_64-pc-windows-msvc.tar.xz" ;;
    win-arm64)   asset="clang+llvm-${llvm}-aarch64-pc-windows-msvc.tar.xz" ;;
    linux-x64)   asset="LLVM-${llvm}-Linux-X64.tar.xz" ;;
    linux-arm64) asset="LLVM-${llvm}-Linux-ARM64.tar.xz" ;;
    osx-arm64)   asset="LLVM-${llvm}-macOS-ARM64.tar.xz" ;;
    *)
      echo "Unsupported runtime identifier '$runtime'"
      LASTEXITCODE=1
      return "$LASTEXITCODE"
      ;;
  esac

  url="https://github.com/llvm/llvm-project/releases/download/llvmorg-${llvm}/${asset}"
  archive="$ArtifactsDir/llvm-${runtime}.tar.xz"

  CreateDirectory "$destination"

  curl -fSL "$url" -o "$archive"
  LASTEXITCODE=$?

  if [ "$LASTEXITCODE" != 0 ]; then
    echo "'curl' failed to download '$url'"
    return "$LASTEXITCODE"
  fi

  tar -xf "$archive" -C "$destination" --strip-components=1
  LASTEXITCODE=$?

  if [ "$LASTEXITCODE" != 0 ]; then
    echo "'tar' failed to extract '$archive'"
    return "$LASTEXITCODE"
  fi
}

function LiftLibLLVM {
  runtime="$1"
  destination="$2"
  major="${llvm%%.*}"

  # The official LLVM releases ship no shared libLLVM on Linux/macOS (only static
  # archives), so lift it from the most-official prebuilt source per platform: the
  # LLVM project's apt.llvm.org repository on Linux and Homebrew on macOS. Windows'
  # LLVM-C.dll is lifted from the official release in build.ps1 instead.
  case "$runtime" in
    linux-*)
      codename="$(. /etc/os-release && echo "$VERSION_CODENAME")"
      wget -qO- https://apt.llvm.org/llvm-snapshot.gpg.key | sudo tee /etc/apt/trusted.gpg.d/apt.llvm.org.asc > /dev/null
      echo "deb http://apt.llvm.org/${codename}/ llvm-toolchain-${codename}-${major} main" | sudo tee /etc/apt/sources.list.d/llvm.list > /dev/null
      sudo apt-get update

      downloadDir="$ArtifactsDir/apt/$runtime"
      CreateDirectory "$downloadDir"
      ( cd "$downloadDir" && apt-get download "libllvm${major}" )
      LASTEXITCODE=$?

      if [ "$LASTEXITCODE" != 0 ]; then
        echo "'apt-get download libllvm${major}' failed for '$runtime'"
        return "$LASTEXITCODE"
      fi

      deb="$(find "$downloadDir" -name "libllvm${major}_*.deb" | head -n1)"

      if [[ -z "$deb" ]]; then
        echo "'libllvm${major}' package was not downloaded for '$runtime'"
        LASTEXITCODE=1
        return "$LASTEXITCODE"
      fi

      dpkg-deb -x "$deb" "$downloadDir/extract"
      src="$(find "$downloadDir/extract" -name 'libLLVM*.so*' -type f | head -n1)"
      ;;
    osx-*)
      brew install "llvm@${major}" || brew install llvm
      prefix="$(brew --prefix "llvm@${major}" 2> /dev/null || brew --prefix llvm)"
      # The 'brew install llvm' fallback (used when 'llvm@${major}' is unavailable) can
      # pull a different major; verify it matches the tracked version before packaging.
      installedMajor="$("$prefix/bin/llvm-config" --version 2> /dev/null | cut -d. -f1)"
      if [[ "$installedMajor" != "$major" ]]; then
        echo "Homebrew provided LLVM major '$installedMajor' but '$major' is required for '$runtime'"
        LASTEXITCODE=1
        return "$LASTEXITCODE"
      fi
      src="$prefix/lib/libLLVM.dylib"
      ;;
    *)
      echo "'$runtime' cannot lift libLLVM here; use build.ps1 on the matching runner"
      LASTEXITCODE=1
      return "$LASTEXITCODE"
      ;;
  esac

  case "$runtime" in
    osx-*) name='libLLVM.dylib' ;;
    *)     name='libLLVM.so' ;;
  esac

  if [[ -z "$src" ]] || [[ ! -f "$src" ]]; then
    echo "'$name' was not found for '$runtime'"
    LASTEXITCODE=1
    return "$LASTEXITCODE"
  fi

  cp -L "$src" "$destination/$name"
  LASTEXITCODE=$?
}

function BuildLibLLVMSharp {
  runtime="$1"
  source="$2"
  destination="$3"

  case "$runtime" in
    linux-*|osx-*)
      ;;
    *)
      echo "'$runtime' cannot build libLLVMSharp here; use build.ps1 on the matching runner"
      LASTEXITCODE=1
      return "$LASTEXITCODE"
      ;;
  esac

  nativeBuildDir="$ArtifactsDir/bin/native/$runtime"

  cmake -B "$nativeBuildDir" -S "$RepoRoot" -DCMAKE_BUILD_TYPE=Release -DPATH_TO_LLVM="$source"
  LASTEXITCODE=$?

  if [ "$LASTEXITCODE" != 0 ]; then
    echo "'cmake' configure failed for '$runtime'"
    return "$LASTEXITCODE"
  fi

  cmake --build "$nativeBuildDir" --target LLVMSharp
  LASTEXITCODE=$?

  if [ "$LASTEXITCODE" != 0 ]; then
    echo "'cmake' build failed for '$runtime'"
    return "$LASTEXITCODE"
  fi

  case "$runtime" in
    osx-*) name='libLLVMSharp.dylib' ;;
    *)     name='libLLVMSharp.so' ;;
  esac

  # CMake's VERSION/SOVERSION emit a versioned library plus an unversioned symlink, so
  # copy the dereferenced contents to get a real file.
  src="$(find "$nativeBuildDir" -name "$name" | head -n1)"

  if [[ -z "$src" ]]; then
    echo "'$name' was not produced for '$runtime'"
    LASTEXITCODE=1
    return "$LASTEXITCODE"
  fi

  cp -L "$src" "$destination/$name"
  LASTEXITCODE=$?
}

function RegenerateNative {
  if [[ -z "$rid" ]]; then
    echo "--rid is required with --regeneratenative"
    LASTEXITCODE=1
    return "$LASTEXITCODE"
  fi

  if [[ -z "$target" ]]; then
    echo "--target is required with --regeneratenative"
    LASTEXITCODE=1
    return "$LASTEXITCODE"
  fi

  GetLlvmVersion

  if [ "$LASTEXITCODE" != 0 ]; then
    return "$LASTEXITCODE"
  fi

  llvmDir="$ArtifactsDir/llvm/$rid"
  stagingDir="$ArtifactsDir/native/$rid"

  CreateDirectory "$stagingDir"

  if [[ "$target" == "libLLVM" ]]; then
    LiftLibLLVM "$rid" "$stagingDir"
  elif [[ "$target" == "libLLVMSharp" ]]; then
    DownloadLlvm "$rid" "$llvmDir"

    if [ "$LASTEXITCODE" != 0 ]; then
      return "$LASTEXITCODE"
    fi

    BuildLibLLVMSharp "$rid" "$llvmDir" "$stagingDir"
  else
    echo "Unsupported target '$target'"
    LASTEXITCODE=1
  fi

  if [ "$LASTEXITCODE" != 0 ]; then
    return "$LASTEXITCODE"
  fi
}

function Test {
  logFile="$LogDir/$configuration/test.binlog"

  if [[ -z "$properties" ]]; then
    dotnet test -c "$configuration" --no-build --no-restore -v "$verbosity" /bl:"$logFile" /err "$solution"
  else
    dotnet test -c "$configuration" --no-build --no-restore -v "$verbosity" /bl:"$logFile" /err "${properties[@]}" "$solution"
  fi

  LASTEXITCODE=$?

  if [ "$LASTEXITCODE" != 0 ]; then
    echo "'Test' failed for '$solution'"
    return "$LASTEXITCODE"
  fi
}

if $help; then
  Help
  exit 0
fi

if $ci; then
  build=true
  pack=true
  restore=true
  test=true

  if [[ -z "$architecture" ]]; then
    architecture="<auto>"
  fi
fi

RepoRoot="$ScriptRoot/.."

if [[ -z "$solution" ]]; then
  solution="$RepoRoot/LLVMSharp.slnx"
fi

ArtifactsDir="$RepoRoot/artifacts"
CreateDirectory "$ArtifactsDir"

LogDir="$ArtifactsDir/log"
CreateDirectory "$LogDir"

if [[ ! -z "$architecture" ]]; then
  export DOTNET_CLI_TELEMETRY_OPTOUT=1
  export DOTNET_MULTILEVEL_LOOKUP=0
  export DOTNET_SKIP_FIRST_TIME_EXPERIENCE=1

  DotNetInstallScript="$ArtifactsDir/dotnet-install.sh"
  wget -O "$DotNetInstallScript" "https://dot.net/v1/dotnet-install.sh"

  DotNetInstallDirectory="$ArtifactsDir/dotnet"
  CreateDirectory "$DotNetInstallDirectory"

  . "$DotNetInstallScript" --channel 10.0 --version latest --install-dir "$DotNetInstallDirectory" --architecture "$architecture"

  PATH="$DotNetInstallDirectory:$PATH:"
fi

if $restore; then
  Restore

  if [ "$LASTEXITCODE" != 0 ]; then
    return "$LASTEXITCODE"
  fi
fi

if $build; then
  Build

  if [ "$LASTEXITCODE" != 0 ]; then
    return "$LASTEXITCODE"
  fi
fi

if $test; then
  Test

  if [ "$LASTEXITCODE" != 0 ]; then
    return "$LASTEXITCODE"
  fi
fi

if $pack; then
  Pack

  if [ "$LASTEXITCODE" != 0 ]; then
    return "$LASTEXITCODE"
  fi
fi

if $regeneratenative; then
  RegenerateNative

  if [ "$LASTEXITCODE" != 0 ]; then
    return "$LASTEXITCODE"
  fi
fi
