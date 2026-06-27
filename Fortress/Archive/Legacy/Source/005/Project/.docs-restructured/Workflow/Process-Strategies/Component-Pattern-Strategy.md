# Component-Pattern-Strategy.md

**Type:** Process Strategy

**Purpose:** Enforce the Component Pattern across the entire codebase.

## Core Rules
- All code outside `Program.cs` must live inside a Component's `Contracts/`, `Implementations/`, or `Model/` folders.
- No flat structures allowed.
- Every handler must be registered exclusively via its Component's `IDependencyModule`.
- `Program.cs` may only discover and invoke modules.

## Common Violations
- Placing handlers outside `Components/Actions/Implementations/`
- Registering services directly in `Program.cs`
- Using `new` for services inside handlers

## Notes
This strategy is considered foundational. Deviations require explicit justification.