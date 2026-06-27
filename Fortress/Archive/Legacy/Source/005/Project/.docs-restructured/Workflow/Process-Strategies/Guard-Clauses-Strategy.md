# Guard-Clauses-Strategy.md

**Type:** Process Strategy

**Purpose:** Reinforce the requirement for guard clauses at the beginning of every handler's execution method.

## Requirements
Every `ExecuteAsync` implementation must start with checks for:
- Null or invalid `ActionContext`
- Cancellation requested
- Missing or invalid user session (where applicable)

## Rationale
Guard clauses improve reliability, make failure modes explicit early, and reduce deep nesting of conditionals.

## Notes
This strategy is considered mandatory. It supports defensive programming and clearer code. Alternative error handling strategies can be developed if needed.