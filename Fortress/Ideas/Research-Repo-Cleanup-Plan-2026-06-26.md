# Research Repo Cleanup Plan (Target Structure Alignment)

**Date:** 2026-06-26  
**Session:** 002  
**Author:** Research  
**Type:** Operational cleanup following Operational File Move Pipeline  
**Status:** A + B complete. Legacy manifest deleted. Experiments moved to Archive/Experiments/. Phase 2.1 content reorganized under Phases/2.1/. 5 root folders with per-phase subdirs. 0 out of place files.

---

## Preflight

### What are we trying to achieve?
Align the `Research/` directory strictly with the declared target of **5 root folders**:

```
Research/
├── Archive/
├── Core/
├── Ideas/
├── Phases/ (2.1/, 2.2/ ...)
└── Records/
```

Currently, 25 files live outside these 5 folders.

### Current State
**Canonical folders (good):**
- Archive/
- Core/ (now clean after Phase move)
- Ideas/
- Phases/ (with per-phase subfolders 2.1/, 2.2/ ...) (new)
- Records/ (currently empty)

**Initial misplaced (before execution):** 25 files across Backlog/, Backups/, Experiments/, Export/, Logs/ + root manifest.

(The legacy `_active-documents.txt` was thrown away as decided.)

### Target Locations
- `Backlog/` → `Records/Backlog/`
- `Backups/` → `Records/Backups/`
- `Export/` → `Records/Export/`
- `Logs/` → `Records/Logs/`
- `Experiments/` → Archive/Experiments/ (chosen option A)

### Files Containing References That Will Need Updating
Literal or near-literal references to the old top-level folders exist in these files (as of 2026-06-26):

**High-priority (must update):**
- `Research/Core/STRUCTURE.md`
- `Research/Core/CHARTER.md`
- `Research/Core/Current-Context.md`
- `Research/Core/README-Handoff.md`
- `Research/Core/Memory/Research-Memory-Capsule--2026-06-21-1438.md`
- `Research/Records/Logs/Session-002-2026-06-26.md`
- `Research/Phases/2.1/Phase-2.1-Preflight-2026-06-25.md`
- `Research/Ideas/Research-Repo-Cleanup-Plan-2026-06-26.md` (this file)
- `Research/Records/Logs/Folder-Cleanup-2026-06-25.md`
- `Research/Records/Logs/Daily-Work-Summary-2026-06-24-1818.md`

**Lower / contextual (review only):**
- Various other Daily-Work-Summary files
- The large `PHASE_2_1_PROJECTS_RESTRUCTURE_PLAN-2026-06-24.md` (many "Export/Phase" and "Experiments/" mentions are for the main project, not Research/)
- Legacy files under `Archive/`

During the docs pass we will use targeted searches and context to avoid changing project-level references.

### Risks & Gotchas
- **Path references**: Documents contain both *literal filesystem paths* (must be updated) and *conceptual references* (e.g. "the Export handoff location"). We will update literal paths to the new locations under Records/. For conceptual text we will decide case-by-case whether to keep high-level language ("Export/ handoff area") or use the full new path.
- `(legacy _active-documents.txt deleted)` itself lists paths — must be updated in the docs pass.
- Historical zips in Backups/ and some legacy mentions in Archive/ require care.
- Some "Export/Phase X.Y/" and "Experiments/" references in plans refer to the *main Fortress project structure*, not this Research/ folder — the update pass must use context to avoid incorrect changes.
- Git will track moves (intentional and good).
- No code/build impact (pure research docs).

### Backup Requirement (Critical)
Per STRUCTURE.md "When to Create a Backup" and "Backup Procedures":
- Before this structural change, record the plan here (done).
- Recommended: Create a full dated backup `Research-Complete-2026-06-26-XXXX.zip` (following the exact procedure in STRUCTURE.md) before Batch 1 if we want maximum safety.
We will add an explicit pre-batch backup action.

