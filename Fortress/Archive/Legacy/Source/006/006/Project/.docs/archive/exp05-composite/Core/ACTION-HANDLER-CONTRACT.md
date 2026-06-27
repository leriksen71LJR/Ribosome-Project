# ACTION-HANDLER-CONTRACT.md (Core)

**Purpose:** Define the core contract that all `IActionHandler` implementations must follow.

This file is intentionally narrow — it contains only the interface definition and key behavioral requirements.

```csharp
public interface IActionHandler
{
    string Name { get; }
    string Description { get; }

    /// <summary>
    /// Returns true if this handler should be visible in the current menu context.
    /// </summary>
    bool IsVisible(ActionContext context);

    /// <summary>
    /// Executes the action. Must be async.
    /// </summary>
    Task<bool> ExecuteAsync(ActionContext context, CancellationToken cancellationToken = default);
}
```

## Key Requirements
- Every implementation must begin `ExecuteAsync` with guard clauses (null context, cancellation, session checks).
- Visibility logic is part of the handler contract but specific rules may be defined in strategy files.

*This contract is considered relatively stable. Changes should be made with care.*