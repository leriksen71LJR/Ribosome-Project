# Actions Component — Contracts

**Path:** `src/Fortress.Console/Components/Actions/Contracts/`

## IActionHandler

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
    /// Executes the action. Must be async (Phase 1.1+).
    /// </summary>
    Task<bool> ExecuteAsync(ActionContext context, CancellationToken cancellationToken = default);
}
```

**Requirements:**

- `ExecuteAsync` must begin with guard clauses (null `context`, cancellation, session) per `process/AGENTS.md` Rule 3.
- `ExitHandler` may omit session guard on execute when exiting — see `adr/0002-exit-handler-vs-session-guard.md`.
- Visibility rules per handler: `HANDLER-INVENTORY.md` table.

## IItem

Defined in Data component; referenced by Actions for handler item operations. See `components/Data/MODEL.md`.