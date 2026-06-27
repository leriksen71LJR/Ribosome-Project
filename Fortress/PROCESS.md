# Fortress Operating Process

This document defines **how** we work in Fortress. It is the authoritative description of the workflow, session structure, and quality gates.

The goal is to make the process repeatable and largely independent of chat memory.

---

## Charter (Why Fortress Exists)

Fortress is a **research and training project**. The Fortress console application is a vehicle, not the top prize.

**Primary charter:** Train the **Director** (Mr. Bear) in **AI agent coding** — how to brief agents, read their reasoning, judge documentation quality, run shootouts, and curate what they produce.

Secondary outcomes (documentation discipline, Ribosome experiments, working MVP) serve that charter. When structure helps learning, we use it. When structure would slow exploration, we loosen it — deliberately.

**Division of labor:**

| Role | Owns |
|------|------|
| **Director (Mr. Bear)** | Intent, priorities, when to explore vs when to ship, final calls |
| **Research** | Contemplative design, experiments, long-horizon thinking |
| **Steward (Grok)** | Code and folder organization, process capture, export hygiene — offered as a service, not a gate |

Research and the Director are not expected to match steward-level folder discipline. The steward keeps the repo **legible enough to resume** without forcing every idea through a rigid pipeline.

---

## Core Philosophy

We treat **documentation as executable pseudocode** for AI agents.

The quality of the output is primarily determined by the quality and clarity of the documentation, not by the intelligence of the agent. Therefore, we invest heavily in:

- Making reasoning visible before code is written (Reasoning Disclosure)
- Explicit conflict resolution and gap reporting (Rules 10 and 11)
- Maintaining living documentation that reduces the need for chat context

---

## Project Structure and Boundaries

`Fortress/` (the root) and `Fortress/Projects/` serve different purposes and must be kept clearly separated.

### Fortress/ (Root)
This is the **overall project container**. It holds:

- High-level process and management documentation (`PROCESS.md`, `STATUS.md`, `HANDOFF.md`)
- Research, ideas, analysis, and long-term thinking (`Research/`)
- Export packages and prompts used for agent testing (`Export/`)
- Any human-only coordination or meta-documentation

`Fortress/` is primarily for **humans** managing and evolving the project.

### Fortress/Projects/
This is the **agent product container** — what we give build agents to test. It is not the research lab.

**Phases under Projects:**

```
Fortress/Projects/
├── PHASES.md          ← phase index for Director/steward (lightweight)
├── 1.2A/              ← frozen legacy baseline (`.docs/` layout)
├── 2.1/               ← `.documents/` + tensions + REGISTRY (Exp06 fork)
└── …                  ← additional phases as needed
```

Each phase folder is a **complete agent package**: `AGENTS.md` at that folder is the **project root** for that shootout. Agents must not be pointed at `Fortress/Projects/` without a phase id.

| Layer | Location | Purpose | Rigidity |
|-------|----------|---------|----------|
| **Experiments** | `Research/Ribosome/Experiments/` | Prototypes, arguments, REVISED plans | Low — explore freely |
| **Phases** | `Fortress/Projects/{id}/` | Build-agent product | Medium — must be buildable when used |
| **Export** | `Fortress/Export/Phase {id}/` | Zips and prompts for shootouts | High — full copy only when zipping |

**Promotion (Experiment → Phase):** When Research and the Director agree a prototype is ready for agent testing, the steward **copies or moves** the doc tree into `Fortress/Projects/{id}/` and mirrors to `Export/`. No fixed ceremony — a log entry or `STATUS.md` line is enough. Experiments stay in Research for history; phases are the "current product."

**Multiple phases in flight:** Allowed. The shootout prompt must name **one** phase (e.g. "copy `Export/Phase 2.1/Projects/`"). `Projects/PHASES.md` records which phase is the default for new work if unclear.

**Migration (2026-06-26):** `Fortress/Project/` renamed to `Fortress/Projects/`. Legacy 1.2A nested at `Projects/1.2A/` with **internals unchanged**. `Export/Phase 1.2A/` still uses inner folder `Project/` for backward compatibility.

- Everything an agent is allowed to see and modify during a build lives inside the **named phase folder** (and its external shootout copy).
- Agents must update the **active phase** first; steward syncs back to `fortress-design` after review.

### Role of PROCESS.md
`PROCESS.md` is the **authoritative management and coordination document** for the entire Fortress project.

It exists to:
- Define how the project as a whole should be operated and evolved.
- Record significant management-level decisions (structure, process changes, boundaries, export rules, quality gates, etc.).
- Serve as the single source of truth that both humans and agents consult when questions arise about *how the project should be run*.

