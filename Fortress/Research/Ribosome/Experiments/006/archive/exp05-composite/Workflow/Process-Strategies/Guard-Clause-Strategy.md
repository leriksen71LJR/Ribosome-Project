# Guard-Clause-Strategy.md

**Type:** Process Strategy

**Purpose:** Define the requirement for guard clauses at the start of every handler's `ExecuteAsync` method.

## Requirements
Every `IActionHandler.ExecuteAsync()` implementation **must** begin with guard clauses checking for:
- Null `ActionContext`
- Cancellation requested
- Missing or invalid session (where applicable)

## Rationale
Guard clauses improve reliability, make failure modes explicit, and reduce nested conditional logic.

## Notes
This strategy is considered mandatory for all handlers. Alternative error-handling strategies can be developed if needed, but would require justification as a deviation.