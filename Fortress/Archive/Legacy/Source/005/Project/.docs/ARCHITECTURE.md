# ARCHITECTURE.md

**Important Note on Rules**  
All behavioral, process, and enforcement rules for the build agent are defined in `AGENTS.md`.  
This includes rules such as:
- Output Location Rule
- Violation / Deviation Reporting
- Deep Documentation Audit requirement
- Documentation Boundary Rule

This document (`ARCHITECTURE.md`) focuses **only** on the technical architecture, component structure, and implementation patterns.

---

## System Overview

**Fortress** is a secure, console-based personal command center. The architecture is built around a simple, repeatable **Component Pattern** and heavy use of **Microsoft Dependency Injection**.

**Guiding Principle:**  
Outside of the console entry point (`Program.cs`), **if it's code, it's a Component**.

Each Component follows this consistent internal structure:

- **Contracts** — Interfaces that define behavior
- **Implementations** — Stateless work classes (injectable via DI)
- **Model** — Pure data classes and records (not injectable)

**Folder Structure (per AGENTS.md Rule 2):**  
All components **must** live under `src/Fortress.Console/Components/`.  
`Program.cs` is the only code file allowed outside `Components/`.

---

## Architectural Style

Fortress uses a **component-based architecture** with the **Strategy by List<T>** pattern as the primary mechanism for handling user interactions.

**Core Rules:**
1. The Strategy by List<T> pattern using `IActionHandler` **must** be used to process user interactions.
2. The same pattern should be applied **elsewhere in the system where it fits**.

---

## Implementation Order & Dependency Strategy (Mandatory)

**All implementation work must follow a strict bottom-up dependency order.**

The Architect Agent **must** enforce this order. Building components out of dependency sequence creates broken references, circular dependencies, and poor architecture.

### Required Build Order (from least to most dependent)

| Order | Layer                          | What to Build First                          | Examples |
|-------|--------------------------------|----------------------------------------------|----------|
| 1     | Contracts                      | Interfaces only                              | `IItem`, `IActionHandler`, `IStorageService`, `ISessionService` |
| 2     | Pure Models                    | Records and data classes                     | `TaskItem`, `NoteItem`, `CredentialItem`, `UserSession`, `ActionContext` |
| 3     | Infrastructure Implementations | Services with external dependencies only     | `SqliteStorageService`, `SystemConsole`, `ConsoleInputService` |
| 4     | Security & Session             | Core security and session management         | `EncryptionService`, `SessionManager`, `Argon2KeyDerivationService` |
| 5     | Shared / Domain Services       | Any reusable business logic services         | (Future) `TaskArchivalService`, etc. |
| 6     | Action Handlers                | All `IActionHandler` implementations         | All handlers in `HANDLER_INVENTORY.md` |
| 7     | Bootstrapping & Composition    | Modules and root composition                 | `ActionsModule`, `InfrastructureModule`, `Bootstrapper`, `Program.cs` |
| 8     | Tests                          | Unit tests for everything above              | All test files |

**Rules:**
- Never implement a handler before its required services and contracts exist.
- Never implement a service before its contracts and dependent models exist.
- The Architect Agent must reject any plan that violates this order.
- When regenerating or adding features, always verify the dependency chain before coding begins.

---

## Components

### 1. Actions Component (Core)

**Purpose:** Process all user interactions using the Strategy by List<T> pattern.

**Contracts:**
- `IActionHandler`
- `IItem`

**Implementations:**
- All handler classes defined in [HANDLER_INVENTORY.md](HANDLER_INVENTORY.md) (11 handlers for Phase 1.2A MVP)

**Model:**
- `ActionContext`
- `IItem` + concrete implementations (`TaskItem`, `NoteItem`, `CredentialItem`, `GoalItem`)

**Key Distinction:**
- `IItem` = Domain entity (the actual data the user manages)
- `ActionContext` = Execution context (carries current state and errors to handlers)

---

### 2. Data Component

**Purpose:** Define and manage all business data in a unified way.

**Contracts:**
- `IItem`

**Implementations:**
- None (data classes only)

**Model:**
- `TaskItem`
- `NoteItem`
- `CredentialItem`
- `GoalItem`
- Any future item types

**Note:** All data items implement `IItem` so they can be stored and processed uniformly in a single `List<IItem>`.

---

### 3. Security Component

**Purpose:** Protect user data through encryption and access control.

**Contracts:**
- `IEncryptionService`
- `ISessionService` (optional)

**Implementations:**
- `EncryptionService`
- `SessionManager`

**Model:**
- `UserSession`
- Encryption keys and related data structures

