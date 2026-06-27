# Fortress Structure Migration — Passes 0–3

**Date:** 2026-06-26  
**Runner:** Steward  
**Backup:** `Records/Backups/Fortress-Migration-2026-06-26-2321.zip`

## Completed

### Pass 0
- Full Fortress backup (excluding existing Backups/ contents during zip)

### Pass 1
- `Logs/` → `Records/Logs/` (flat merge)
- `Handoff/` → `Core/Memory/`, `Core/HANDOFF.md`, executive summary → `Records/Logs/`
- `Export/Phase 1.2A/` → `Phases/1.2A/Export/`
- Top-level `Export/` stub README (retire after docs pass)

### Pass 2
- `Research/` retired
- Moved to targets: Investigations, Archive Legacy/Experiments, Ideas subfolders, Records/Backlog
- **Dedupe deferred:** conflicts staged under `Archive/Research-import/` (Ideas, Phases, root `.md` files)

### Pass 3
- `Phases/1.2A/` → `Project/` + `Export/` (symmetry with 2.1)

## Not done (Pass 4+)
- `PROCESS.md`, `README.md`, `STATUS.md`, `Core/STRUCTURE.md` path updates
- Remove top-level `Export/` stub
- Research-import dedupe discussion (item 4)
- 2.1 PLUGIN hygiene

## Target tree achieved

```
Fortress/
├── Archive/
├── Core/
├── Ideas/
├── Phases/
└── Records/
```

Plus root: `PROCESS.md`, `README.md`, `STATUS.md`, and temporary `Export/` stub.