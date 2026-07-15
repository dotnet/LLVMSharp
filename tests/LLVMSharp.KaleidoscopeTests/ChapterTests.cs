// Copyright (c) .NET Foundation and Contributors. All Rights Reserved. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using NUnit.Framework;

namespace LLVMSharp.KaleidoscopeTests;

/// <summary>
/// Smoke tests that each Kaleidoscope tutorial chapter still builds and produces the expected output.
/// Every chapter is an executable REPL (or, for chapter 8, a batch compiler), so each test launches the
/// chapter as a subprocess, feeds it a Kaleidoscope script on stdin, and asserts on what it prints.
/// Running each chapter in its own process matches how a user runs the samples and keeps the native LLVM
/// state isolated between chapters.
/// </summary>
public sealed class ChapterTests
{
    private const int TimeoutMilliseconds = 120_000;

    [Test]
    public void Chapter3_EmitsIr()
    {
        var output = RunChapter("Chapter3", """
            extern sin(x);
            def foo(a b) a + b;
            foo(2, 3);
            """);

        Assert.Multiple(() =>
        {
            Assert.That(output, Does.Contain("declare double @sin(double)"));
            Assert.That(output, Does.Contain("define double @foo(double %a, double %b)"));
        });
    }

    [Test]
    public void Chapter4_JitsAndOptimizes()
    {
        // Two calls to the same function must give distinct results in one session (upstream #1), and
        // an extern libc function must resolve from the host process (#69).
        var output = RunChapter("Chapter4", """
            def foo(a b) a*a + 2*a*b + b*b;
            foo(2, 3);
            foo(4, 5);
            extern cos(x);
            cos(0);
            """);

        Assert.Multiple(() =>
        {
            Assert.That(output, Does.Contain("Evaluated to 25"));
            Assert.That(output, Does.Contain("Evaluated to 81"));
            Assert.That(output, Does.Contain("Evaluated to 1"));
        });
    }

    [Test]
    public void Chapter5_ControlFlowAndHostOutput()
    {
        // fib exercises if/else; printstar exercises the for loop plus the putchard host function (#133).
        var output = RunChapter("Chapter5", """
            def fib(x) if x < 3 then 1 else fib(x - 1) + fib(x - 2);
            fib(10);
            extern putchard(x);
            def printstar(n) for i = 1, i < n in putchard(42);
            printstar(6);
            """);

        Assert.Multiple(() =>
        {
            Assert.That(output, Does.Contain("Evaluated to 55"));
            Assert.That(output.Count(c => c == '*'), Is.EqualTo(6), "printstar(6) runs the loop while i < 6 starting at i = 1, printing six '*' characters");
        });
    }

    [Test]
    public void Chapter6_UserDefinedOperators()
    {
        var output = RunChapter("Chapter6", """
            def unary!(v) if v then 0 else 1;
            !0;
            !1;
            """);

        Assert.Multiple(() =>
        {
            Assert.That(output, Does.Contain("Evaluated to 1"));
            Assert.That(output, Does.Contain("Evaluated to 0"));
        });
    }

    [Test]
    public void Chapter7_MutableVariables()
    {
        // test mutates its parameter; fib is the iterative mutable-variable formulation.
        var output = RunChapter("Chapter7", """
            def binary : 1 (x y) y;
            def test(x) (x = x + 1) + x;
            test(3);
            def fib(x) var a = 1, b = 1, c in (for i = 3, i < x in c = a + b : a = b : b = c) : b;
            fib(10);
            """);

        Assert.Multiple(() =>
        {
            Assert.That(output, Does.Contain("Evaluated to 8"));
            Assert.That(output, Does.Contain("Evaluated to 55"));
        });
    }

    [Test]
    public void Chapter8_EmitsObjectFile()
    {
        var workingDirectory = Directory.CreateTempSubdirectory("kaleidoscope-ch8-").FullName;

        try
        {
            var output = RunChapter("Chapter8", "def average(x y) (x + y) * 0.5;", workingDirectory);
            var objectFile = Path.Combine(workingDirectory, "output.o");

            Assert.Multiple(() =>
            {
                Assert.That(output, Does.Contain("define double @average"));
                Assert.That(File.Exists(objectFile), Is.True, "expected output.o to be emitted");
                Assert.That(new FileInfo(objectFile).Length, Is.GreaterThan(0), "output.o should not be empty");
            });
        }
        finally
        {
            Directory.Delete(workingDirectory, recursive: true);
        }
    }

