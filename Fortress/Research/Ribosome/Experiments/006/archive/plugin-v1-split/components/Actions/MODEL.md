# Actions Component — Model

**Path:** `src/Fortress.Console/Components/Actions/Model/`

## ActionContext

Execution context passed to every handler. Carries session state, loaded items, and collected errors.

```csharp
public class ActionContext
{
    public UserSession? Session { get; set; }
    public List<IItem> Items { get; } = new();
    public List<Exception> ExceptionErrors { get; } = new();
}
```

**Distinction:**

- `IItem` = domain entity the user manages
- `ActionContext` = per-iteration execution state for handlers

Handlers receive dependencies via **constructor injection**, not through `ActionContext`.

Item type definitions: `components/Data/MODEL.md`.