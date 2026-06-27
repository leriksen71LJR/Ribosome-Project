# Fortress Research — Structure & Rules

**Status:** Active canonical structure (as of 2026-06-26)

## Purpose

`Fortress/Research/` is the **single source of truth** for all meta-level work on the Fortress project. It exists to:

- Capture raw thinking and emerging ideas without polluting the buildable project.
- Evolve prompts, processes, and philosophy over time.
- Maintain long-term continuity and high-fidelity handoffs.
- Enable deep analysis across multiple agent runs and phases.
- Keep the "thinking space" cleanly separated from the "building space".

This folder is **human + lead researcher territory**. The local Supergrok instance (inside `Fortress/Project/`) owns the build artifacts and should generally not read or write here.

## File Naming Conventions

### Date Format in Filenames

When saving any document that includes a date in the filename, use the following format:

**`yyyy-MM-dd-hhmm`**

**Examples:**
- `Experiment-06-Analysis-2026-06-22-1926.md`
- `Daily-Work-Summary-2026-06-21-2117.md`
- `Ribosome-Project-Review-Summary-2026-06-22-1020.md`

This format provides both the full date and the exact time the document was created (24-hour clock, no colon).

## Context Management & Backup Triggers

Because these research conversations can become long and dense, we maintain awareness of context usage and back up important work proactively.

### Context Awareness
- When context usage approaches **~80%**, Research should flag it.
- When context usage approaches **~90%**, Research should strongly recommend creating a backup of key documents before continuing.

### When to Create a Backup
Create a backup (usually by saving a dated snapshot or updating the Memory Capsule) when any of the following occur:

- Before making significant structural changes to a major guidance document (e.g. Experiment 07).
- After reaching a meaningful decision point or new principle (especially if it affects how future work should be done).
- When the conversation has become very long and we are about to enter a new major phase of work.
- When the user explicitly requests a backup.

### Purpose
This practice protects high-value thinking from being lost due to context compression. It is not about saving everything — it is about protecting the principles, decisions, and documents that would be expensive to reconstruct.

## Backup Procedures

### Full Research Folder Backup

When a complete snapshot of the current Research state is needed (especially before major transitions, after significant decision points, or at the end of a work session), follow this process:

**Naming Convention:**
`Research-Complete-yyyy-MM-dd-hhmm.zip`

**Example:**
`Research-Complete-2026-06-24-1430.zip`

**Process (Must be followed in order):**

1. **Record the backup in this file first** (STRUCTURE.md) — including date/time, reason for backup, and what major work was just completed.
2. Create the zip from the **parent directory** of `Research/` (i.e. from `artifacts/`).
3. The resulting zip should be placed in `Research/Records/Backups/` (create the folder if it does not exist).
4. After creating the zip, update this section with the final filename and location.

**Why this order matters:**
Recording the intent and context *before* creating the archive protects against situations where the backup itself fails or context is lost mid-process.

**Current Backup Location:**
`Research/Records/Backups/`

### Latest Full Backup Performed

**Date/Time:** 2026-06-24 04:54  
**Filename:** `Research-Complete-2026-06-24-0454.zip`  
**Location:** `Research/Records/Backups/Research-Complete-2026-06-24-0454.zip`  
**Reason:** End of session backup after finalizing Decision 3 (`.documents/` + `.codingAgent/` model) and before shifting focus to Phase 2.2 research via daily revolving ensemble task.  
**Process followed:** Backup procedure recorded in STRUCTURE.md first, then zip executed from `artifacts/` directory.

---

## Directory Layout (Simplified - 5 root folders)

The target structure for Research/ is 5 root folders:

