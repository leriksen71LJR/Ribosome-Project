# Preflight — Phase 2.1

**Verdict:** Ready with conditions  
**Date:** 2026-06-26  
**Runner:** Steward  
**Summary:** Structure and decisions are in place; PLUGINs still cite dead `adr/` paths and export mirror is missing.

---

## What was checked

`Fortress/Projects/2.1/` — shootout / build-readiness before export zip or external agent handoff.

## Findings

**Good:**
- Phase root `AGENTS.md` with two-zone boundary and read order
- `.documents/` tree: CORE, COMPONENTS, REGISTRY, 6 PLUGINs, process, quality
- `.codingAgent/` scaffold (proposals, notes, feedback)
- `tensions/`: 6 Resolved + 3 Open (within cap)
- `strategies/`: 2 files (within cap)
- `BUILD-DISCLOSURE` includes Maintenance Proposals table
- Exp07 decisions reflected in layout

**Not good:**
- Six PLUGINs still reference `adr/...` paths that do not exist in 2.1 (should be `.documents/tensions/...`)
- `Builds/README.md` still says `006/`
- `Export/Phase 2.1/` is stub only — no `Projects/` mirror, no prompt, no zip
- Open tension seeds are thin (acceptable for prototype; agents will gap-report)

### Auto-check results

| Check | Result |
|-------|--------|
| `AGENTS.md` at phase root | Pass |
| `.documents/` + `.codingAgent/` + `Builds/` | Pass |
| Open tensions | Pass — 3 (0007–0009) |
| Strategies | Pass — 2 |
| Stale `adr/` in `.documents/` | **Fail** — multiple hits in PLUGINs |
| Stale `006/` | **Fail** — `Builds/README.md` |
| Export mirror | **Fail** — README only |
| Git | Info — branch ahead of remote (4 commits); clean tree |

## Blockers

- None for **plan-mode / doc read-through**
- **Shootout:** stale `adr/` refs in PLUGINs (agents will look in wrong place)

## Conditions

1. Grep-fix `adr/` → `.documents/tensions/` (or relative `../tensions/`) in all six PLUGINs
2. Update `Builds/README.md` for Phase 2.1 paths
3. Copy to `Export/Phase 2.1/Projects/` + prompt when you want a real shootout

## Questions for Director

- None — conditions are mechanical; say when to apply fixes.

## Recommended next step

Steward fixes PLUGIN `adr/` links and `Builds/README.md` (no commit unless you ask), then re-run `preflight Phase 2.1`.