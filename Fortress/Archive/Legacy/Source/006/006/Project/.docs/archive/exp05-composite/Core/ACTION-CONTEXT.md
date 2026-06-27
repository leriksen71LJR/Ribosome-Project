# ACTION-CONTEXT.md (Core)

**Purpose:** Define the `ActionContext` class as a data and state container.

This file focuses only on the data container role of `ActionContext`. Service location and dependency injection concerns are explicitly excluded.

## Definition

`ActionContext` carries the information needed during action execution (items, session state, errors, validation results, etc.).

**Important Rule:**  
All services (such as `IConsole`, `IInputService`, `IStorageService`, etc.) **must** be dependency injected into the `IActionHandler` implementations themselves. They should **not** be placed inside `ActionContext`.

## Example Structure

```csharp
public class ActionContext
{
    public List<IItem> Items { get; set; } = new();
    public UserSession Session { get; set; }
    public List<Exception> ExceptionErrors { get; set; } = new();
    public List<string> ValidationErrors { get; set; } = new();
}
```

*This separation supports clearer Single Responsibility between state and services.*