# Data Component - Build Plugin

**Plugin ID:** `components/Data`
**Depends on:** none (build first)
**Tension refs:** none
**Status:** Phase 2.1 MVP

---

## Model

**Path:** `src/Fortress.Console/Components/Data/Model/` (item classes may also live under Actions/Model per existing builds — follow assigned export layout)

### IItem

```csharp
public interface IItem
{
    Guid Id { get; }
    string Title { get; set; }
    DateTime CreatedAt { get; }
    DateTime? UpdatedAt { get; set; }
}
```

## Concrete types (Phase 1.2A)

- `TaskItem` — `IsCompleted`, `DueDate`, `Priority`, `Tags`
- `NoteItem` — `Content`
- `CredentialItem` — `Username`, `Password`, `Url`, `Notes`
- `GoalItem` — `Description`, `TargetDate`, `Progress`

All implement `IItem` for unified `List<IItem>` storage and handler processing.

Database mapping: `Infrastructure plugin`.

---
