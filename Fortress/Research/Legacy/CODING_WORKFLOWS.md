# CODING_WORKFLOWS.md

**Practical Development Workflows for Fortress**

This document provides clear, repeatable workflows for common tasks when developing Fortress. It ensures consistency across the team and helps both humans and AI agents work efficiently.

All workflows follow the **Component Pattern** (Contracts → Implementations → Model) and use `IDependencyModule` for registration.

**Important:** Always follow the **Implementation Order** defined in `ARCHITECTURE.md` (bottom-up: Contracts → Models → Infrastructure → Handlers → Bootstrapping → Tests).

---

## 0. Adding a New Feature (End-to-End Workflow)

This is the recommended high-level process for adding any significant new capability to Fortress.

### Recommended Steps

1. **Update Documentation First**
   - Identify which documents need to change (`ARCHITECTURE.md`, `CODING_DESIGN.md`, `CODING_STANDARDS.md`, etc.).
   - Clearly describe the new feature, its responsibilities, and any new contracts or models.
   - Update the relevant agent instructions if the workflow changes.

2. **Create a Plan (Architect Agent)**
   - Break the feature down into the correct **Implementation Order**.
   - Identify all new contracts, models, services, and handlers required.
   - Define what needs to be unit tested.

3. **Implement Bottom-Up**
   - Start with contracts and models.
   - Then implement infrastructure services.
   - Then implement handlers.
   - Finally update bootstrapping / composition root.

4. **Write Unit Tests**
   - Create tests alongside implementation (or immediately after).
   - Follow the patterns in `tests/Fortress.Console.Tests/`.
   - Use xUnit + Moq.
   - Test both happy paths and error cases via `ActionContext`.

5. **Review**
   - Run the Reviewer Agent against `CODING_STANDARDS.md` and `ARCHITECTURE.md`.
   - Verify Implementation Order was respected.
   - Check for proper defensive programming and granularity.

6. **Regenerate if Needed**
   - If significant issues are found, improve the documentation first, then regenerate the affected components.
   - Then implement infrastructure services.
   - Then implement handlers and other logic.
   - Register everything via the appropriate `IDependencyModule`.

4. **Write Unit Tests**
   - The Tester Agent should generate tests following the same dependency order.
   - Focus on behavior, edge cases, and defensive programming.

5. **Review Against Standards**
   - The Reviewer Agent checks for adherence to `CODING_STANDARDS.md`, `ARCHITECTURE.md`, and the Component Pattern.
   - Verify that the code is granular, uses early returns, and follows coordinator patterns.

6. **Regenerate if Needed**
   - If significant issues are found during review, improve the documentation first, then regenerate the affected parts.

**Rule:** Never start coding a handler or complex service before its required contracts and supporting services are defined and stable.

---

## 1. Adding a New Action (IActionHandler)

This is the most common workflow.

### Steps

1. **Create the Handler Class**
   - Location: `src/Fortress.Console/Actions/Implementations/`
   - Name it descriptively: `AddTaskHandler`, `ArchiveCompletedHandler`, etc.

2. **Implement `IActionHandler`**

```csharp
public class AddTaskHandler : IActionHandler
{
    private readonly IConsole _console;
    private readonly IStorageService _storage;

    public AddTaskHandler(IConsole console, IStorageService storage)
    {
        _console = console;
        _storage = storage;
    }

    public string Name => "Add Task";
    public string Description => "Create a new task";

    public bool Execute(ActionContext context)
    {
        // Defensive validation
        if (context.Session == null || !context.Session.IsUnlocked)
        {
            context.ValidationErrors.Add("You must be logged in to add a task.");
            return false;
        }

        // ... implementation ...

        return true;
    }
}
```

3. **Register the Handler in the Module**

   Add it to `ActionsModule.cs`:

```csharp
public void Register(IServiceCollection services)
{
    services.AddSingleton<IActionHandler, AddTaskHandler>();
    // ... other handlers
}
```

