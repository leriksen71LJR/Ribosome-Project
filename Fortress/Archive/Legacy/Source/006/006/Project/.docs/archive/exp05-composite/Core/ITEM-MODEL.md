# ITEM-MODEL.md (Core)

**Purpose:** Define the base `IItem` interface and the concrete item types used in Phase 1.2A.

## Base Interface

```csharp
public interface IItem
{
    Guid Id { get; }
    string Title { get; set; }
    DateTime CreatedAt { get; }
    DateTime? UpdatedAt { get; set; }
}
```

## Concrete Types (Phase 1.2A)
- `TaskItem`
- `NoteItem`
- `CredentialItem`
- `GoalItem`

All concrete item types implement `IItem` so they can be stored and processed uniformly in a single `List<IItem>`.

## Notes
This model supports unified handling of different data types while allowing type-specific behavior where needed.