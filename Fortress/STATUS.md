# Fortress Status — Living Project State

**Purpose:** Current snapshot without chat memory.  
**Workspace role:** `fortress-design` is **documentation and export prep only**. Builds run in a **separate project** — not in this repo.

**Last Updated:** 2026-06-21

---

## Current Overall State

**Phase:** Phase 1.2A live export + **Ribosome Experiment 06** (DI-pattern docs) handed to Research for review

**Goal:** Agent-facing documentation tight enough for a low-supervision build **in the external build workspace**; Exp06 tests whether plugin-shaped mRNA reduces Era B invention vs composite stubs.

**Current Readiness:** **Phase 1.2A export ready** (unchanged). **Exp06:** plan-mode review complete (`blocked`, 8/10 executability); Research received report; steward review pending (days). Era C shootout **not** started.

---

## Workspace Boundary

| This repo (`fortress-design`) | External build project |
|-------------------------------|------------------------|
| Doc authoring & tightening | Implementation (src/, tests/) |
| `Fortress/Project/` source of truth | Receives export zip or Project copy |
| `Fortress/Export/` packages | Agents run `Build-Prompt.md` there |
| `Fortress/Research/` human thinking | Build reports written back or synced |

---

## Resolved Issues (2026-06-20 doc fix pass)

| # | Issue | Resolution |
|---|-------|------------|
| 1 | `ExecuteAsync` / `IsVisible` conflicts | Fixed in `AGENTS.md`, `CODING_DESIGN.md`, `ARCHITECTURE.md` ADR-001 |
| 2 | Handler inventory missing | `.docs/HANDLER_INVENTORY.md` — 11 MVP handlers |
| 3 | SQLCipher / Argon2id unspecified | `ARCHITECTURE_SECURITY.md` Implementation Specification |
| 4 | Folder diagram conflict | `ARCHITECTURE.md` — all under `Components/` |
| 5 | Interface contracts missing | `CODING_DESIGN.md` full contracts |
| 6 | `PHASE_1_1_IMPROVEMENTS.md` thin | Expanded with checklist and deviation template |
| 7 | `EvaluationCriteria.md` insufficient | Expanded with evidence bar and rubric |
| 8 | `.docs/` read-only vs build reports | `AGENTS.md` Rule 5 exception for `.docs/Builds/` |
| 9 | `Build-Prompt.md` was wrong file | Real Phase 1.2A build prompt in `Export/Phase 1.2A/Prompts/` |

---

## Remaining Open Issues (Priority 2 — not blocking export)

| Issue | Severity | Notes |
|-------|----------|-------|
| `CODING_STANDARDS.md` still high-level | Medium | No measurable thresholds yet |
| Bootstrapping "outside Component pattern" note in `ARCHITECTURE.md` | Low | Diagram now shows `Components/Bootstrapping/` |
| `BUILD_CARTOGRAPHY.md` not in Project | Low | Post-build artifact — created in **build project** after first build |
| `PROCESS.md` duplicate export sections | Low | Cleanup deferred |
| Data vs Actions model ownership | Low | Both reference `IItem`; workable but could clarify |

---

## Project File Inventory (`Fortress/Project/`)

```
AGENTS.md
AgentGamification.md
BuildDisclosure.md
README.md
Evaluation/EvaluationCriteria.md
.docs/
  ARCHITECTURE.md
  ARCHITECTURE_SECURITY.md
  CODING_DESIGN.md
  CODING_STANDARDS.md
  HANDLER_INVENTORY.md
  Phases/PHASE_1_1_IMPROVEMENTS.md
  Builds/README.md
```

No `src/` or `tests/` — expected. Code is built externally.

---

## Export Status

**Package:** `Fortress/Export/Phase 1.2A/`  
**Zip:** `Fortress-Phase1.2A-Updated-2026-06-20.zip` (see Export folder)  
**Contents:** Full `Project/` copy (includes `BuildDisclosure.md`) + `Prompts/` (`Build-Prompt.md`)

**Build workflow (mandatory order):**
1. Build via `Build-Prompt.md` → codebase + tests
2. Part 1 build-report sections → `.docs/Builds/BUILD-REPORT-YYYY-MM-DD-XXX-{Agent}.md`
3. **Build Disclosure** (final step) → Part 2 sections in the **same file** per `BuildDisclosure.md`

---

## Ribosome Experiment 06 (2026-06-21)

| Item | Path |
|------|------|
| Research tree | `Fortress/Research/Ribosome/Experiments/006/` |
| Shootout zip | `Fortress/Research/Ribosome/Experiments/Experiment-06-DI-Pattern-Documentation-2026-06-21.zip` |
| Plan-mode report | `006/Builds/BUILD-REPORT-2026-06-21-001-GrokBuild.md` |
| Session log | `Fortress/Logs/Daily-Work-Summary-2026-06-21-2239.md` |

**Next (after steward review):** Era C 3-agent shootout; assign build root outside `fortress-design`.

**Local only (not in git):** `_tmp/experiment-06-staging/` — zip rebuild workspace; regenerate from zip extract if deleted.

---

## What Happens Next (outside this repo)

1. Copy or unzip export into the **build project**
2. Run **Build** using `Build-Prompt.md`
3. Agent completes combined report (Part 1 + Part 2 Build Disclosure) per `BuildDisclosure.md`
4. Return `BUILD-REPORT-YYYY-MM-DD-XXX-{Agent}.md` to **fortress-design** for steward analysis
5. Feed doc improvements back here based on disclosure findings

---

## Process Changes

**2026-06-21** — Added `Fortress/Logs/` for dated session summaries and decision records. Documented in `PROCESS.md` and `README.md`.

---

## Maintenance Log

**2026-06-20 (AM)** — Initial STATUS, Rules 10/11, stub fixes.  
**2026-06-20 (PM)** — Full Priority 1 doc fix pass (Steps 1–10). STATUS refreshed. Export package prepared. Builds explicitly scoped to external project.  
**2026-06-20 (PM+)** — `BuildDisclosure.md` added; `AGENTS.md` Rule 12 links post-build disclosure as mandatory final step. Export zip refreshed.  
**2026-06-21** — Ribosome Exp06 package + plan-mode report; Research handoff; `Logs/` introduced; commit-ready (exclude `_tmp/`).