4. **Test the Handler**
   - Unit test in isolation using a mock `ActionContext`
   - Verify it returns `true`/`false` correctly and populates error lists

---

## 2. Creating a New Module (IDependencyModule)

Use this when you need to register multiple related services/handlers.

### Steps

1. **Create the Module Class**
   - Location: `src/Fortress.Console/Bootstrapping/Modules/`

```csharp
public class SecurityModule : IDependencyModule
{
    public void Register(IServiceCollection services)
    {
        services.AddSingleton<IEncryptionService, EncryptionService>();
        services.AddSingleton<ISessionService, SessionManager>();
    }
}
```

2. **Register the Module in Bootstrapping**

   In `Program.cs` or `CompositionRoot.cs`:

```csharp
var modules = new IDependencyModule[]
{
    new ActionsModule(),
    new SecurityModule(),
    new InfrastructureModule()
};

foreach (var module in modules)
{
    module.Register(services);
}
```

---

## 3. Making Database Changes (SQLCipher)

### Steps

1. **Create a Migration Script**
   - Location: `src/Fortress.Console/Infrastructure/Migrations/`
   - Name format: `001_InitialSchema.sql`, `002_AddTaskTags.sql`

2. **Run Migration on Startup**
   - Use a `DatabaseMigrator` service that runs pending migrations when the app starts.

3. **Update the Data Model**
   - Add properties to the relevant Model class (e.g., `TaskItem`)
   - Implement the change in the `IStorageService` implementation

4. **Update Tests**
   - Ensure unit tests still pass with the new schema

---

## 4. Adding a New Service

### Steps

1. **Define the Contract (Interface)**
   - Location: `src/Fortress.Console/Actions/Contracts/` (or shared `Contracts/` folder)

2. **Create the Implementation**
   - Location: `src/Fortress.Console/Infrastructure/Implementations/`
   - Keep it stateless and injectable

3. **Register in the Appropriate Module**

```csharp
public void Register(IServiceCollection services)
{
    services.AddSingleton<INewService, NewService>();
}
```

4. **Inject and Use**
   - Inject via constructor in any handler or service that needs it

---

## 5. Updating Documentation After Changes

### Rule
**If you change behavior, architecture, or add new features — update the documentation.**

### Checklist

- [ ] Update `ARCHITECTURE.md` if a new component or pattern is introduced
- [ ] Update `ARCHITECTURE_DECISIONS.md` if a significant architectural decision was made
- [ ] Update `CODING_WORKFLOWS.md` if a new common workflow emerges
- [ ] Update core documents in `.docs/` only if a fundamental principle or pattern changes (rare)

---

## Best Practices

- Always follow the **Component Pattern** (Contracts → Implementations → Model)
- Use `IDependencyModule` for all registration logic
- Validate early in every `IActionHandler.Execute()` method
- Return `false` + populate error lists instead of throwing exceptions
- Keep handlers focused — one handler = one user-facing action

---

*This document should be kept up to date. Outdated workflows create inconsistency.*

---

## Using AI Coding Tools (Grok Build, Claude, Codex)

### Recommended Approach

- Use the prompt templates in the `.prompts/` folder as a starting point.
- Always load context in this order:
  1. `.docs/README.md`
  2. `ARCHITECTURE.md`
  3. `CODING_STANDARDS.md`
  4. `CODING_DESIGN.md`

### Tool-Specific Notes

- **Codex**: Use `AGENTS.md` (root) as the primary instruction file.
- **Claude**: Use `.claude/CLAUDE.md` (it contains the critical rules summary).
- **Grok Build**: Use the dedicated prompt template in `.prompts/GROK_BUILD_PROMPT.md`.

### Context Management Tip

For best results, explicitly tell the tool:
> "Read `.docs/README.md` first, then follow the rules in `ARCHITECTURE.md` and `CODING_STANDARDS.md`."

This dramatically improves consistency across different AI tools.