**Details:** See `ARCHITECTURE_SECURITY.md` for full specification.

---

### 4. Infrastructure Services Component

**Purpose:** Provide reusable infrastructure capabilities.

**Contracts:**
- `IStorageService`
- `IConsole`
- `IInputService`
- `IConfigurationService`

**Implementations:**
- `SqliteStorageService`
- `SystemConsole`
- `ConsoleInputService`
- `ConfigurationService`

**Model:**
- Configuration models
- Any supporting data structures

---

### 4.5. Logging Component

**Purpose:** Provide structured logging throughout the application using **Log4Net**.

**Contracts:**
- `ILoggingService`

**Implementations:**
- `Log4NetLoggingService` (wrapper around Log4Net)

**Model:**
- Log event properties
- Configuration (log4net.config)

**Note:** Log4Net is configured via XML (`log4net.config`) and initialized at application startup in the Bootstrapping Component.

---

### 5. Bootstrapping Component (Composition Root)

**Purpose:** Wire up the entire application at startup.

**Responsibilities:**
- Register all services and handlers in the DI container
- Load configuration
- Prompt for master password and unlock data
- Build the initial `ActionContext`
- Start the main action loop

**Note:** This is the only part of the system that sits outside the normal Component pattern.

---

## Strict Component Pattern Rules (Non-Negotiable)

- All code **outside** `Program.cs` **must** live strictly inside a Component's `Contracts/`, `Implementations/`, or `Model/` folders.
- No flat structures allowed (no root-level `Handlers/`, `Services/`, etc.).
- Every handler **must** be registered **exclusively** via its Component's `IDependencyModule`.
- `Program.cs` is allowed **only** to discover and invoke modules — **no direct registrations**.

**Common Violations to Avoid:**
- Placing handler classes outside `Components/Actions/Implementations/`
- Registering services directly in Program.cs
- Creating services with `new` inside handlers

---

## Dependency Registration Strategy

Fortress uses a lightweight, custom **module system** built on top of Microsoft Dependency Injection. This allows each Component to own its own service registration logic.

### IDependencyModule Interface

```csharp
public interface IDependencyModule
{
    void Register(IServiceCollection services);
}
```

### How It Works

1. Each major Component implements its own `IDependencyModule`.
2. The Bootstrapping Component (Composition Root) discovers and registers all modules.
3. This keeps registration logic close to the Component it belongs to.

**Example — Actions Module:**

```csharp
public class ActionsModule : IDependencyModule
{
    public void Register(IServiceCollection services)
    {
        // Register all 11 handlers — see HANDLER_INVENTORY.md for the complete list
        services.AddSingleton<IActionHandler, AddTaskHandler>();
        services.AddSingleton<IActionHandler, AddNoteHandler>();
        // ... (see HANDLER_INVENTORY.md ActionsModule section)
    }
}
```

**Example — Security Module:**

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

### Registration in Bootstrapping

```csharp
var services = new ServiceCollection();

var modules = new IDependencyModule[]
{
    new ActionsModule(),
    new SecurityModule(),
    new InfrastructureModule(),
    new DataModule()
};

foreach (var module in modules)
{
    module.Register(services);
}

var serviceProvider = services.BuildServiceProvider();
```

### Benefits

- Each Component owns its registration logic
- Easy to add, remove, or reorder Components
- Clean separation of concerns
- Still uses pure Microsoft Dependency Injection (no extra frameworks)
- Scales well as the system grows

---

## Technology Stack

| Area                   | Technology                                      |
|------------------------|-------------------------------------------------|
| Language               | C# (.NET 8+)                                    |
| Architecture           | Component-based + Strategy by List<T>           |
| Dependency Injection   | Microsoft.Extensions.DependencyInjection        |
| Data Storage           | SQLCipher (encrypted SQLite)                    |
| Encryption             | AES-256-GCM                                     |
| Key Derivation         | Argon2id                                        |
| Logging                | Log4Net                                         |

---

## Main Loop Flow (User Experience)

The application uses a **persistent numbered menu** that dynamically shows relevant options.

### Flow
1. Application starts and bootstraps
2. User is prompted for master password (if not already unlocked)
3. Main menu is built dynamically based on visible handlers
4. User selects a number from the menu
5. Corresponding `IActionHandler` is executed
6. Handler returns `true`/`false` and may add errors to `ActionContext`
7. Any errors are displayed to the user
8. Loop returns to step 3 (persistent menu)

### Visibility Rules
- Each `IActionHandler` decides internally whether it should appear in the menu.
- Some options only appear when relevant (e.g., "Archive Completed Tasks" only shows if completed tasks exist).
- This keeps the menu clean while still using the Strategy by List<T> pattern.

