# Registration-Strategy.md

**Type:** Process Strategy

**Purpose:** Define how handlers and services should be registered in the DI container.

## Recommended Approach
- Each Component should register its own services via its `IDependencyModule`.
- Handlers should be registered as `AddSingleton<IActionHandler, THandler>()`.
- Registration logic should stay close to the Component it belongs to.

## Notes
This strategy supports the Component Pattern and clean separation of concerns. Alternative registration approaches can be developed as separate strategies if needed.