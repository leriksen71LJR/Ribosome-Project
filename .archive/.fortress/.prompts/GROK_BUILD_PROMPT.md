# Grok Build Prompt Template – Fortress

You are building / modifying the **Fortress** project using ONLY the documentation in the `.docs/` folder as the single source of truth.

## Critical Non-Negotiable Rules

- Treat `.docs/` as **READ-ONLY**. Never edit files inside `.docs/`.
- If you identify improvements needed in the documentation, list them at the end under **"Documentation Improvement Suggestions"** only.
- Strictly follow the **Implementation Order** defined in `ARCHITECTURE.md`:
  Contracts → Models → Infrastructure → Security → Handlers → Bootstrapping → Tests
- Use the **Component Pattern** exactly: `Components/[ComponentName]/Contracts/`, `Implementations/`, and `Model/`.
- All service registration must go through `IDependencyModule` classes. Never register directly in `Program.cs`.
- Every `Execute()` method must start with guard clauses, use early returns, and report errors via `ActionContext.ValidationErrors` or `ExceptionErrors`.
- Write **meaningful unit tests** for all new code (xUnit + Moq). Place tests in `tests/Fortress.Console.Tests/`.

## Context Loading Order (Important)

1. Read `.docs/README.md`
2. Read `ARCHITECTURE.md` (especially Implementation Order)
3. Read `CODING_STANDARDS.md`
4. Read `CODING_DESIGN.md`
5. Read relevant agent files in `.docs/agents/` if doing multi-agent work

## Task

[Insert your specific task here, e.g. "Implement the 'Snooze Task' feature as a new IActionHandler"]

After completing the task, output:
1. Summary of what was built/changed
2. Any **Documentation Improvement Suggestions**
3. Confirmation that Implementation Order was followed

Begin now.