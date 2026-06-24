# Steward Response — Decision 2: `REGISTRY.md` vs `COMPONENTS.md`

**Date:** 2026-06-23  
**In response to:** [007/Decision-2-Registry-vs-Components-Split-Report-for-Steward-2026-06-23.md](Decision-2-Registry-vs-Components-Split-Report-for-Steward-2026-06-23.md)  
**Depends on:** [Decision 1 — `tensions/`](Experiment-07-Steward-Response-Decision-1-Tensions-2026-06-23.md) (cross-refs in REGISTRY cite tensions, not ADRs)  
**Audience:** Research / Director (Mr. Bear)  
**Posture:** **Agree** — Research refinement matches Exp06 reality and steward intent

---

## 1. Answer to Research's Question

**Yes — `COMPONENTS.md` retains the plugin contract and core validation rules.**

Do **not** move contract text into `REGISTRY.md`. REGISTRY is a **map**, not a second rulebook.

---

## 2. Split Table (Canonical for Phase 2.1 Prototype)

| Lives in `COMPONENTS.md` (recipe) | Lives in `components/REGISTRY.md` (connector) |
|-----------------------------------|---------------------------------------------|
| Component pattern (Contracts / Implementations / Model) | Plugin inventory table (id, path, one-line role) |
| Architectural style (Strategy-by-list, IDependencyModule, dynamic menu) | **Load / registration order** (mandatory read sequence) |
| Technology stack | Dependency edges (plugin → plugin) |
| Open/Closed and "adding a plugin" **rules** | Links to each `PLUGIN.md` |
| **PLUGIN.md contract** (required headings, executable body bar) | Links to `tensions/` and `strategies/` entries that touch each plugin |
| Exception **pointers** ("see tension 0002") — one line max | `tensions/REGISTRY.md` index row or inline tension ids per plugin row |

**Rule of thumb for agents:** *How* to build a component → `COMPONENTS.md`. *What* exists, *in what order*, *what links to what* → `REGISTRY.md`.

---

## 3. Why Research's Refinement Is Correct

Exp06 `COMPONENTS.md` already does both jobs today (see lines 36–69: load-order table + PLUGIN contract in one file). That worked for plan-mode review but matches the "mixed recipe + inventory" problem Research names.

Moving **only** the load-order table, dependency map, and cross-ref columns to REGISTRY is a **surgical** split — not a new abstraction. Contract stays where agents already learn "what a valid PLUGIN looks like."

Putting contract in REGISTRY would blur connector vs recipe and invite REGISTRY bloat.

---

## 4. Minimum Viable `REGISTRY.md` (Prototype)

One screen. Suggested sections:

1. **Purpose** — "Connector only; rules live in COMPONENTS.md"
2. **Load order** — same six rows as Exp06 today (Data → … → Bootstrapping)
3. **Dependency sketch** — simple directed list or small table
4. **Plugin index** — plugin id → `PLUGIN.md` path
5. **Tension / strategy touchpoints** — optional column or footnote links (post–Decision 1)

No duplicated philosophy. No duplicate PLUGIN contract block.

---

## 5. Read-Order Change (When Fork Lands)

Update `process/AGENTS.md` mandatory path:

| Step | Document |
|------|----------|
| After `CORE.md` | `COMPONENTS.md` (pattern + contract) |
| Next | `components/REGISTRY.md` (order + map) |
| Then | plugins in REGISTRY order |
| When triggered | `tensions/REGISTRY.md` |

Directional success signal unchanged: build reports **cite REGISTRY** when stating load order or cross-plugin deps.

---

## 6. Decision Status

| Item | Status |
|------|--------|
| Split REGISTRY vs COMPONENTS | **Closed — agreed** |
| Contract stays in COMPONENTS | **Closed — agreed** |
| REGISTRY hosts inventory, order, links | **Closed — agreed** |
| MVP REGISTRY shape | Open — implement at fork (§4 above is sufficient) |

Decision 2 does not block prototype fork beyond Decision 1 and Director timing.

---

## 7. Closing

Research and Steward are aligned. No iteration needed unless the Director prefers a single-file COMPONENTS for training simplicity — if so, say so; we can defer REGISTRY to Phase 2.2 without undoing Decision 2 in principle.

---

*Prepared for Research handoff. Steward / build-side perspective.*