    [Test]
    public void Chapter9_EmitsDebugInfo()
    {
        var workingDirectory = Directory.CreateTempSubdirectory("kaleidoscope-ch9-").FullName;

        try
        {
            var output = RunChapter("Chapter9", "def fib(n) if n < 3 then 1 else fib(n - 1) + fib(n - 2);", workingDirectory);
            var objectFile = Path.Combine(workingDirectory, "output.o");

            Assert.Multiple(() =>
            {
                // The emitted IR carries DWARF metadata: a compile unit, a subprogram, a parameter
                // variable, and a source location on the function's instructions.
                Assert.That(output, Does.Contain("!DICompileUnit"));
                Assert.That(output, Does.Contain("!DISubprogram(name: \"fib\""));
                Assert.That(output, Does.Contain("!DILocalVariable(name: \"n\""));
                Assert.That(output, Does.Contain("!dbg"));
                Assert.That(File.Exists(objectFile), Is.True, "expected output.o to be emitted");
                Assert.That(new FileInfo(objectFile).Length, Is.GreaterThan(0), "output.o should not be empty");
            });
        }
        finally
        {
            Directory.Delete(workingDirectory, recursive: true);
        }
    }

    private static string RunChapter(string chapter, string input, string? workingDirectory = null)
    {
        var assembly = LocateChapterAssembly(chapter);

        var startInfo = new ProcessStartInfo("dotnet")
        {
            RedirectStandardInput = true,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            WorkingDirectory = workingDirectory ?? Path.GetDirectoryName(assembly)!,
        };
        startInfo.ArgumentList.Add("exec");
        startInfo.ArgumentList.Add(assembly);

        using var process = new Process { StartInfo = startInfo };
        var standardOutput = new StringBuilder();
        var standardError = new StringBuilder();
        process.OutputDataReceived += (_, e) => { if (e.Data is not null) { _ = standardOutput.AppendLine(e.Data); } };
        process.ErrorDataReceived += (_, e) => { if (e.Data is not null) { _ = standardError.AppendLine(e.Data); } };

        _ = process.Start();
        process.BeginOutputReadLine();
        process.BeginErrorReadLine();
        process.StandardInput.Write(input);
        process.StandardInput.Close();

        if (!process.WaitForExit(TimeoutMilliseconds))
        {
            process.Kill(entireProcessTree: true);
            Assert.Fail($"{chapter} did not exit within {TimeoutMilliseconds}ms.\nstdout:\n{standardOutput}\nstderr:\n{standardError}");
        }

        process.WaitForExit(); // flush the async output readers.

        Assert.That(process.ExitCode, Is.Zero, $"{chapter} exited with {process.ExitCode}.\nstdout:\n{standardOutput}\nstderr:\n{standardError}");
        return standardOutput.ToString();
    }

    private static string LocateChapterAssembly(string chapter)
    {
        var repositoryRoot = FindRepositoryRoot();
        var configuration = GetBuildConfiguration();
        var chapterBin = Path.Combine(repositoryRoot, "samples", "KaleidoscopeTutorial", chapter, "bin", configuration, "net10.0");

        if (Directory.Exists(chapterBin))
        {
            // The chapter builds to a runtime-identifier subdirectory (e.g. .../net10.0/win-x64/), so
            // search rather than hard-coding the RID.
            var assembly = Directory.EnumerateFiles(chapterBin, chapter + ".dll", SearchOption.AllDirectories).FirstOrDefault();
            if (assembly is not null)
            {
                return assembly;
            }
        }

        Assert.Fail($"Could not find {chapter}.dll under '{chapterBin}'. Build the '{configuration}' configuration of the solution before running these tests.");
        return string.Empty; // unreachable; Assert.Fail throws.
    }

    private static string FindRepositoryRoot()
    {
        for (var directory = new DirectoryInfo(AppContext.BaseDirectory); directory is not null; directory = directory.Parent)
        {
            if (File.Exists(Path.Combine(directory.FullName, "LLVMSharp.slnx")) &&
                Directory.Exists(Path.Combine(directory.FullName, "samples")))
            {
                return directory.FullName;
            }
        }

        Assert.Fail("Could not locate the repository root (no ancestor directory contains LLVMSharp.slnx and samples/).");
        return string.Empty; // unreachable; Assert.Fail throws.
    }

    private static string GetBuildConfiguration()
    {
        foreach (var metadata in typeof(ChapterTests).Assembly.GetCustomAttributes<AssemblyMetadataAttribute>())
        {
            if ((metadata.Key == "BuildConfiguration") && !string.IsNullOrEmpty(metadata.Value))
            {
                return metadata.Value;
            }
        }

        return "Release";
    }
}
