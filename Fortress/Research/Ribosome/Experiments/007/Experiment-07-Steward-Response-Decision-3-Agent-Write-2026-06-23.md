# Steward Response — Decision 3: Agent Write Boundaries

**Date:** 2026-06-23  
**In response to:** [007/Decision-3-Agent-Write-Boundaries-Report-for-Steward-2026-06-23.md](Decision-3-Agent-Write-Boundaries-Report-for-Steward-2026-06-23.md)  
**Builds on:** [Decision 1](Experiment-07-Steward-Response-Decision-1-Tensions-2026-06-23.md), [Decision 2](Experiment-07-Steward-Response-Decision-2-Registry-2026-06-23.md)  
**Audience:** Research / Director (Mr. Bear)  
**Posture:** **Accept** — structural separation; **Director final call** locks `.documents/` + `.codingAgent/` (see [Director Final Call](Experiment-07-Director-Final-Call-Decisions-1-2-3-2026-06-23.md))

---

## 1. Executive Summary

**Yes to separation of concerns.** Build agents are **sensors**, not co-authors of `tensions/`, `strategies/`, or REGISTRY.

**Yes to a physical agent workspace** — policy-only "don't edit" is fragile; Research is right.

**Director final call (2026-06-23):** Research names are authoritative — **`.documents/`** + **`.codingAgent/`**. Steward deferral and `agent-workspace/` preference superseded on naming only.

Maintenance Proposals table in the **combined BUILD-REPORT stays mandatory** — `.codingAgent/` supplements it; it does not replace it.

---

## 2. Agreed Governance Model

```
.documents/          ← authoritative (steward promotes into)
  CORE.md, COMPONENTS.md, REGISTRY.md, tensions/, strategies/,
  process/, quality/, components/*/PLUGIN.md

.codingAgent/        ← agent drafts (steward reviews)
  proposals/, notes/, feedback/

Builds/              ← combined report + cartography (mandatory table + artifacts)
```

**Hard rules:**

1. Agents **never** create or edit files under authoritative trees except **`Builds/`** (combined report + cartography per existing Rule 5/12).
2. Agents **may** write draft artifacts under **`agent-workspace/`** when a proposal is too large for a table row (e.g. full draft Tension Record for steward consideration).
3. **Promotion** — only steward (or Director) moves content from `agent-workspace/` → `tensions/`, `strategies/`, etc.
4. **Shootout copies** — external build roots accumulate agent-workspace junk; steward curates from **BUILD-REPORT + zip post-mortem**, not live sync of every shootout folder.

---

## 3. Director Naming (Final)

| Folder | Owner | Director call |
|--------|-------|---------------|
| **`.documents/`** | Steward (authoritative) | **Locked** — Research naming |
| **`.codingAgent/`** | Agents draft; steward promotes | **Locked** — Research naming |

Exp06 flat layout and `Project/1.2A` `.docs/` remain historical; **Phase 2.1 prototype uses `.documents/`** as the authoritative root wrapper.

---

## 4. Relationship to Maintenance Proposals Table

**Both** channels, not either/or:

| Channel | When to use |
|---------|-------------|
| **BUILD-REPORT table** | Default — every maintenance signal; scannable across shootouts |
| **`.codingAgent/`** | When steward needs a **draft artifact** (full proposed tension, strategy sketch, REGISTRY patch proposal) |

Agents should not skip the table because a file exists in workspace. Table row can point to: `See .codingAgent/proposals/T-0007-draft.md`.

This preserves Era C report discipline while giving Research the low-friction space they want.

---

## 5. AGENTS.md Rule 5 (Prototype Wording)

Replace implicit read-only with explicit two-zone model:

```markdown
**`.documents/`** — read-only during builds (authoritative)

**Agent-writable:**
  Builds/         — combined report, cartography (mandatory)
  .codingAgent/   — draft proposals only; never authoritative
```

Code (`src/`, `tests/`) remains writable per normal build rules in the external shootout root.

---

## 6. Decision Status

| Item | Status |
|------|--------|
| Agents are sensors, not doc co-authors | **Closed — agreed** |
| Physical separation beats policy alone | **Closed — agreed** |
| Steward promotion workflow | **Closed — agreed** |
| `.documents/` + `.codingAgent/` names | **Closed — Director locked** |
| BUILD-REPORT table still required | **Closed — agreed** |

**All three pre-implementation decisions** from REVISED §4 are now steward–Research aligned (Decision 1 tensions, Decision 2 REGISTRY split, Decision 3 write boundaries).

Prototype fork may proceed when **Director** agrees timing.

---

## 7. Closing

Research's structural proposal is adopted with **Director naming**. Next at fork: scaffold `.documents/` and `.codingAgent/`, update `process/AGENTS.md` Rule 5, extend Maintenance Proposals types from Decision 1 §3.6.

---

*Prepared for Research handoff. Steward / build-side perspective.*