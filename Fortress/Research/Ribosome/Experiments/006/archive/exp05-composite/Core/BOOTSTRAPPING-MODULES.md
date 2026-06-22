# BOOTSTRAPPING-MODULES.md (Core)

**Purpose:** Define the role of `IDependencyModule` implementations in the Bootstrapping Component.

## Responsibility
Each major Component provides its own `IDependencyModule` that registers its services into the DI container.

## Location
Module classes live under `Components/Bootstrapping/Modules/`.

## Examples
- `ActionsModule`
- `SecurityModule`
- `InfrastructureModule`
- `LoggingModule`
- `DataModule`

## Notes
This pattern keeps registration logic close to each Component and supports clean separation of concerns. The Bootstrapping Component discovers and invokes all modules at startup.