### Definition of Done
- Zero files outside the 5 canonical root folders (the legacy manifest was thrown away).
- All internal references updated and verified.
- STRUCTURE.md, active documents manifest, and relevant logs updated.
- Cleanup log entry created.

---

## Proposed Batches (Small & Intentional)

**Pre-Batch 0 (Mandatory before any moves):**
- Record backup intent here (already done).
- Executed full backup: `Research\Backups\Research-Complete-2026-06-26-2155.zip`
- Backup created successfully before any moves.

Follow the full pipeline for each batch: Preflight (mini) → Move → Verify immediately → Reflect → Update docs as needed.

### Batch 1: Logs Consolidation
**Goal:** Move `Logs/` under `Records/`.

**Actions:**
1. Move the entire `Logs/` folder → `Records/Logs/`
2. Verify:
   - `Research/Logs/` no longer exists at root
   - `Research/Records/Logs/` contains all 8 .md files
3. Update references:
   - **Literal paths**: Change `Logs/` and `Research/Logs/` → `Records/Logs/` and `Research/Records/Logs/`
   - **Conceptual text**: Review phrases like "A `Logs/` folder exists..." — decide whether to keep high-level or update.
   - Priority files from the list above.
4. Update `(legacy _active-documents.txt deleted)` (remove old Logs entries, add under Records/ section)
5. Append results to this plan.

**Execution results (2026-06-26-2155):**
- Move successful.
- Verified: Top-level no longer lists Logs. Records now contains Logs/ with exactly the 8 .md files.
- Batch 1 move complete. Docs update pending in Batch 5.

**Reflection questions:**
- Did any references get missed?
- Do the daily work summaries still make sense under Records/?

---

### Batch 2: Export Consolidation
**Goal:** Move `Export/` under `Records/`.

**Actions:**
1. Move entire `Export/` folder → `Records/Export/`
2. Verify contents (3 .md files including the recent Phase-2.1 summary)
3. Update references:
   - **Literal paths**: `Export/` and `Research/Export/` → `Records/Export/` and `Research/Records/Export/`
   - **Conceptual text** (CHARTER, Memory Capsule, Current-Context): 
     - Option A: Change to full new path.
     - Option B (preferred for readability): Keep high-level language like "the `Export/` handoff location (now physically under `Records/Export/`)" and only fix strict path references.
   - Priority files: see list above.
4. Update `(legacy _active-documents.txt deleted)`

**Note:** This batch has the highest number of descriptive references. We will decide Option A vs B during the batch.

**Execution results (2026-06-26-2155):**
- Move successful.
- Records now contains: Backlog\, Backups\, Export\, Logs\
- Top level now exactly the 5 canonical folders (Archive, Core, Ideas, Phases, Records). Only root (legacy _active-documents.txt deleted) remains out of place (1 file). Experiments/ fully handled under Archive.
- All four move batches complete. Batch 5 docs pass started.

---

### Batch 3: Backlog Consolidation
**Goal:** Move `Backlog/` under `Records/`.

**Actions:**
1. Move `Backlog/` → `Records/Backlog/`
2. Verify: 1 .md file moved
3. Update references (fewer):
   - Any mentions of root-level Backlog
4. Update active-documents.txt

**Execution results (2026-06-26-2155):**
- Move successful.
- Batch 3 complete.
- Batch 6 (Experiments) executed as A: moved to Archive/Experiments/. Docs updates done.

---

### Batch 4: Backups Consolidation
**Goal:** Move `Backups/` under `Records/`.

**Actions:**
1. Move entire `Backups/` folder → `Records/Backups/`
2. Verify the two zips and update paths in STRUCTURE.md (the backup procedure section)
3. Update any references to `Research/Backups/`

**Note:** Zips are large and historical. Moving the folder is low-risk.

**Execution results (2026-06-26-2155):**
- Move successful.
- Records now contains: Backlog\, Backups\, Export\, Logs\
- All folder moves complete. Only Experiments/ and root (legacy _active-documents.txt deleted) remain out of place.
- Batch 4 move complete.