```
Research/
├── Archive/     ← All historical, old experiments (001-006 + 007 drafts), legacy, superseded docs (git has full history)
├── Core/        ← Timeless high-signal essentials: Current-Context.md, STRUCTURE.md, CHARTER.md, README-Handoff.md, Memory Capsule, Experimental Internalization Capsule
├── Ideas/       ← Active 2.2+ thinking: Memory Palaces ideas, specialized agents, Structure Builder, 20 paths, preflight template/process, etc.
├── Phases/      ← Phase-specific work and planning: subfolders 2.1/ and 2.2/ (e.g. 2.1/ contains Decisions/, Guidance/, Plans/, preflight, summary; 2.2/ contains exploratory ideas)
└── Records/     ← Logs (recent only), Backlog, Export (handoff reports), Backups (minimal)
```

Old clutter (Investigations, old Ideas files, pre-2.1 Experiments subs, etc.) moved to Archive/. Phase-specific material (such as 007 guidance) is now promoted into Phases/ while timeless essentials stay in Core/. This reduces root items dramatically while keeping everything accessible via git. 
```
```

Also update the rules if needed, but this is the main.

## Rules

1. **Everything that is not buildable agent input goes here.**
2. **Do not create new top-level folders** without updating this file first.
3. **Keep content high-signal.** Prefer one strong document over many fragmented ones.
4. **Date-stamp important artifacts** (e.g., `REASONING_2026-06-20.md`, `Ideas-2026-06-19.md`).
5. **Never put code, .docs/, or buildable project files here.** Those belong in `Fortress/Project/`.
6. **When in doubt, put it in `Ideas/` first** with a clear filename and date. We can promote it later.

## Current Active Areas (2026-06-21)

- **Prompts/**: Reasoning Disclosure Prompt (with gamification layer) and Build prompts.
- **ReasoningDisclosure/**: Collected outputs from Claude, Grok Build, and Codex runs.
- **Ideas/**: Ribosome model evolution, Documentation as Pseudocode, gamification experiments, Phase 2 proposals.
- **Philosophy/**: Core principles behind making documentation executable and agent-coordinated.
- **Handoffs/**: Migration notes from chat-based development to local VS Code + Continue.dev workflow.
- **Export/** (now under `Records/Export/`): Preferred location for analysis reports and artifacts intended to move to the local project (replacing the older `Analysis/` folder).

## Relationship to Fortress/Project/

- `Fortress/Project/` = The thing agents build and maintain (AGENTS.md, .docs/, source code).
- `Fortress/Research/` = The thinking that produces and improves the rules agents follow.

These two folders should remain **strictly separated**. The local Supergrok should treat `Research/` as read-only (or out of scope) unless explicitly instructed otherwise.

---

**Last updated:** 2026-06-26 — Added `Phases/` with per-phase subfolders (e.g. 2.1/, 2.2/). Phase 2.1 content organized under 2.1/.  
**Next review trigger:** Major phase transition or significant prompt/process change.
## Logging Process

- A `Logs/` folder (under `Records/Logs/`) exists for daily work summaries, decision records, and process notes.
- Log files should use clear, descriptive names that include the date and time in 24-hour format (e.g. `Daily-Work-Summary-2026-06-21-1251.md` or `Phase2-Decisions-2026-06-21-1430.md`).
- Logs are created when significant work is done, key decisions are made, or at the end of focused sessions.
- The goal of logging is to preserve context, decisions, and progress without relying solely on chat history.

## Recent Files

The dedicated `_Recent/` convenience folder was retired 2026-06-25. Its contents were copies of active work; full history is preserved in git. Active and recent files are now maintained directly in their canonical homes (primarily `Ideas/`, `Phases/`, and under `Records/`). Historical Experiments material is now under `Archive/Experiments/`. When a user asks for recent files, surface the most relevant items from their proper long-term locations.

## Operational Processes

For day-to-day or cleanup work like larger file moves or repo simplification, we follow the lightweight **Operational File Move Pipeline** (detailed in `Ideas/Preflight-Process.md`):

- Preflight the task (scope, current state, risks).
- Small intentional batches only.
- Verify immediately after each.
- Reflect after each batch.
- Final disclosure by updating this file and relevant logs.

This ensures we stay high-signal, conservative, and reflective even on operational tasks. The target for simplification is 5 root folders under Research/: Archive/, Core/, Ideas/, Phases/, Records/.