Significant process, structural, or coordination decisions should be recorded in `PROCESS.md` rather than living only in chat or scattered across other documents.

This document sits above `AGENTS.md`. While `AGENTS.md` governs agent behavior *during a build*, `PROCESS.md` governs the project itself.

---

## The Standard Session Cycle

Most productive sessions follow this pattern:

1. **Reasoning Disclosure** (Mandatory first step in most sessions)
   - Agent reads the attached `ReasoningDisclosure-Prompt.md`
   - Agent produces `REASONING_YYYY-MM-DD.md` in the project root
   - This surfaces understanding, conflicts, gaps, and assumptions **before** any implementation begins

2. **Analysis & Decision**
   - Human reviews the reasoning file(s)
   - High-severity gaps are noted and (when appropriate) fixed in the documentation
   - Decision is made whether to proceed to build or do another documentation pass

3. **Build Attempt** (when documentation is ready)
   - Agent is given the current `Projects/{phase}/` contents + prompt
   - Agent follows `AGENTS.md` rules strictly
   - All deviations are reported

4. **Post-Build Review & Final Artifact**
   - Build report + Deep Documentation Audit is produced
   - Violations and gaps are analyzed
   - `STATUS.md` is updated
   - `BUILD_CARTOGRAPHY.md` is generated automatically as the **final mandatory artifact** of every build (see `AGENTS.md` section 8.5)

5. **Documentation Maintenance**
   - High-value findings are folded back into `Projects/{phase}/` documentation (steward promotes from reports)
   - `STATUS.md` and other living documents are updated
   - Export zip is refreshed if needed

---

## Key Rules

- **Reasoning Disclosure is non-negotiable** before implementation in training/experimental sessions.
- **Rule 10 (Conflict Resolution)**: When documents conflict, `AGENTS.md` is the highest authority. The conflict and resolution must be explicitly stated.
- **Rule 11 (Gap Reporting)**: Agents must flag gaps and ambiguities rather than making silent assumptions. High-risk assumptions must be prominently reported.
- **No silent fixes**: If documentation is wrong or incomplete, it should be fixed in the source documents, not worked around in code.
- **Chat memory minimization**: After every significant session, the state of the project must be captured in `STATUS.md`, `Logs/`, and other living documents so future sessions do not require recalling previous chat context.

### Session logging (`Logs/`)

A `Logs/` folder holds daily work summaries, decision records, and process notes.

- **Naming:** `{Topic}-{YYYY-MM-DD}-{HHmm}.md` in 24-hour format (e.g. `Daily-Work-Summary-2026-06-21-1251.md`, `Phase2-Decisions-2026-06-21-1430.md`).
- **When:** Significant work completed, key decisions made, or end of a focused session.
- **Goal:** Preserve context, decisions, and progress without relying solely on chat history.

See [`Logs/README.md`](Logs/README.md). Logs complement `STATUS.md`, `handoff-audit.md`, and `Handoff/MemoryCapsule/CURRENT.md`.

### Preflight reports

A **preflight** is a steward-written readiness check before you hand something off — a phase package, an export, an experiment, whatever. Not a form for you to fill in; the steward inspects the repo and writes the report.

**How to request:** say something like *"Let's get a preflight report for Phase 2.1"* or *"preflight the 1.2A export"*.

**Steward flow:**

1. **Clarify (optional)** — ask a few short questions if the subject or goal isn't obvious (e.g. shootout vs doc-only review, which phase path). **You can skip this** with *"just run it"* or a clear subject.
2. **Check** — read files, grep for stale paths, verify layout — using the kinds of checks below that apply.
3. **Report** — write a finished markdown file to `Logs/Preflight-{Subject}-{YYYY-MM-DD}-{HHmm}.md` with a **verdict** at the top: `Ready` · `Ready with conditions` · `Not ready`, then findings, blockers, and one recommended next step.

**Kinds of things to check** (use what fits the subject; skip the rest):

| Kind | Examples |
|------|----------|
| **Subject clear** | What folder, experiment, or export; what decision this gates |
| **Artifacts exist** | Expected files/folders on disk (e.g. `AGENTS.md`, `.documents/`, `Builds/`) |
| **Decisions recorded** | Relevant calls written down, not only in chat |
| **Stale references** | Old paths (`Fortress/Project/`, `adr/`, `006/`) where the new layout differs |
| **Caps and scope** | Prototype limits respected (e.g. 2.1 tension/strategy counts) |
| **Export / shootout** | Mirror and prompt exist if you're about to zip or run agents |
| **Git (informational)** | Uncommitted or unpushed changes — note, don't treat as automatic blocker |

