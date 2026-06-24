# Director Final Call — Experiment 07 Decisions 1–3

**Date:** 2026-06-23  
**Authority:** Director (Mr. Bear)  
**Audience:** Research, Steward  
**Status:** **Closed** — proceed to prototype planning on these terms

---

## Summary

All three pre-implementation decisions from Phase 2.1 REVISED guidance are **final**. Research may treat this document as the handoff authority; steward responses remain the reasoning record.

---

## Decision 1 — Tensions (not `seams/` + `adr/`)

| Item | Final call |
|------|------------|
| Structure | Unified **`tensions/`** — Open / Resolved / Deprecated |
| `strategies/` | **Separate** folder (not folded into tensions) |
| Exp06 `adr/` | Migrate to Resolved tension records in prototype; no dual live trees |
| Prototype cap | Max **3** open tensions + **2** strategies (Proposed/Open) |

**Steward:** Accepted with guardrails — [Experiment-07-Steward-Response-Decision-1-Tensions-2026-06-23.md](Experiment-07-Steward-Response-Decision-1-Tensions-2026-06-23.md)

---

## Decision 2 — REGISTRY vs COMPONENTS

| Item | Final call |
|------|------------|
| **`COMPONENTS.md`** | Pattern, stack, Open/Closed, **PLUGIN.md contract** (recipe) |
| **`REGISTRY.md`** | Inventory, load order, dependency map, plugin + tension/strategy links (connector) |
| Contract location | **Stays in COMPONENTS** — not moved to REGISTRY |

**Steward:** Agreed — [Experiment-07-Steward-Response-Decision-2-Registry-2026-06-23.md](Experiment-07-Steward-Response-Decision-2-Registry-2026-06-23.md)

---

## Decision 3 — Agent write boundaries

| Item | Final call |
|------|------------|
| Principle | Agents are **sensors**; steward **promotes** into authoritative docs |
| Physical split | **Two folders** — not policy-only read-only |
| Authoritative tree | **`.documents/`** (Director naming; Research origin) |
| Agent workspace | **`.codingAgent/`** (Director naming; Research origin) |
| BUILD-REPORT | **Documentation Maintenance Proposals** table remains **mandatory** when non-empty |
| Promotion | Steward reviews `.codingAgent/` + reports; promotes into `.documents/` |

### `.documents/` contents (authoritative)

`CORE.md`, `COMPONENTS.md`, `components/REGISTRY.md`, `tensions/`, `strategies/`, `components/*/PLUGIN.md`, `process/`, `quality/`, and related steward-owned doc roots — **read-only for build agents**.

### `.codingAgent/` contents (agent-writable)

Draft proposals, tension/strategy sketches, extended feedback — **never authoritative** until promoted.

### `Builds/`

Combined build report and post-build artifacts per existing Rule 5/12 — agent-writable; not a substitute for the Maintenance Proposals table.

**Director overrides** steward deferral of `.documents/` rename and `agent-workspace/` naming — [Decision 3 steward draft](Experiment-07-Steward-Response-Decision-3-Agent-Write-2026-06-23.md) superseded on names only.

---

## Layout sketch (Phase 2.1 prototype)

```
{project root}/
├── AGENTS.md
├── Builds/
├── .documents/          ← authoritative (steward promotes into)
│   ├── CORE.md
│   ├── COMPONENTS.md
│   ├── components/
│   │   ├── REGISTRY.md
│   │   └── */PLUGIN.md
│   ├── tensions/
│   ├── strategies/
│   ├── process/
│   └── quality/
└── .codingAgent/        ← agent drafts (steward reviews)
    ├── proposals/
    ├── notes/
    └── feedback/
```

Exact nesting inside `.documents/` may follow Exp06 fork mapping; **folder names `.documents` and `.codingAgent` are not negotiable** for this prototype.

---

## What Research should do next

1. Acknowledge this final call (brief reply or REVISED-2 patch optional).
2. Publish **minimum viable Tension Record** template + Maintenance Proposals row types (if not already in flight).
3. Support steward **Exp07 prototype fork** when scheduled — apply Decisions 1–3 and Director naming.

No further steward review required on these three decisions unless Research identifies a **blocking** conflict with executable builds.

---

## Prototype fork

**Cleared to plan.** Timing at Director discretion. Promote to `Fortress/Project/2.1/` per `PROCESS.md` when prototype is build-ready.

---

*Director final call — for Research handoff.*