### Benefits
- Familiar console app experience (numbered menu)
- No manual menu renumbering
- Handlers control their own visibility
- Clean separation between UI and business logic

---

## Key Design Decisions

### ADR-001: Strategy by List<T> + IActionHandler
**Date:** May 2026  
**Decision:** Use `IActionHandler` with `Task<bool> ExecuteAsync(ActionContext context, CancellationToken cancellationToken = default)` for user interactions. Each handler also implements `bool IsVisible(ActionContext context)` for dynamic menu visibility.  
**Rationale:** Eliminates menu renumbering, improves extensibility and testability. Async execution supports I/O-bound handler work without blocking.  
**Status:** Accepted (updated Phase 1.1 — supersedes the original `Execute` returning `bool` decision; see `.docs/Phases/PHASE_1_1_IMPROVEMENTS.md` and `AGENTS.md` Rule 3)

### ADR-002: Microsoft Dependency Injection Only
**Date:** May 2026  
**Decision:** Use only Microsoft’s built-in DI container.  
**Rationale:** Simplicity and standard .NET approach.  
**Status:** Accepted

---

## Solution Layout

### Recommended Folder Structure (Component-Based)

```
Fortress/
├── .docs/                                      # All documentation (this folder)
├── src/
│   └── Fortress.Console/
│       ├── Program.cs                          # Entry point + main loop (Composition Root)
│       │
│       └── Components/                         # All components live here (AGENTS.md Rule 2)
│           │
│           ├── Actions/                        # Actions Component
│           │   ├── Contracts/
│           │   │   ├── IActionHandler.cs
│           │   │   └── IItem.cs
│           │   ├── Implementations/
│           │   │   ├── AddTaskHandler.cs
│           │   │   ├── ListItemsHandler.cs
│           │   │   ├── ArchiveCompletedHandler.cs
│           │   │   └── ... (all handlers)
│           │   └── Model/
│           │       ├── ActionContext.cs
│           │       ├── TaskItem.cs
│           │       ├── NoteItem.cs
│           │       ├── CredentialItem.cs
│           │       └── GoalItem.cs
│           │
│           ├── Data/                           # Data Component
│           │   ├── Contracts/
│           │   │   └── IItem.cs                # (shared with Actions)
│           │   └── Model/                      # (item models may live here or under Actions)
│           │
│           ├── Security/                       # Security Component
│           │   ├── Contracts/
│           │   │   ├── IEncryptionService.cs
│           │   │   ├── ISessionService.cs
│           │   │   └── IKeyDerivationService.cs
│           │   ├── Implementations/
│           │   │   ├── EncryptionService.cs
│           │   │   ├── SessionManager.cs
│           │   │   └── Argon2KeyDerivationService.cs
│           │   └── Model/
│           │       └── UserSession.cs
│           │
│           ├── Infrastructure/                 # Infrastructure Services Component
│           │   ├── Contracts/
│           │   │   ├── IStorageService.cs
│           │   │   ├── IConsole.cs
│           │   │   ├── IInputService.cs
│           │   │   └── IConfigurationService.cs
│           │   └── Implementations/
│           │       ├── SqliteStorageService.cs
│           │       ├── SystemConsole.cs
│           │       ├── ConsoleInputService.cs
│           │       └── ConfigurationService.cs
│           │
│           ├── Logging/                        # Logging Component
│           │   ├── Contracts/
│           │   │   └── ILoggingService.cs
│           │   └── Implementations/
│           │       └── Log4NetLoggingService.cs
│           │
│           ├── Bootstrapping/                  # Bootstrapping Component
│           │   └── Modules/
│           │       ├── ActionsModule.cs
│           │       ├── SecurityModule.cs
│           │       ├── InfrastructureModule.cs
│           │       ├── LoggingModule.cs
│           │       └── DataModule.cs
│           │
│           └── Common/                         # Shared utilities, constants, exceptions
│
└── tests/
    └── Fortress.Console.Tests/
        └── Components/                         # Mirror src component structure
            ├── Actions/
            ├── Security/
            └── ...
```

### Important Rules

- Every major **Component** lives under `src/Fortress.Console/Components/` in its own folder.
- Inside each Component: `Contracts/` → `Implementations/` → `Model/`.
- `IDependencyModule` implementations live in `Components/Bootstrapping/Modules/`.
- `Program.cs` is the only file allowed outside `Components/` (it is the Composition Root).
- All other code must follow the Component Pattern.
---

**This document defines the technical foundation of Fortress. All implementation must align with the component structure and principles described here.**