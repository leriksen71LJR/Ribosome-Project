# AGENTS.md — Fortress Phase 2.1 (process)

**Documentation-first build.** Authoritative process rules for Phase 2.1.

**Start at phase root:** `AGENTS.md` (parent folder). Then follow read order below.

---

## Critical Rules

### 1. Implementation Order (Non-Negotiable)

Build bottom-up per `.documents/components/REGISTRY.md` plugin load order:

1. Data → 2. Infrastructure → 3. Security → 4. Logging → 5. Actions → 6. Bootstrapping → 7. Tests

### 2. Component Pattern

- All components under `src/Fortress.Console/Components/`
- Each component: `Contracts/`, `Implementations/`, `Model/`
- Exception: `Bootstrapping/Modules/` for `IDependencyModule` — `.documents/tensions/0001-modules-folder-exception.md`
- Registration **only** via `IDependencyModule`

### 3. Guard Clauses

Every handler `ExecuteAsync` begins with guard clauses (null context, cancellation, session).  
**Exception:** `ExitHandler` — `.documents/tensions/0002-exit-handler-vs-session-guard.md`

### 4. Unit Testing

- xUnit + Moq; tests under `tests/Fortress.Console.Tests/`
- Mirror `components/` structure under `tests/.../Components/`
- **Verifiable expectations:** `quality/TEST-EXPECTATIONS.md` — handler checklist, SQLCipher round-trip (or documented deviation)

### 5. Documentation Boundary (two-zone)

- Treat `.documents/` as **read-only** during build
- Writable: `Builds/` (reports) and `.codingAgent/` (proposals only — never authoritative)
- Do **not** read outside the assigned shootout package (`Archive/`, `Core/`, `Ideas/`, `Records/`, parent `Phases/` tree)
- Doc improvements: **Documentation Maintenance Proposals** table in build report and/or `.codingAgent/proposals/` — steward promotes into `.documents/`

### 6. Output Location

Write all code to the **assigned shootout project root** only. State absolute path to `AGENTS.md` in build report header.

### 7. Deviation Reporting

Report every rule violation in build report §4. No silent workarounds.

### 8. Deep Documentation Audit

Mandatory in combined build report. Rubric: `quality/EvaluationCriteria.md`. Include test checklist from `quality/TEST-EXPECTATIONS.md`.

### 9. Gap Reporting (Rule 11)

When documentation is unclear, incomplete, or ambiguous, **flag the gap** — do not fill silently.

- **Low-risk assumption:** note in Open Gaps with justification.
- **High-risk assumption** (encryption, save semantics, security UX, cross-component contracts): **prominent** in Invention Summary and Open Gaps.

Detail and I-codes: `quality/INVENTION-DISCLOSURE.md`.

### 10. Conflict Resolution & Authority (Rule 10)

`process/AGENTS.md` is **highest authority** unless this file explicitly defers (e.g., to handler inventory or an ADR).

On contradiction between documents:

1. Identify **both** documents and quote the conflicting statements.
2. State which is authoritative and why (AGENTS deference, inventory specificity, or ADR).
3. Document the resolution in build report §4 or §5.
4. Do **not** silently pick one interpretation.

### 11. Post-Build Build Disclosure (Rule 12)

- Final step only — one combined report per `process/BUILD-DISCLOSURE.md`
- Output: `Builds/BUILD-REPORT-YYYY-MM-DD-XXX-{Agent}.md`
- **Pre-build disclosure** (`REASONING-*.md`) is **deprecated** for standard builds — do not create

### 12. Design Repository Boundary

Do not implement in `fortress-design` or `Fortress/Export/`. Build only in assigned shootout root.

---

## Key Documents

| Document | Purpose |
|----------|---------|
| Phase `AGENTS.md` | Two-zone boundary + read order entry |
| `.documents/CORE.md` | Doc composition orchestration |
| `.documents/COMPONENTS.md` | Recipe + PLUGIN contract |
| `.documents/components/REGISTRY.md` | Load order + tension/strategy links |
| `.documents/components/*/PLUGIN.md` | Per-component build mRNA (six plugins) |
| `.documents/quality/TEST-EXPECTATIONS.md` | Verifiable test bar |
| `.documents/quality/INVENTION-DISCLOSURE.md` | Invention + assumption severity |
| `.documents/process/BUILD-DISCLOSURE.md` | Report spec + Maintenance Proposals |

Phase 1.1 rules: `process/PHASE_1_1.md`. Steward authoring: `quality/AUTHORING-GUIDANCE.md` (off-path).