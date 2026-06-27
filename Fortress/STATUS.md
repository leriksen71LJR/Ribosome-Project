# Fortress Status — Living Project State

**Purpose:** Current snapshot without chat memory.  
**Workspace role:** `fortress-design` is **documentation and export prep only**. Builds run in a **separate project**.

**Last Updated:** 2026-06-26

---

## Current Overall State

**Phase:** **1.2A** default export (frozen under `Phases/1.2A/Project/`). **2.1** scaffolded under `Phases/2.1/Project/` (Exp06 fork + tensions/REGISTRY split).

**Goal:** Train Director via agent shootouts; Phase 2.1 tests `.documents/` / `.codingAgent/` two-zone model and maintenance proposals loop.

**Readiness:** 1.2A export at `Phases/1.2A/Export/`. **2.1** hygiene complete; export mirror at `Phases/2.1/Export/Project/` + `Prompts/Build-Prompt.md`. Ready for shootout (zip optional).

---

## Recent Structural Changes (2026-06-26)

| Change | Detail |
|--------|--------|
| Canonical tree | Five root folders: `Archive/`, `Core/`, `Ideas/`, `Phases/`, `Records/` |
| Retired | `Research/`, top-level `Logs/`, `Handoff/`, `Projects/`, top-level `Export/` |
| Phases layout | `Phases/{id}/Project/` + `Phases/{id}/Export/` (1.2A and 2.1 aligned) |
| 2.1 prep | Decisions, Plans, Guidance under `Phases/2.1/Project/`; preflight at phase root |
| Item 4 | `Archive/Research-import/` deduped; phase history → `Records/Phases/` |

---

## Workspace Boundary

| This repo (`fortress-design`) | External build project |
|-------------------------------|------------------------|
| Doc authoring & tightening | Implementation (src/, tests/) |
| `Phases/{id}/Project/` source of truth | Receives export copy or zip |
| `Phases/{id}/Export/` shootout packages | Agents run build prompt there |
| `Records/Logs/` session trail | Build reports synced back |

---

## Process Changes

- **2026-06-26:** Full structure migration (Passes 0–4). See `Records/Logs/Fortress-Structure-Migration-Pass0-3-2026-06-26.md`.
- **2026-06-23:** Charter + Experiments vs Phases in `PROCESS.md`.

---

## Next Steps

1. Plan-mode or read-through on `Phases/2.1/Project/`
2. Fix 2.1 PLUGIN `adr/` → tensions paths; update `Builds/README.md`
3. Refresh `Phases/2.1/Export/` when Director ready for shootout
4. Phase 2.2 exploration stays in `Phases/2.2/` (not promoted)