---

### Batch 5: Cross-Reference Documentation Pass
**Goal:** Ensure no broken references remain after the folder moves.

**Actions:**
1. Run searches for remaining old paths (use context to skip main-project references):
   ```text
   Logs/ | Research/Logs/
   Export/ | Research/Export/
   Backlog/ | Research/Backlog/
   Backups/ | Research/Backups/
   ```
2. Update the exact list of files identified above.
3. Pay special attention to:
   - `(legacy _active-documents.txt deleted)` — rewrite the relevant sections with new paths and update section headers if desired.
   - STRUCTURE.md — update directory layout examples, "Recent Files", "Operational Processes", and backup location text.
   - CHARTER.md, Current-Context.md, README-Handoff.md, Memory Capsule — fix literal paths; apply chosen policy for conceptual text.
4. Re-grep and confirm zero incorrect remaining references to the old top-level locations (outside of this plan's historical text and Archive/).
5. Update this plan with "Docs pass complete".

---

### Batch 6: Experiments/ Decision & Execution (Optional but Recommended)

**Executed:** Phase 2.1 content reorganized under `Phases/2.1/`. 2.2/ content (8 idea files) moved from Ideas/ to `Phases/2.2/` and renamed to short names (e.g. 20-Exploratory-Paths-2026-06-24.md, Memory-Palaces-2026-06-24.md, etc.).

**Options:**
- **A (Recommended):** Move the entire `Experiments/` folder into `Archive/Experiments/`. 
  - Update the internal `Experiments/README.md` if it refers to its own location.
  - This removes the 6th top-level folder and is consistent with the 2026-06-25 cleanup philosophy.
- **B:** Keep `Experiments/` as a deliberate long-term exception (document why in STRUCTURE.md).
- **C:** Deeper archival — move the remaining non-Archive content into `Archive/` and delete the top-level `Experiments/` folder.

**Recommended:** A (unless we decide Experiments/ has ongoing value as a top-level concept).

If we choose A or C, treat it as Batch 6 with its own preflight + doc updates (including the preflight file that still points to old `Experiments/007...` paths).

---

## Execution Order Recommendation

1. Batch 1 (Logs) — low risk, many logs
2. Batch 3 (Backlog) — tiny
3. Batch 4 (Backups) — zips
4. Batch 2 (Export) — high reference impact, do after simpler ones
5. Batch 5 (Docs pass) — COMPLETE (all main literal refs updated; manifest cleaned; conceptual notes added where needed)
6. Batch 6 (Experiments) if desired

After each batch:
- Run directory listing verification (`Get-ChildItem Research`)
- Check for broken/outdated references via grep
- Update **this plan** (add results, date/time, any decisions made)

---

## Final Disclosure (After All Batches)

- Update `STRUCTURE.md` "Last updated" date and the 5-folder description if any wording needs tightening.
- Create or append a dedicated cleanup log: e.g. `Logs/Repo-Structure-Consolidation-2026-06-26.md`
- Refresh `(legacy _active-documents.txt deleted)` with correct paths under Records/ and update its section comments.
- Update `Current-Context.md` and this plan with completion notes.
- Set the Status line at the top of **this plan** to: **Status: Complete**
- Record summary: "X/25 files moved into canonical locations. All references reviewed and updated. Structure now aligned with 5-folder target."

---

## Open Questions for Director / Next Step

- (Experiments/ moved to Archive/Experiments/ as A)
- In the documentation pass for `Export/` and `Logs/`, do we prefer Option A (full new paths everywhere) or Option B (keep some high-level conceptual language)?
- (the legacy manifest was thrown away during execution)

---

*Revised 2026-06-26 with feedback: added backup requirement, literal vs conceptual distinction, explicit file list, and stronger self-update instructions.*

**Ready to execute when directed.** Use the Operational File Move Pipeline for each batch.