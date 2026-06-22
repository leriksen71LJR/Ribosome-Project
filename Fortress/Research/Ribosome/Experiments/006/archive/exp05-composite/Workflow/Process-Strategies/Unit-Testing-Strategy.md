# Unit-Testing-Strategy.md

**Type:** Process Strategy

**Purpose:** Define the unit testing requirements for the project.

## Requirements
- Full unit test coverage is required for all components.
- Tests must live in `tests/Fortress.Console.Tests/` and mirror the source component structure.
- Use xUnit + Moq.
- Follow the same Implementation Order when writing tests (Contracts → Models → Services → Handlers → etc.).

## Notes
Testing is considered a core part of implementation, not an optional step. This strategy supports quality and maintainability.