# Kaleidoscope tutorial (LLVMSharp)

A C# port of LLVM's [Kaleidoscope tutorial](https://llvm.org/docs/tutorial/), built on
[LLVMSharp.Interop](../../sources/LLVMSharp.Interop). Kaleidoscope is a small functional language
(every value is a `double`) that the tutorial grows one feature at a time while introducing the LLVM
APIs for building IR, optimizing it, JIT-executing it, and finally emitting native object code.

## Layout

Unlike the upstream C++ tutorial — which copies the whole compiler into each chapter — this port keeps
the invariant frontend in a shared `Kaleidoscope.Common` library, and each chapter project contains
**only its delta** over the previous one. That makes the incremental steps easy to see: a chapter's
`Parser`/`CodeGenVisitor` derive from the previous chapter's and override just the new productions.

```
Kaleidoscope.Common/     Lexer, Token, the full AST, base Parser + base CodeGenVisitor,
                         the ORC LLJIT wrapper, the REPL loop, and host functions.
Chapter3/                Emit LLVM IR (no execution) — dumps the module.
Chapter4/                Add the JIT and the optimizer (new pass manager).
Chapter5/                Add control flow: if/then/else and for loops.
Chapter6/                Add user-defined unary and binary operators.
Chapter7/                Add mutable variables (alloca + mem2reg) and assignment.
Chapter8/                Compile a whole program to a native object file.
Chapter9/                Emit DWARF debug information alongside the object file.
```

Each chapter references the previous one, so `Chapter7` transitively sees `Chapter3`–`Chapter6` and
`Kaleidoscope.Common`. Chapters 4 and 8 are purely a new driver over the previous chapter's frontend;
Chapters 5–7 add grammar and codegen. Chapter 9 is chapter 8's batch compiler with debug info layered
on, so it references both Chapter 7 (frontend + codegen) and Chapter 8 (the object-file driver).

### Chapter ↔ tutorial mapping

| Chapter | Tutorial | Adds |
| --- | --- | --- |
| 3 | Ch. 2–3 | Lexer, parser, AST, IR generation (dump only) |
| 4 | Ch. 4 | ORC LLJIT execution + optimization passes |
| 5 | Ch. 5 | `if`/`then`/`else`, `for` loops |
| 6 | Ch. 6 | User-defined operators, operator precedence |
| 7 | Ch. 7 | Mutable variables, `var`/`in`, `=` assignment |
| 8 | Ch. 8 | Native object-file emission |
| 9 | Ch. 9 | DWARF debug information (compile unit, subprograms, locals, locations) |

The tutorial's [Chapter 10](https://llvm.org/docs/tutorial/MyFirstLanguageFrontend/LangImpl10.html) is a
prose conclusion (properties of SSA, tail calls, garbage collection, exception handling, and other places
to take a language) rather than a code delta, so there is no `Chapter10` project — see
[Where to go from here](#where-to-go-from-here) below.

## Running

Requires the .NET 10 preview SDK (resolved via the repo's `global.json`). From this directory:

```
dotnet build KaleidoscopeTutorial.slnx -c Release
dotnet run --project Chapter4 -c Release
```

Chapters 3–7 read Kaleidoscope from stdin (or a file passed as the first argument) as a REPL. Try:

```
def fib(x) if x < 3 then 1 else fib(x - 1) + fib(x - 2);
fib(10);

extern sin(x);
sin(1.0);

# user-defined operators (chapter 6+)
def unary!(v) if v then 0 else 1;
!0;

# mutable variables (chapter 7+)
def binary : 1 (x y) y;
def fibi(x) var a = 1, b = 1, c in (for i = 3, i < x in c = a + b : a = b : b = c) : b;
fibi(10);
```

Chapter 8 is a batch compiler: it reads a whole program and writes an object file (default `output.o`,
or a second argument):

```
echo "def average(x y) (x + y) * 0.5;" | dotnet run --project Chapter8 -c Release
```

The resulting object exports `average` with C ABI (`double average(double, double)`), so it can be
linked into a C/C++ program.

Chapter 9 is the same batch compiler with debug information: the emitted IR carries a `DICompileUnit`,
one `DISubprogram` per function, a `DILocalVariable` per parameter, and a `!dbg` source location on every
instruction, so the resulting object can be stepped through in a debugger.

```
echo "def fib(n) if n < 3 then 1 else fib(n - 1) + fib(n - 2);" | dotnet run --project Chapter9 -c Release
```

## Where to go from here

The upstream tutorial's Chapter 10 has no accompanying code — it is a conclusion pointing at directions a
real language would explore next. All of these are expressible with LLVMSharp's interop:

- **Global variables, typed values, and aggregates** — Kaleidoscope only has `double`; a real frontend
  tracks types and builds structs/arrays with `LLVMTypeRef`/`BuildGEP2`.
- **Garbage collection** — LLVM's statepoint/`gc` intrinsics and stack maps are exposed through the C API.
- **Exception handling** — `invoke`/`landingpad` and the `llvm.eh.*` intrinsics.
- **Debugger integration and optimization** — build on Chapter 9's debug info and tune the pass pipeline
  in `Kaleidoscope.Common`.

See the upstream
[Chapter 10 write-up](https://llvm.org/docs/tutorial/MyFirstLanguageFrontend/LangImpl10.html) for the full
discussion.

## Tests

These samples are part of the root `LLVMSharp.slnx`, so they build and are validated in CI. The
`LLVMSharp.KaleidoscopeTests` project under `tests/` launches each chapter as a subprocess, feeds it a
Kaleidoscope script, and asserts on the emitted IR / evaluated results / object file. Run them with:

```
dotnet build -c Release
dotnet test -c Release --no-build --filter "FullyQualifiedName~KaleidoscopeTests"
```

## Notes

- **JIT.** Execution uses ORC LLJIT (`Kaleidoscope.Common/KaleidoscopeJit.cs`). Each top-level
  expression is added as its own module under a resource tracker, executed, then removed, so entering
  several expressions in a row works correctly.
- **Extern / host functions.** `extern` declarations resolve against the host process (e.g. libc `sin`,
  `cos`), and `putchard`/`printd` are injected as absolute symbols (`Kaleidoscope.Common/HostFunctions.cs`)
  so the tutorial's `printstar`/`printd` examples work.
- **Optimizer.** Chapters 4+ run the new pass-manager pipeline
  (`mem2reg,instcombine,reassociate,gvn,simplifycfg`) via `LLVM.RunPasses`.
- **Debug info.** Chapter 9 threads a `SourceLocation` through the shared lexer/parser/AST and translates
  it into DWARF via `LLVMDIBuilderRef`. The location plumbing lives in `Kaleidoscope.Common` (an inert
  `EmitLocation` hook on the base `CodeGenVisitor`), so chapters 3–8 are unaffected.
- The interop under `../../sources/LLVMSharp.Interop/llvm` is auto-generated; these samples only use the
  hand-written friendly wrappers and the raw ORC C API.
