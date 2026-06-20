# Build Prompt — Fortress Phase 1.2A

You are a build agent for **Fortress** — a secure .NET 8 console application.

Your objective is to **implement a working MVP** from the project documentation with full process compliance: correct architecture, all required handlers, encrypted storage, unit tests, a complete build report, and a **post-build Build Disclosure** (`AGENTS.md` Rule 12, `BuildDisclosure.md`).

---

## Project Root

The **project root** is the directory containing `AGENTS.md`.

All generated code, tests, and reports **must** be written inside this directory.  
Do **not** write to worktrees, temp folders, or paths outside the project root.

You are **forbidden** from reading anything in a `Research/` folder.

---

## Mandatory Reading Order (before writing code)

Read these documents **in order**:

1. `AGENTS.md`
2. `README.md`
3. `.docs/ARCHITECTURE.md`
4. `.docs/CODING_STANDARDS.md`
5. `.docs/CODING_DESIGN.md`
6. `.docs/ARCHITECTURE_SECURITY.md` — **Implementation Specification (Phase 1.2A)** section
7. `.docs/HANDLER_INVENTORY.md`
8. `.docs/Phases/PHASE_1_1_IMPROVEMENTS.md`
9. `Evaluation/EvaluationCriteria.md`

Do not read `.docs/Builds/` (prior reports) unless explicitly instructed.

---

## Build Rules (Non-Negotiable)

### Implementation Order

Build bottom-up per `AGENTS.md` Rule 1:

1. Contracts → 2. Models → 3. Infrastructure → 4. Security → 5. Handlers → 6. Bootstrapping → 7. Tests

### Architecture

- All components under `src/Fortress.Console/Components/`
- Component structure: `Contracts/` → `Implementations/` → `Model/`
- DI registration **only** via `IDependencyModule` in `Components/Bootstrapping/Modules/`
- `Program.cs` is the only file outside `Components/`

### Handlers

- Implement **all 11 handlers** in `.docs/HANDLER_INVENTORY.md`
- Use `ExecuteAsync` with guard clauses on every handler
- Do not hardcode menu numbers in handler `Name` properties

### Security

- SQLCipher + Argon2id per `ARCHITECTURE_SECURITY.md` Implementation Specification
- Never store the master password
- Wrong password must **not** silently create a new database

### Documentation During Build

- Treat `.docs/` as read-only **except** `.docs/Builds/` (build reports only)
- Do not edit architecture or standards documents during the build

### Rules 10 & 11

- When documents conflict, follow `AGENTS.md` and report the conflict
- Flag gaps and assumptions — do not silently invent high-risk behavior

### Optional craft layer

- `AgentGamification.md` — optional Pride Points and Cartographer framing for **build** and **Build Disclosure** (does not change mandatory deliverables)

---

## Deliverables (all required)

### 1. Working codebase

- .NET 8 solution: `src/Fortress.Console/` + `tests/Fortress.Console.Tests/`
- All components, handlers, security, storage, bootstrapping
- Solution builds and tests pass

### 2. Build report

Write `.docs/Builds/BUILD-REPORT-YYYY-MM-DD-XXX.md` with all sections required by `PHASE_1_1_IMPROVEMENTS.md` (see **Report Naming** — `XXX` = daily sequence):

- Summary of Work Completed
- Files Created / Modified
- Key Implementation Decisions
- Deviations from Documentation
- **Deep Documentation Audit** (per `Evaluation/EvaluationCriteria.md`)
- Open Gaps and Assumptions
- Recommended Next Steps

### 3. Build Disclosure (final step)

After the build report is written, follow `BuildDisclosure.md` and produce:

- `REASONING-YYYY-MM-DD-XXX.md` in the **project root** (same `XXX` as the build report)

This file is returned to project stewards for documentation analysis. **Do not skip it.**

---

## Suggested Build Sequence

1. Create solution and project structure matching `ARCHITECTURE.md` Solution Layout
2. Implement contracts and models (all components)
3. Implement Infrastructure + Logging
4. Implement Security (`Argon2KeyDerivationService`, `EncryptionService`, `SessionManager`)
5. Implement `SqliteStorageService` with schema from `CODING_DESIGN.md`
6. Implement all 11 handlers from `HANDLER_INVENTORY.md`
7. Wire `Program.cs`: `Batteries_V2.Init()`, modules, unlock flow, main menu loop
8. Write unit tests mirroring `tests/.../Components/` structure
9. Verify build + tests pass
10. Write build report with honest Deep Documentation Audit
11. Complete **Build Disclosure** per `BuildDisclosure.md` (`AGENTS.md` Rule 12)

---

## Completion Criteria

The build is **complete** only when:

- [ ] Solution compiles
- [ ] Tests pass
- [ ] All 11 handlers implemented (or explicitly deferred with deviation report)
- [ ] SQLCipher + Argon2id used per security spec
- [ ] `BUILD-REPORT-YYYY-MM-DD-XXX.md` exists with Deep Documentation Audit
- [ ] All deviations explicitly listed (or stated as `None`)
- [ ] `REASONING-YYYY-MM-DD-XXX.md` exists in the project root (post-build retrospective; same `XXX`)

After `REASONING-YYYY-MM-DD-XXX.md` is written per `BuildDisclosure.md`, **stop**. Do not begin unrelated work.

---

## If You Cannot Proceed

If a documentation gap blocks implementation:

1. State the gap clearly
2. Make only **low-risk** assumptions (justify per Rule 11)
3. Report high-risk assumptions as deviations
4. Continue with what is documented — do not redesign the architecture

Begin.