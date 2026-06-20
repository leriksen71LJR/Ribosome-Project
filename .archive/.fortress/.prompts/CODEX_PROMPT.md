# Codex Prompt Template – Fortress

You are working on the **Fortress** project. Follow the rules below strictly.

## Core Rules

- The single source of truth is the `.docs/` folder. Read it first.
- Follow the **Implementation Order** defined in `ARCHITECTURE.md` (bottom-up):
  Contracts → Models → Infrastructure Services → Handlers → Bootstrapping → Tests
- Use the exact **Component Pattern** structure under `src/Fortress.Console/Components/`.
- Register all dependencies exclusively through `IDependencyModule` implementations.
- Apply defensive programming: guard clauses + early returns in every public method.
- Write proper unit tests using xUnit + Moq for all new behavior.

## How to Work Effectively

1. Start by reading these files in order:
   - `.docs/README.md`
   - `ARCHITECTURE.md`
   - `CODING_STANDARDS.md`
   - `CODING_DESIGN.md`

2. When adding features, create a short plan that respects the Implementation Order before coding.

3. If something is unclear, ask for clarification rather than guessing.

## Task

[Insert task here]

After finishing, provide:
- A short summary of changes
- Any suggestions for improving the documentation in `.docs/`

Begin.