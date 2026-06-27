# Build Prompt — Fortress Phase 1.2A

You are a build agent for **Fortress** — a secure .NET 8 console application.

Your objective is to **implement a working MVP** from the project documentation with full process compliance: correct architecture, all required handlers, encrypted storage, unit tests, and a **combined build report** (Part 1 build report + Part 2 Build Disclosure in one file — `AGENTS.md` Rule 12, `BuildDisclosure.md`).

---

## Assigned Project Root (Mandatory — read first)

**You must build only in the assigned shootout folder below** — not in `fortress-design`, not in `Fortress/Export/`, not in any IDE workspace root that differs from this path.

**Assigned root for this session (replace if your orchestrator specifies otherwise):**

```
C:\Users\lerik\source\repos\fortress-shootout\Claude
```

**Phase 1.2A shootout paths (use only the one assigned to you):**

| Agent | Assigned project root |
|-------|------------------------|
| Claude | `C:\Users\lerik\source\repos\fortress-shootout\Claude` |
| Grok Build | `C:\Users\lerik\source\repos\fortress-shootout\Grok` |
| Codex | `C:\Users\lerik\source\repos\fortress-shootout\Cortex` |

The **project root** is the assigned directory above. It must be the directory containing `AGENTS.md` for this build.

### Pre-flight check (required before any code)

1. Resolve the **absolute path** to `AGENTS.md`.
2. Confirm it is **inside** your assigned root (not `fortress-design`, not `Fortress/Export/`).
3. Record that path in the build report header. If it does not match, **stop** — build is **blocked** per `AGENTS.md` Rule 13.

All generated code, tests, and reports **must** be written inside the assigned root only.  
Do **not** write to worktrees, temp folders, parent repos, or export mirrors.

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

### 2. Build report (one file — mandatory)

Follow **`BuildDisclosure.md` in full** — the single specification for the combined report.

Create **exactly one file:** `.docs/Builds/BUILD-REPORT-YYYY-MM-DD-XXX-{Agent}.md`

- `YYYY-MM-DD` — today's date
- `XXX` — 3-digit daily sequence (`001`, `002`, …)
- `{Agent}` — your agent slug (no spaces, e.g. `Claude`, `GrokBuild`)

**Do not** create a second file. **Do not** create `REASONING-*.md`.

`BuildDisclosure.md` defines: report header, all 7 build-report sections (including deviations and Deep Documentation Audit), all Build Disclosure sections, Self-Assessment, and the completion checklist.

Return this one file to project stewards.

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
10. Write the combined report per `BuildDisclosure.md` (`AGENTS.md` Rules 8 & 12)

---

## Completion Criteria

The build is **complete** only when:

- [ ] Solution compiles
- [ ] Tests pass
- [ ] All 11 handlers implemented (or explicitly deferred with deviation report)
- [ ] SQLCipher + Argon2id used per security spec
- [ ] Combined report complete per `BuildDisclosure.md` completion checklist (one file; no `REASONING-*.md`)

After the report is complete, **stop**. Do not begin unrelated work.

---

## If You Cannot Proceed

If a documentation gap blocks implementation:

1. State the gap clearly
2. Make only **low-risk** assumptions (justify per Rule 11)
3. Report high-risk assumptions as deviations
4. Continue with what is documented — do not redesign the architecture

Begin.