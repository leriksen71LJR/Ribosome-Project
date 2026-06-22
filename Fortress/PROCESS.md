# Fortress Operating Process

This document defines **how** we work in Fortress. It is the authoritative description of the workflow, session structure, and quality gates.

The goal is to make the process repeatable and largely independent of chat memory.

---

## Core Philosophy

We treat **documentation as executable pseudocode** for AI agents.

The quality of the output is primarily determined by the quality and clarity of the documentation, not by the intelligence of the agent. Therefore, we invest heavily in:

- Making reasoning visible before code is written (Reasoning Disclosure)
- Explicit conflict resolution and gap reporting (Rules 10 and 11)
- Maintaining living documentation that reduces the need for chat context

---

## Project Structure and Boundaries

`Fortress/` (the root) and `Fortress/Project/` serve different purposes and must be kept clearly separated.

### Fortress/ (Root)
This is the **overall project container**. It holds:

- High-level process and management documentation (`PROCESS.md`, `STATUS.md`, `HANDOFF.md`)
- Research, ideas, analysis, and long-term thinking (`Research/`)
- Export packages and prompts used for agent testing (`Export/`)
- Any human-only coordination or meta-documentation

`Fortress/` is primarily for **humans** managing and evolving the project.

### Fortress/Project/
This is the **agent build workspace** and the single source of truth for all build artifacts.

- Everything an agent is allowed to see and modify during a build lives here.
- It contains `.docs/`, source structure, build reports, `BUILD_CARTOGRAPHY.md`, etc.
- Agents must update `Fortress/Project` first and always.

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
   - Agent is given the current `Project/` contents + prompt
   - Agent follows `AGENTS.md` rules strictly
   - All deviations are reported

4. **Post-Build Review & Final Artifact**
   - Build report + Deep Documentation Audit is produced
   - Violations and gaps are analyzed
   - `STATUS.md` is updated
   - `BUILD_CARTOGRAPHY.md` is generated automatically as the **final mandatory artifact** of every build (see `AGENTS.md` section 8.5)

5. **Documentation Maintenance**
   - High-value findings are folded back into `Project/` documentation
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

### Fortress/Project is the Source of Truth for Build Artifacts

**`Fortress/Project` is the single source of truth for all build agent artifacts.**

- Every file an agent creates, modifies, or generates during a build must be placed inside `Fortress/Project`.
- Agents must **update `Fortress/Project` first and always**.
- The `Project/` folder contains everything the build agent is allowed to see and change (`.docs/`, source code structure, build reports, `BUILD_CARTOGRAPHY.md`, etc.).
- Nothing should be written outside of `Fortress/Project` during a build session unless explicitly instructed.

This separation keeps `Fortress/Project` clean as the deliverable artifact folder while `Fortress/` (the parent) holds process, research, and meta-documentation.

---

## Maintenance Instructions for Grok

You are responsible for keeping this process description accurate.

**After any session that changes how we work** (new technique, new document type, change in workflow, new quality gate, etc.), you must:

1. Update the relevant section of this document.
2. Add a brief note in `STATUS.md` under "Process Changes".
3. Date the change.

Do not let the documented process drift from actual practice. If we start doing something differently in sessions, this document must reflect it within the same session or immediately after.

Treat `PROCESS.md` as the single source of truth for "how Fortress sessions are supposed to run."

**Special note on `Fortress/Project`**: If the boundary or usage rules for `Fortress/Project` change, update the "Fortress/Project is the Source of Truth for Build Artifacts" section immediately. This principle is foundational to keeping agent work contained and reproducible.

---

## Preparing Export / Shootout Zips

When creating a zip for agent testing, shootouts, or handoff, follow these rules strictly:

### Core Rule: Full Copy Only
`Fortress/Export/Phase X.Y/` must be a **full, clean copy** of `Fortress/Project/` at the time of zipping. Do not selectively copy files. The goal is to give the agent the complete, current state of the project.

### Required Contents
Every export package must contain:

- `Project/` — Full copy of `Fortress/Project/`
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
1. Ensure `Fortress/Project/` is in its final desired state.
2. Generate `BUILD_CARTOGRAPHY.md` as the final artifact of the build (see section below).
3. Copy the entire `Fortress/Project/` into `Fortress/Export/Phase X.Y/Project/`.
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

**Last Major Update:** 2026-06-21  
**Maintained By:** Grok