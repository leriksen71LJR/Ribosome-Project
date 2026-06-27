# HANDOFF.md — Fortress AI Agent Training

**This is an AI Building Agent Training project.**

The goal is **not** to build the best possible Fortress application.  
The real product is the **documentation system** itself — how well it can guide AI agents to build correctly, consistently, and with discipline.

---

## Current Phase

**Phase:** 1.2 (Light Restructure Complete)  
**Focus:** Strengthening output discipline, violation reporting, documentation feedback loops, and clean separation of Research vs Project layers.

### Phase 1.2 Active Rules
The enforceable rules for Phase 1.2 have been consolidated into `Project/AGENTS.md` under the "Critical Rules (Must Follow)" section.

**[2026-06-20] Priority 1 Fixes + Reasoning Disclosure Prompt Update**
- Added **Rule 10 (Conflict Resolution & Authority Hierarchy)** and **Rule 11 (Strict Following & Gap Reporting)** to `AGENTS.md` (both in `Project/` and `Export/Phase 1.2A/`).
- Created minimal stub for the previously missing `PHASE_1_1_IMPROVEMENTS.md`.
- Updated the Reasoning Disclosure Prompt in all three locations to explicitly reference Rule 10 and Rule 11 in the Success Criteria, Inferences section, and as a new "Important — New Rules" paragraph after the Mandatory Rules. This ensures agents are reminded to follow the new conflict resolution and gap-reporting behavior during reasoning.

### Key Structural Changes (Pre-1.2)

- Created clean top-level structure: `Fortress/`, `.archive/`, `.fortress/`
- Established `Fortress/Research/` as the **human-only thinking space**
- Established `Fortress/Project/` as the **agent-visible build documentation**
- Added `Fortress/Research/Backlog/` for capturing and ranking future ideas (Reasoning Disclosure tooling added as a priority item for the initial Phase 2 backlog)
- Moved all active work into `Fortress/`

---

## Folder Structure (Current)

```
Fortress/
├── Research/                     ← Human thinking space only (includes Phases/ with historical + future planning docs)
├── Project/                      ← Agent-visible documentation (AGENTS.md is the primary rules contract)
├── Handoff/                      ← Cross-chat context and handoff documents
├── Export/                       ← Zips and deliverables
└── HANDOFF.md
```

**Important Snapshot (2026-06-18)**

All contents that were previously under `Fortress/Project/` have been moved into a top-level snapshot folder:

`.project-2026-06-18/`

This folder contains the state of `Project/` at the time of the light restructure (including `Workflows/`, `Evaluation/`, `Phases/`, `AGENTS.md`, `CODING_STANDARDS.md`, `Prompts/`, etc.).

This was done to preserve the current state before further structural decisions. `.project-2026-06-18/` should be treated as a frozen snapshot for reference.

---

## Important Principles

- **Research is our thinking space.** Nothing in `Research/` should be given to build agents.
- **Build documentation is a product of research.** We promote ideas from `Research/` into `Project/` only when they are ready.
- The **Ribosome Model** is the current primary direction. See `Research/Ribosome-Model.md` for the dedicated summary.
- **Real file system operations are required.** Any simulated file/folder structures must be explicitly disclosed and approved before use. We treat this as a real coding/design project — actual file system changes are strongly preferred over simulation.

---

## How to Run Phase 1.2 Builds

Use the provided PowerShell script from the root or `.fortress/`:

```powershell
.\Run-Phase1.2.ps1 `
    -ClaudePath  "C:\path\to\fortress-shootout\Claude" `
    -GrokPath    "C:\path\to\fortress-shootout\Grok" `
    -CortexPath  "C:\path\to\fortress-shootout\Cortex"
