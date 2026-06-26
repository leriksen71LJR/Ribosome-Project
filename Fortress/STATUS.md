# Fortress Status — Living Project State

**Purpose:** Current snapshot without chat memory.  
**Workspace role:** `fortress-design` is **documentation and export prep only**. Builds run in a **separate project**.

**Last Updated:** 2026-06-26

---

## Current Overall State

**Phase:** **1.2A** default export (frozen under `Projects/1.2A/`). **2.1** scaffolded under `Projects/2.1/` (Exp06 fork + tensions/REGISTRY split).

**Goal:** Train Director via agent shootouts; Phase 2.1 tests `.documents/` / `.codingAgent/` two-zone model and maintenance proposals loop.

**Readiness:** 1.2A export unchanged (`Export/Phase 1.2A/Project/`). **2.1** ready for plan-mode read-through; shootout zip not yet generated.

---

## Recent Structural Changes (2026-06-26)

| Change | Detail |
|--------|--------|
| Rename | `Fortress/Project/` → `Fortress/Projects/` |
| 1.2A | Nested at `Projects/1.2A/` — **internals untouched** |
| 2.1 | Scaffolded from Exp06 — `.documents/`, `.codingAgent/`, tensions, strategies, REGISTRY |
| Exp07 | Decisions 1–3 **closed** (Director final call) |
| Exp08 | Phase 2.2 exploration only — **not promoted** |

---

## Workspace Boundary

| This repo (`fortress-design`) | External build project |
|-------------------------------|------------------------|
| Doc authoring & tightening | Implementation (src/, tests/) |
| `Fortress/Projects/` source of truth | Receives export zip or Projects copy |
| `Fortress/Export/` packages | Agents run build prompt there |
| `Fortress/Research/` human thinking | Build reports synced back |

---

## Process Changes

- **2026-06-26:** Projects container rename + 2.1 scaffold. See `Logs/Projects-Rename-and-Repo-Hygiene-2026-06-26.md`.
- **2026-06-23:** Charter + Experiments vs Phases in `PROCESS.md`.

---

## Next Steps

1. Plan-mode or small read-through on `Projects/2.1/`
2. Generate `Export/Phase 2.1/` zip when Director ready
3. Phase 2.2 remains Research-only (Exp08)