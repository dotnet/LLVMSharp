param (
    [string]$filename = "libLLVM.dll",
    [string]$arch = "X64"
 )

function Get-Matches($Pattern) { 
  begin { $regex = New-Object Regex($pattern) }
  process { foreach ($match in ($regex.Matches($_))) { ([Object[]]$match.Groups)[-1].Value } }
}

Write-Host "!!! Please run from appropriate (i.e. x64 or x86) Visual Studio Tools Command Prompt !!!!" -foreground "yellow"
Write-Host "!!!! Generating for architecture --> $arch !!!!" -foreground magenta
Write-Host "*** Generating LLVM Shared DLL $filename for Architecture $arch ***" -foreground green

If (Test-Path MergeLLVM.lib) {
  Write-Host "Cleaning up MergeLLVM.lib"
  Remove-Item MergeLLVM.lib
}

If (Test-Path LLVM.lib) {
  Write-Host "Cleaning up LLVM.lib"
  Remove-Item LLVM.lib
}

lib /OUT:MergeLLVM.lib LLVM*.lib
dumpbin.exe /linkermember:1 MergeLLVM.lib > dumpbinoutput.txt
"EXPORTS" | out-file EXPORTS.DEF
"" | out-file EXPORTS.DEF -append

if ($arch -eq "x64")
{
  Get-Content -Path dumpbinoutput.txt | Get-Matches "^\s+\w+\s+(LLVM.*)$" | out-file -filepath EXPORTS.DEF -append
}
else
{
  Get-Content -Path dumpbinoutput.txt | Get-Matches "^\s+\w+\s+_(LLVM.*)$" | out-file -filepath EXPORTS.DEF -append
}

link /dll /DEF:EXPORTS.DEF /MACHINE:$arch /OUT:$filename MergeLLVM.lib

if ($LASTEXITCODE -eq 1112)
{
   Write-Host "Error: Please make sure you're use -arch X64 or -arch X86 depending on which version you compiled, and using the same VS Tools prompt" -foreground "red"
}
else {
   Write-Host "If no errors, Generated $filename in current directory" -foreground green
}

Remove-Item dumpbinoutput.txt
Remove-Item MergeLLVM.lib