**Questions in the report:** only when the steward truly can't tell (e.g. "shootout or plan-mode only?"). Otherwise infer and state assumptions in the report.

### Fortress/Projects is the Source of Truth for Build Artifacts

**`Fortress/Projects/{phase}/` is the source of truth for build agent artifacts for that phase.**

- Every file an agent creates or modifies during a build belongs inside the **active phase folder** (or the external shootout copy of it).
- Default phase for new shootouts: **1.2A** (`Projects/1.2A/`) unless prompt names **2.1** or another id.
- Nothing should be written to `Research/` during builds. Agents are forbidden from reading `Research/`.

This separation keeps agent product under `Projects/` while `Fortress/` holds process, research, and training notes for the Director.

---

## Maintenance Instructions for Grok

You are responsible for keeping this process description accurate.

**After any session that changes how we work** (new technique, new document type, change in workflow, new quality gate, etc.), you must:

1. Update the relevant section of this document.
2. Add a brief note in `STATUS.md` under "Process Changes".
3. Date the change.

Do not let the documented process drift from actual practice. If we start doing something differently in sessions, this document must reflect it within the same session or immediately after.

Treat `PROCESS.md` as the single source of truth for "how Fortress sessions are supposed to run."

**Special note on `Fortress/Projects`**: If the boundary or usage rules change, update the "Fortress/Projects is the Source of Truth for Build Artifacts" section immediately.

---

## Preparing Export / Shootout Zips

When creating a zip for agent testing, shootouts, or handoff, follow these rules strictly:

### Core Rule: Full Copy Only
`Fortress/Export/Phase {id}/` must be a **full, clean copy** of `Fortress/Projects/{id}/` at the time of zipping. Do not selectively copy files. Legacy 1.2A export uses inner folder `Project/`; Phase 2.1+ uses `Projects/`.

### Required Contents
Every export package must contain:

- `Projects/` or `Project/` — Full copy of the phase folder (see `Projects/PHASES.md` for naming per phase)
- `Prompts/` — Latest versions of all prompts (especially the current `ReasoningDisclosure-Prompt.md`)
- `BUILD_CARTOGRAPHY.md` — Must be present in `Project/.docs/Builds/`

### Zip Naming Convention
Use the following naming pattern inside the Phase folder:

`Fortress-PhaseX.Y[-Descriptor]-YYYY-MM-DD.zip`

Examples:
- `Fortress-Phase1.2A-Final-2026-06-21.zip`
- `Fortress-Phase1.2A-Shootout-2026-06-21.zip`
- `Fortress-Phase1.2A-Updated-2026-06-21.zip`

### Steps to Prepare a New Zip
1. Ensure `Fortress/Projects/{id}/` is in its desired state.
2. Generate `BUILD_CARTOGRAPHY.md` as the final artifact of the build when applicable.
3. Copy the entire phase folder into `Fortress/Export/Phase {id}/Projects/` (or `Project/` for legacy 1.2A export).
4. Copy the latest prompts into `Fortress/Export/Phase X.Y/Prompts/`.
5. Create the zip using the naming convention above.
6. Place the zip inside `Fortress/Export/Phase X.Y/`.

### Maintenance Note for Grok
After any change to the build or export process, update this section immediately so the documented procedure matches actual practice.

3. Create the zip from the **contents** of `Fortress/Export/Phase X.Y/`.

4. **Zip Naming Convention**:
   `Fortress-PhaseX.Y[-OptionalDescriptor]-YYYY-MM-DD.zip`

   Examples:
   - `Fortress-Phase1.2A-Final-2026-06-21.zip`
   - `Fortress-Phase1.2A-Shootout-2026-06-20.zip`
   - `Fortress-Phase1.2A-Updated-2026-06-20.zip`

   - Use `Final` when the documentation is considered stable for a phase.
   - Use `Shootout` when preparing for multi-agent comparison runs.
   - Use `Updated` when refreshing after documentation changes.
   - Always include the date in `YYYY-MM-DD` format.

5. Place the resulting `.zip` file directly inside `Fortress/Export/Phase X.Y/`.

This process ensures that export zips are self-contained, versioned, and do not rely on chat memory to reconstruct.

---

**Last Major Update:** 2026-06-26 (Project → Projects rename, 2.1 scaffold)  
**Maintained By:** Grok (steward); Director (Mr. Bear) sets pace and priorities