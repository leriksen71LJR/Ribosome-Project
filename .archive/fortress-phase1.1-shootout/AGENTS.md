# AGENTS.md — Fortress (Phase 1.1)

**This project follows a strict documentation-first approach.**

`.docs/` is the **single source of truth**.

**Start here:** [.docs/README.md](.docs/README.md)

---

## Critical Rules (Must Follow)

### 1. Read Phase 1.1 Improvements
You **must** read and follow `.docs/Phases/PHASE_1_1_IMPROVEMENTS.md` before starting any build.

### 2. Implementation Order (Non-Negotiable)
Always build and refactor in this strict bottom-up order:
1. Contracts (interfaces)
2. Models
3. Infrastructure services
4. Security & Session services
5. Actions (handlers)
6. Bootstrapping
7. Tests

### 3. Component Pattern
- All components must live under `src/Fortress.Console/Components/`
- Every component follows: `Contracts/` → `Implementations/` → `Model/`
- All dependency registration must go through `IDependencyModule` classes

### 4. Build Report Requirement (New in Phase 1.1)
At the end of your work you **must**:
- Create `.docs/Builds/` if it does not exist
- Write a structured report named `BUILD-YYYY-MM-DD-<YourName>.md`
- Include the required sections defined in `PHASE_1_1_IMPROVEMENTS.md`, especially **Deviations from Documentation**

### 5. Explicit Deviation Reporting (Mandatory)
If you cannot follow a documented rule, you must clearly document it in your build report. Silent deviations are not acceptable.

### 6. Async Requirement
`IActionHandler` methods must be `ExecuteAsync` (returning `Task<bool>`).

---

## Key Documents

| Document                              | Purpose                                      | When to Read                  |
|---------------------------------------|----------------------------------------------|-------------------------------|
| `.docs/README.md`                     | Main documentation index                     | Always start here             |
| `.docs/Phases/PHASE_1_1_IMPROVEMENTS.md` | Phase 1.1 rules & build report requirements | Before every build            |
| `.docs/ARCHITECTURE.md`               | System architecture & patterns               | When working on structure     |
| `.docs/CODING_STANDARDS.md`           | Coding rules and quality standards           | Before writing code           |
| `.docs/CODING_DESIGN.md`              | Detailed implementation guidance             | When implementing features    |