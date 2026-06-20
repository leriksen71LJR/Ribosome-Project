# AGENTS.md — Fortress

**This project follows a strict documentation-first approach.**

`.docs/` is the **single source of truth** for architecture, coding standards, component structure, and workflows.

**Start here:** This file (`AGENTS.md`) contains the critical rules you must follow.  
For architecture and component design, see the `.docs/` folder (start with `ARCHITECTURE.md` and `CODING_STANDARDS.md`).

---

## Critical Rules (Must Follow)

### 1. Implementation Order (Non-Negotiable)
Always build and refactor in this strict bottom-up order:

1. Contracts (interfaces)
2. Models
3. Infrastructure services
4. Security & Session services
5. Actions (handlers)
6. Bootstrapping
7. Tests

Never implement higher-level components before their dependencies exist.

### 2. Component Pattern
- All components must live under `src/Fortress.Console/Components/`
- Every component follows: `Contracts/` → `Implementations/` → `Model/`
- All dependency registration must go through `IDependencyModule` classes

### 3. Coding Standards
- Keep classes and methods **small and focused**
- Use **early returns** aggressively to minimize nesting
- One primary coordinator method per handler class: `ExecuteAsync()` (see Phase 1.1)
- Every handler `ExecuteAsync()` must begin with guard clauses before any other logic

### 4. Unit Testing
- Full unit test coverage is required for all components
- Tests live in `tests/Fortress.Console.Tests/`
- Use **xUnit + Moq**
- Follow the same Implementation Order when writing tests

### 5. Documentation
- Treat `.docs/` as **read-only** during implementation, **except**:
  - **`.docs/Builds/`** — agents **may** create and write build reports here (see Phase 1.1 requirements)
- Do not edit any other `.docs/` files (architecture, standards, design, phases, etc.) during a build
- Note any documentation improvements needed instead of editing source docs directly
- When in doubt, re-read `.docs/ARCHITECTURE.md`, `.docs/CODING_STANDARDS.md`, and `.docs/CODING_DESIGN.md`

### 6. Output Location Rule (Mandatory)
- All generated files **must** be written directly into the assigned project root folder.
- Writing to worktrees, temporary harness folders, or any location other than the designated project root is **strictly forbidden**.

### 7. Violation / Deviation Reporting (Mandatory)
- If you cannot follow any rule, you **must** explicitly report it in the build report.
- Do not silently work around rules. Report the violation, explain why it occurred, and what impact it had.

### 8. Deep Documentation Audit (Mandatory)
- At the end of every build, you **must** perform a Deep Documentation Audit.
- Use the guidance in `Evaluation/EvaluationCriteria.md`.
- Include the audit in the build report under a section titled **"Deep Documentation Audit"**.

### 9. Documentation Boundary Rule (Mandatory)
- You are **strictly forbidden** from reading or referencing any documents inside a `Research/` folder.
- `Research/` is human-only thinking space. All content you are allowed to use lives under `.docs/` (or the current project root as defined by the active prompt).

### 10. Conflict Resolution & Authority Hierarchy (Mandatory)
- `AGENTS.md` is the **highest authority** document in this project.
- When any other document (`.docs/ARCHITECTURE.md`, `.docs/CODING_DESIGN.md`, etc.) conflicts with `AGENTS.md`, **follow `AGENTS.md`** unless `AGENTS.md` explicitly defers to another document.
- If you encounter a contradiction between documents:
  1. Clearly identify both documents involved.
  2. State the specific conflicting statements.
  3. Declare which document you are treating as authoritative and why.
- Do **not** silently choose one interpretation. Make the conflict and your chosen resolution explicit in your reasoning file and build report.

### 11. Strict Following & Gap Reporting (Mandatory)
- When documentation is unclear, incomplete, ambiguous, or missing critical details, **you must flag the gap** rather than making silent assumptions.
- Prefer explicitly noting the ambiguity (in your reasoning file or build report) over filling in missing details yourself.
- "I assumed X because the documentation did not specify it" is acceptable **only** if you also explain:
  - Why the assumption was necessary to proceed, and
  - Why it is low-risk.
- High-risk or architectural assumptions must be called out prominently and justified.

### 12. Post-Build Build Disclosure (Mandatory)

Every build **must** end with a Build Disclosure — **after** the codebase and build report are complete.

| Rule | Detail |
|------|--------|
| **When** | Final step only — never before implementation begins |
| **Instructions** | Follow [BuildDisclosure.md](BuildDisclosure.md) in full |
| **Output** | `REASONING-YYYY-MM-DD-XXX.md` in the **project root** (same directory as `AGENTS.md`) |
| **Naming** | `XXX` = 3-digit daily sequence (`001`, `002`, …); must match paired `BUILD-REPORT-YYYY-MM-DD-XXX.md` — see `PHASE_1_1_IMPROVEMENTS.md` |
| **Completion** | A build is **not complete** until this file exists |
| **Handoff** | Return `REASONING-YYYY-MM-DD-XXX.md` to project stewards for documentation analysis — do not skip or substitute a chat summary |

The Build Disclosure is a **retrospective**: how the documentation performed as executable instructions during the build you just completed. Reference your actual implementation, deviations, and build report honestly.

Pre-build disclosure runs are **deprecated** for standard builds. Rule 12 governs.

**Optional craft layer:** [AgentGamification.md](AgentGamification.md) — light gamification for both implementation and Build Disclosure. Does not alter mandatory rules.

---

## How to Work

1. Read the relevant documentation in `.docs/` first.
2. Create a plan that respects the **Implementation Order**.
3. Implement bottom-up.
4. Write or update unit tests as part of the work.
5. Verify compliance with `.docs/CODING_STANDARDS.md`.
6. Write the build report to `.docs/Builds/` (Rule 8, Phase 1.1).
7. Complete the **Build Disclosure** per [BuildDisclosure.md](BuildDisclosure.md) (Rule 12) — the mandatory final step.

---

## Key Documents

| Document                        | Purpose                              | When to Read |
|--------------------------------|--------------------------------------|--------------|
| `AGENTS.md`                    | Critical rules and behavioral requirements | Always start here |
| `BuildDisclosure.md`           | Post-build disclosure protocol (Rule 12) | **End of every build — mandatory** |
| `AgentGamification.md`         | Optional craft layer (build + disclosure) | Anytime — optional positive framing |
| `.docs/ARCHITECTURE.md`        | System architecture & patterns       | When working on structure |
| `.docs/CODING_STANDARDS.md`    | Coding rules and quality standards   | Before writing code |
| `.docs/CODING_DESIGN.md`       | Detailed implementation guidance     | When implementing features |
| `.docs/ARCHITECTURE_SECURITY.md` | Security architecture              | When working on encryption or auth |
| `.docs/HANDLER_INVENTORY.md`   | Required action handlers (MVP)     | Before implementing any handler |

---

## Phase 1.1 Requirements (Mandatory)

Starting from Phase 1.1 onward, all agents **must** follow the rules defined in:

→ [.docs/Phases/PHASE_1_1_IMPROVEMENTS.md](.docs/Phases/PHASE_1_1_IMPROVEMENTS.md)

This includes:
- Producing a structured build report in `.docs/Builds/`
- Explicitly reporting any deviations from documented rules
- Using `ExecuteAsync` instead of `Execute` on `IActionHandler`
- Completing post-build Build Disclosure per [BuildDisclosure.md](BuildDisclosure.md) (Rule 12)

Failure to follow Phase 1.1 rules will be treated as a process violation.