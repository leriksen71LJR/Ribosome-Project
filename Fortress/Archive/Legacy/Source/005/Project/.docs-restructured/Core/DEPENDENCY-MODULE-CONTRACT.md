# DEPENDENCY-MODULE-CONTRACT.md (Core)

**Purpose:** Define the `IDependencyModule` interface used for component-based service registration.

```csharp
public interface IDependencyModule
{
    void Register(IServiceCollection services);
}
```

## Purpose of This Pattern
Each major Component owns its own service registration logic through its own `IDependencyModule` implementation. This keeps registration close to the Component it belongs to and supports clean separation of concerns.

## Notes
- Bootstrapping discovers and invokes all modules.
- This approach uses pure Microsoft Dependency Injection with no additional frameworks.
- The pattern supports scalability as the system grows.

*This contract is considered stable.*