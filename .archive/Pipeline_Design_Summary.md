# Pipeline Design Summary (Current State)

**Date:** June 14, 2026  
**Status:** Paused for Shootout Round 1 — Ready for refinement in Round 2  
**Goal:** Support both simple linear pipelines and advanced Chain of Responsibility behavior without fragmenting the step model long-term.

---

## Core Interfaces

```csharp
/// <summary>
/// Minimal marker interface for all pipeline contexts.
/// Intentionally empty so concrete contexts can define their own shape.
/// </summary>
public interface IPipelineContext
{
}

/// <summary>
/// Special context used when a step wants Chain of Responsibility behavior.
/// Inherits from IPipelineContext so it can be used in place of the normal context.
/// Acts as a wrapper that provides access to the real context + the ability to continue the chain.
/// </summary>
public interface IPipelineChainedContext<TContext> : IPipelineContext
    where TContext : IPipelineContext
{
    /// <summary>
    /// The actual strongly-typed pipeline context.
    /// </summary>
    TContext PipelineContext { get; }

    /// <summary>
    /// Invokes the next step in the chain.
    /// TODO: Change from Action to something that returns PipelineStepResult for proper error propagation.
    /// </summary>
    Action Next { get; }
}

/// <summary>
/// A single step in a pipeline.
/// Most steps will use the normal ExecuteAsync(TContext).
/// Steps that need CoR behavior can accept IPipelineChainedContext<TContext> instead.
/// </summary>
public interface IPipelineStep<TContext>
    where TContext : IPipelineContext
{
    string Name { get; }

    Task<PipelineStepResult> ExecuteAsync(TContext context);
}

/// <summary>
/// A named, executable pipeline that can itself be used as a step inside another pipeline.
/// </summary>
public interface IPipeline<TContext> : IPipelineStep<TContext>
    where TContext : IPipelineContext
{
    // Name is inherited from IPipelineStep
}

/// <summary>
/// Result of executing a pipeline step (or entire pipeline).
/// </summary>
public class PipelineStepResult
{
    public bool Success { get; init; } = true;
    public List<Exception> Errors { get; init; } = new();
    public List<string> Messages { get; init; } = new();
}
```

---

## Key Design Decisions (Locked)

| Decision | Value | Rationale |
|----------|-------|-----------|
| Naming style | `IPipelineStep`, `IPipelineContext`, `IPipelineChainedContext`, `PipelineExecutor` | Shorter and consistent with user's preference |
| Step interface | Single `IPipelineStep<TContext>` | Avoid long-term fragmentation of step types |
| CoR mechanism | Opt-in via `IPipelineChainedContext<TContext>` (now inherits from `IPipelineContext`) | Removes need to cast in many cases; `PipelineContext` property gives access to real context |
| `IPipeline<TContext>` | Inherits from `IPipelineStep<TContext>` | Enables clean composition (pipelines can contain other pipelines as steps) |
| `IPipelineExecutor<TContext>` | Stateless, injectable service | Owns all chain construction, error handling, and orchestration (middleware pattern) |
| Async | Native (`Task<...>`) on steps, pipelines, and executor | Consistent with modern .NET and Action Handlers (which will also become async) |
| Context mutability | Mutable shared context | Central data model for the pipeline — steps read/write to it |
| Per-step CoR | Not supported in v1 | CoR lives at the pipeline level via the executor |

---

## Open Questions / Work for Round 2

1. **Two ExecuteAsync signatures?**  
   Currently we may end up with steps that take `TContext` vs steps that take `IPipelineChainedContext<TContext>`.  
   How does `IPipelineExecutor<TContext>` decide which one to call? Do we want to avoid this split entirely?

2. **Error propagation through `Next`**  
   `Next` is currently `Action`. It should probably be `Func<Task<PipelineStepResult>>` or similar so errors from downstream steps propagate correctly.

3. **How `IPipelineChainedContext` is created and injected**  
   The executor must create an implementation of `IPipelineChainedContext<TContext>` that knows how to continue the chain. Where does this logic live cleanly?

4. **Registration pattern**  
   How do we register pipelines and their steps via `IDependencyModule`? Should each pipeline have its own module, or is there a central registration pattern?

5. **Concrete `PipelineExecutor` implementation**  
   Need to write the actual chain-building logic (reverse-order delegate wrapping, try/catch wrapping, default stop-on-error behavior).

6. **Optional base class?**  
   Should we still offer a `PipelineStepBase<TContext>` for convenience, or keep everything interface-only?

---

## Folder Structure (Proposed)

```
Components/
└── Pipelines/
    ├── Contracts/
    │   ├── IPipelineContext.cs
    │   ├── IPipelineChainedContext.cs
    │   ├── IPipelineStep.cs
    │   ├── IPipeline.cs
    │   └── PipelineStepResult.cs
    ├── Implementations/
    │   └── PipelineExecutor.cs
    └── Model/
        └── PipelineContextBase.cs   (optional abstract base with Request/Result)
```

---

## Usage Examples (Current Thinking)

**Normal step:**

```csharp
public class ValidateStep : IPipelineStep<ExportPipelineContext>
{
    public string Name => "Validate";

    public async Task<PipelineStepResult> ExecuteAsync(ExportPipelineContext context)
    {
        // ... do work ...
        return new PipelineStepResult { Success = true };
    }
}
```

**CoR-aware step (using chained context):**

```csharp
public class ConditionalStep : IPipelineStep<ExportPipelineContext>
{
    public string Name => "Conditional";

    public async Task<PipelineStepResult> ExecuteAsync(ExportPipelineContext context)
    {
        if (context.ShouldSkipRemaining)
        {
            return new PipelineStepResult { Success = true };
        }

        if (context is IPipelineChainedContext<ExportPipelineContext> chained)
        {
            var result = await chained.Next(); // or however we expose it
            // inspect result, react to errors, etc.
            return result;
        }

        return new PipelineStepResult { Success = true };
    }
}
```

---

## Next Steps (After Shootout Round 1)

- Revisit this design with fresh eyes
- Decide on final approach for step signatures vs chained context
- Implement `PipelineExecutor<TContext>`
- Add registration support via `IDependencyModule`
- Update `ARCHITECTURE.md` and `CODING_DESIGN.md`
- Test the model during Shootout Round 2

---

**Status:** Paused. Ready to resume after Phase 1 shootout.
