# COMPONENT-PATTERN.md (Core)

**Purpose:** Define the mandatory Component Pattern used throughout the Fortress project.

## Core Rule
Outside of `Program.cs`, if it's code, it must be a Component.

## Component Structure
Every component must follow:
- `Contracts/` — Interfaces
- `Implementations/` — Work classes (usually stateless and injectable)
- `Model/` — Pure data classes and records

## Strict Rules
- No flat structures (no root-level `Handlers/`, `Services/`, etc.)
- Every handler must be registered exclusively via its Component's `IDependencyModule`
- `Program.cs` may only discover and invoke modules — no direct registrations

## Common Violations
- Placing handler classes outside `Components/Actions/Implementations/`
- Registering services directly in `Program.cs`
- Creating services with `new` inside handlers

*This pattern is considered foundational and relatively stable.*