# Build Prompt — Fortress Phase 2.1

You are a build agent for **Fortress** — a secure .NET 8 console application.

Your objective is to **implement a working MVP** from the Phase 2.1 documentation package with full process compliance: correct architecture, all required handlers, encrypted storage, unit tests, and a **combined build report** per `.documents/process/BUILD-DISCLOSURE.md`.

---

## Assigned Project Root (Mandatory — read first)

**Build only in the assigned shootout folder** — not in `fortress-design`, not in the export mirror parent, not in any IDE workspace root that differs from this path.

**Assigned root for this session (replace if your orchestrator specifies otherwise):**

```
C:\Users\lerik\source\repos\fortress-shootout\Claude
```

**Phase 2.1 shootout paths (use only the one assigned to you):**

| Agent | Assigned project root |
|-------|------------------------|
| Claude | `C:\Users\lerik\source\repos\fortress-shootout\Claude` |
| Grok Build | `C:\Users\lerik\source\repos\fortress-shootout\Grok` |
| Codex | `C:\Users\lerik\source\repos\fortress-shootout\Cortex` |

The **project root** is the assigned directory containing `AGENTS.md`.

### Pre-flight check (required before any code)

1. Resolve the **absolute path** to `AGENTS.md`.
2. Confirm it is **inside** your assigned root (not `fortress-design`).
3. Record that path in the build report header. If it does not match, **stop** — build is **blocked**.

All code, tests, and reports **must** stay inside the assigned root.

Do **not** read outside this package (`Archive/`, `Core/`, `Ideas/`, `Records/`, or parent `Phases/` trees).

---

## Mandatory Reading Order (before writing code)

Read **in order** per `AGENTS.md`:

1. `AGENTS.md` (project root)
2. `.documents/CORE.md`
3. `.documents/COMPONENTS.md`
4. `.documents/components/REGISTRY.md`
5. Six `PLUGIN.md` files in registry order (Data → Infrastructure → Security → Logging → Actions → Bootstrapping)
6. Relevant `.documents/tensions/` or `.documents/strategies/` when triggered
7. `.documents/quality/TEST-EXPECTATIONS.md` before tests
8. `.documents/process/BUILD-DISCLOSURE.md` before writing the report

Do not read `Builds/` (prior reports) unless explicitly instructed.

---

## Build Rules (Non-Negotiable)

### Two-zone boundary

| Zone | Access |
|------|--------|
| `.documents/` | Read-only |
| `.codingAgent/` | Writable proposals only (non-authoritative) |
| `Builds/` | Writable — combined build reports |

### Implementation order

Bottom-up per `REGISTRY.md`:

Data → Infrastructure → Security → Logging → Actions → Bootstrapping → Tests

### Architecture

- Components under `src/Fortress.Console/Components/`
- Structure: `Contracts/` → `Implementations/` → `Model/` (Bootstrapping `Modules/` exception — tension 0001)
- DI via `IDependencyModule` only; `Program.cs` is the sole composition root outside `Components/`

### Documentation during build

- Follow PLUGIN pseudocode; cite tensions when behavior is resolved there
- Gap-report open tensions (0007–0009) — do not silently invent high-risk behavior
- Rules 10 & 11: report conflicts and assumptions explicitly

---

## Deliverables (all required)

### 1. Working codebase

- .NET 8 solution: `src/Fortress.Console/` + `tests/Fortress.Console.Tests/`
- Solution builds; tests pass per `TEST-EXPECTATIONS.md`

### 2. Combined build report (one file)

Create **exactly one file:** `Builds/BUILD-REPORT-YYYY-MM-DD-XXX-{Agent}.md`

Follow `.documents/process/BUILD-DISCLOSURE.md` in full.

**Do not** create `REASONING-*.md` or a second report file.

Include the **Documentation Maintenance Proposals** table if you recommend doc changes.

---

## Completion Criteria

- [ ] Solution compiles
- [ ] Tests pass
- [ ] Handlers and security per PLUGIN specs (or deviations reported)
- [ ] One combined report per BUILD-DISCLOSURE
- [ ] Assigned project root recorded in report header

After the report is complete, **stop**.

---

## If You Cannot Proceed

1. State the gap clearly
2. Low-risk assumptions only — justify per Rule 11
3. High-risk assumptions → deviations + invention disclosure
4. Continue with what is documented

Begin.