# Fortress Structure Migration — Pass 4 (Docs)

**Date:** 2026-06-26  
**Runner:** Steward

## Updated (literal paths)

- `README.md` — five-folder structure, Phases/Project/Export convention
- `STATUS.md` — current state post-migration
- `PROCESS.md` — structure, Records/Logs, preflight, per-phase export (removed duplicate export section)
- `Core/STRUCTURE.md` — rewritten for Fortress/ (not Research/)
- `Phases/PHASES.md` — phase index and shootout paths
- `Records/Logs/README.md` — paths and relationships
- `Core/README-Handoff.md`, `Core/Current-Context.md` — path fixes
- `Ideas/Preflight-Report-Template.md` — save location
- `Phases/2.1/Project/AGENTS.md` — boundary rules
- `Core/Ribosome-Model.md` — footer path

## Removed

- Top-level `Fortress/Export/` stub folder

## Not updated (intentional)

- `Archive/` historical documents — paths left as-is
- `Phases/2.1/Project/Plans/` and similar — contain historical `Projects/` references in body text
- Session logs in `Records/Logs/` — historical narrative

## Verify

Grep live ops docs for `Fortress/Research/`, top-level `Export/`, `Projects/` — should be gone from README, STATUS, PROCESS, STRUCTURE, PHASES.