```

---

*This project treats documentation as the primary deliverable and AI agents as the testing mechanism.*

---
**[2026-06-18] Baseline Reset**
Reset `Fortress/Project/` to Phase 1.1 baseline from `Fortress-Phase1.1-Shootout-Complete.zip`.
Structure restored: `AGENTS.md`, `README.md`, and `.docs/` (core documents only).
This serves as the stable starting point before further Phase 1.2 / Phase 2 work.
Snapshot of previous state preserved in `.project-2026-06-18/`.

**[2026-06-19] Legacy Documents Moved**
Moved the following outdated Phase 1.1 documents from `Project/.docs/` to `Research/Legacy/`:
- `CODING_WORKFLOWS.md`
- `ARCHITECTURE_DECISIONS.md`
- `PROJECT_OVERVIEW.md`

These are historical and no longer aligned with current Phase 1.2 direction.

---

## Export Process (When Creating Phase Zips)

When preparing a new phase export (e.g. `Phase1.2/`), follow these steps:

1. Copy the latest Reasoning Disclosure prompt from:
   `Fortress/Research/ReasoningDisclosure/ReasoningDisclosure-Prompt.md`

2. Place it into the export prompts folder:
   `Fortress/Export/Phase1.2/Prompts/ReasoningDisclosure-Prompt.md`

3. Then copy the current `Project/` contents into `Fortress/Export/Phase1.2/Project/`.

4. Finally, create the zip from the entire `Fortress/Export/Phase1.2/` folder.

This ensures every phase export includes the current version of the Reasoning Disclosure prompt for consistent research data collection.

---

## [2026-06-20] Reasoning Disclosure Prompt Evaluation & Update

**Context:**  
Three build agents (Claude, Grok, Codex) were asked to evaluate the previous version of the Reasoning Disclosure Prompt. Their feedback was collated in `Research/Prompt Evaluation.md` (attached in conversation) and used to drive targeted improvements.

**Key Issues Identified by Agents:**
- "Fresh Analysis Only" was hard to fully enforce in continued sessions (vocabulary vs. actual capability).
- Project root / folder boundary language had drifted ("Project/" vs actual `.docs/` + root files).
- No explicit rule for overwriting an existing same-day `REASONING_*.md`.
- Read scope in `.docs/` was underspecified (should generated reports be included?).
- No clear authority/conflict resolution rule when documents contradict.
- Section 4 ("Documentation as Pseudocode") had some redundant sub-questions.
- No explicit "minimum bar" or success criteria for a satisfactory reasoning file.
- "Impact of Conclusions" overlapped with later sections.
- Missing referenced documents were part of the test but not explicitly audited.

**Improvements Applied:**
1. Strengthened "Fresh Analysis Only" with more explicit, enforceable language.
2. Added clear **Project Root Definition** ("the directory containing `AGENTS.md`").
3. Added explicit **overwrite rule** for existing same-day reasoning files.
4. Added explicit read boundary rules and exclusions for generated content.
5. Added required **"Missing or Broken References"** subsection.
6. Added lightweight **Success Criteria** for the reasoning file.
7. Tightened Section 5 (Documentation as Pseudocode) and added **self-evaluation of the prompt itself** as a new final section.
8. Scoped "Impact of Conclusions" more narrowly to per-document effects.
9. Added authority/conflict guidance (follow AGENTS.md unless it defers).

**Result:**  
The prompt is now more coherent, self-consistent, and better at forcing the exact behaviors we want (visible inference, contradiction handling, pseudocode evaluation, and prompt self-audit). It is also easier to compare outputs across agents because it produces a single dated file with a stable section structure.

**Files Updated:**
- `Fortress/Research/ReasoningDisclosure-Prompt.md` (primary)
- `Fortress/Research/ReasoningDisclosure/ReasoningDisclosure-Prompt.md`
- `Fortress/Export/Phase 1.2A/Prompts/ReasoningDisclosure-Prompt.md`
- `Fortress/Research/HowToUse-ReasoningDisclosure.md` (updated usage instructions and changelog)

This update directly improves the quality of diagnostic data we will collect in future Phase 1.2 and Phase 2 Reasoning Disclosure runs.

**Next Recommended Action:**  
Re-run the Reasoning Disclosure exercise with the updated prompt across all three agents (Claude, Grok Build, Codex) in fresh sessions and compare the new outputs against the previous set. Use differences to further refine both the prompt and the underlying Fortress documentation.

*Documentation is the product. Agents are the measurement instrument.*

