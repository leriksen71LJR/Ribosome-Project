# Steward Response — Phase 2.2 Custom Agents per Workflow Stage

**Date:** 2026-06-24  
**In response to:** [008/Phase-2.2-Custom-Agents-per-Workflow-Stage-Deep-Breakdown-2026-06-24.md](Phase-2.2-Custom-Agents-per-Workflow-Stage-Deep-Breakdown-2026-06-24.md)  
**Context:** Experiment 07 closed Decisions 1–3 (tensions, REGISTRY split, `.documents/` + `.codingAgent/`); Phase 2.1 prototype fork not yet started  
**Audience:** Research, Director (Mr. Bear)  
**Posture:** Thinking-partner response — positions offered, not implementation authority

---

## 1. Executive Summary

**Direction: supported as exploration; not ready for Phase promotion.**

The breakdown correctly connects custom agents to the Specification Pipeline metaphor, to controlled invention, and to the sensor/promote model from Experiment 07 Decision 3. The self-warning about Experiment 05 fragmentation is the right instinct — and should be treated as a **hard constraint**, not a footnote.

**Steward position:** Phase 2.2 is a **downstream** concern. Ship and learn from the Phase 2.1 prototype (single build agent, `.documents/` authoritative tree, `.codingAgent/` proposals) before splitting the workflow into multiple agent roles. Multi-agent specialization pays off only after handoff pain is observed in real use.

We endorse the conservative **Explorer / Strategist / Builder** trio as the starting hypothesis. We defer a fourth role (Risk Analyst, micro-stages) until a documented handoff failure forces it.

---

## 2. Charter Alignment

Fortress exists to train the **Director** in AI agent coding — briefing, reading reasoning, judging documentation, running shootouts. Phase 2.2 is **high-value Director curriculum** even before it becomes product:

| Director skill | What Phase 2.2 exercises |
|----------------|--------------------------|
| Agent brief design | Stage-specific prompts and contracts |
| Reasoning review | Comparing mental models across handoffs |
| Governance judgment | When specialization helps vs when it sprawl |
| Shootout design | One agent vs staged agent chain |

Phase 2.2 should remain in **Research/Experiments** until the Director wants a shootout that explicitly tests a multi-agent chain. It must not block Phase 2.1.

---

## 3. Alignment with Experiment 07 (Phase 2.1)

| Exp07 decision | Phase 2.2 implication |
|----------------|---------------------|
| `.documents/` authoritative | All stage agents **read** the same canon; no stage-owned truth trees |
| `.codingAgent/` agent-writable | Natural **handoff bus** between stages — proposals and drafts only |
| Agents as sensors; steward promotes | Strategist may *propose* tensions/strategies in `.codingAgent/`; never write `.documents/` directly |
| Cap 3 tensions + 2 strategies | Role-based creation must respect the same caps in prototype |
| REGISTRY as connector | Future `roles/` or stage registry should **link**, not duplicate COMPONENT contracts |

The breakdown’s §2 (`.codingAgent/` internal structure) is directionally right but **premature in folder form**. Start with a **flat** `.codingAgent/` plus naming conventions (`handoff-explorer-to-strategist.md`, `proposal-strategy-*.md`). Introduce subfolders only when file count or collision pain justifies it — same earn-your-folder rule as tensions.

---

## 4. Strong Agreement

### 4.1 Specification Pipeline as specialization driver

Stages as translation steps (inputs, outputs, invariants, failure modes) is the correct abstraction. It matches PROCESS.md’s Reasoning Disclosure → Analysis → Build cycle without requiring one agent per micro-step.

### 4.2 Controlled invention gates

Stage boundaries are a practical way to implement “invention is allowed here, forbidden there” without bloating `AGENTS.md`. The **Strategist** stage is the natural home for strategy proposals; the **Builder** should default to gap-reporting, not ontology expansion.

### 4.3 Exp05 fragmentation warning

Treating multi-agent specialization like Exp05’s fine-grained Workflow/Seams trees would recreate navigation debt. **Few agents, coarse stages, explicit handoff artifacts** — not one agent per pipeline diagram box.

### 4.4 Three-agent conservative start

| Agent | Scope (steward refinement) | Writes |
|-------|------------------------------|--------|
| **Explorer** | Discovery + analysis, gap surfacing, REASONING disclosure | `.codingAgent/` only |
| **Strategist** | Tension/strategy proposals, conflict resolution drafts | `.codingAgent/` only |
| **Builder** | Implementation + validation, BUILD-REPORT + Maintenance Proposals | `Builds/`, `.codingAgent/` |

Do **not** add Risk Analyst until Explorer + Strategist fail to surface tensions reliably in practice.

### 4.5 Steward role evolution

Curating **stage contracts** alongside documentation is consistent with charter.steward as process curator — but scope should stay **lightweight**: one `ROLE.md` or section per agent, not parallel doc forests.

---

## 5. Concerns and Guardrails

### 5.1 Active agency vs sensor model (§6)

“A Strategist Agent proposes strategies” and “Risk Analyst surfaces tensions” are attractive — but they conflict with Exp07’s **sensor/promote** principle if implemented as direct writes to authoritative docs.

**Guardrail:** Role-based agency means **mandated proposal duty** in `.codingAgent/` and build reports — not autonomous promotion. Steward and Director retain promotion into `.documents/`.

### 5.2 Handoff complexity

Each additional agent adds: prompt surface, context loss risk, incompatible assumptions, and export/shootout packaging questions (one zip vs three prompts?).

**Guardrail:** First multi-agent experiment should be **manual chain** (Director runs Explorer → pastes handoff → runs Strategist → …) before any automation or orchestration tooling.

### 5.3 Mental model drift (Open Question 3)

Mitigations without new infrastructure:

- Shared read-only anchor: `.documents/CORE.md` + `COMPONENTS.md`
- Required handoff artifact template in `.codingAgent/` (assumptions carried forward, open gaps, rejected alternatives)
- Build report as **reconciliation** step — Builder cites which proposals were honored vs overridden

### 5.4 Sequencing risk

Phase 2.2 doc structure (subfolders in `.codingAgent/`, role registries) could tempt implementation **before** Phase 2.1 proves the two-folder split with a **single** build agent.

**Guardrail:** No Phase 2.2 folder under `Fortress/Project/` until Phase 2.1 has at least one shootout or plan-mode pass with Maintenance Proposals flowing correctly.

---

## 6. Responses to Open Questions

| # | Question | Steward position |
|---|----------|------------------|
| 1 | Minimum viable agent set | **Three:** Explorer, Strategist, Builder. Merge Discovery+Analysis and Implementation+Validation as proposed. |
| 2 | Explicit vs organic role docs | **Explicit but thin** — analogous to `PLUGIN.md`: one role contract per agent (`roles/EXPLORER.md` or section in `process/`), linked from `REGISTRY.md` when Phase 2.2 ships. Not organic sprawl. |
| 3 | Incompatible mental models | Shared canon + handoff template + build reconciliation; optional Director review between stages during training. |
| 4 | New steward tooling | **Not yet.** Extend existing patterns (REGISTRY links, Maintenance Proposals table, log entries). Revisit if role count exceeds three or handoffs become weekly. |

---

## 7. Suggested Next Steps (Non-Blocking)

1. **Director:** Finish Project reorg and Phase 2.1 prototype fork per [007/Experiment-07-Director-Final-Call-Decisions-1-2-3-2026-06-23.md](../007/Experiment-07-Director-Final-Call-Decisions-1-2-3-2026-06-23.md).
2. **Research:** If Phase 2.2 continues, draft a **Handoff Contract** one-pager (inputs/outputs per stage) — no new folders.
3. **Steward:** Add Phase 2.2 as **planned** in `Project/PHASES.md` when Director agrees; keep experiment in `008/`.
4. **First multi-agent trial:** Manual three-stage chain on a **small** doc change after one successful Phase 2.1 single-agent build.

---

## 8. Verdict

| Item | Steward call |
|------|--------------|
| Exploration quality | **Strong** — non-obvious connections are well argued |
| Exp05 risk awareness | **Adequate** — must stay primary design constraint |
| Ready for Steward review (original doc) | **Now addressed** — this response |
| Ready for Phase promotion | **No** — depends on Phase 2.1 learnings |
| Ready for Director decision | **Optional** — Director may acknowledge direction; no fork required yet |

Phase 2.2 is worth pursuing as **Director training material** and a **future phase hypothesis**. Resist specialization until handoff pain is real.

---

## Related

| Item | Path |
|------|------|
| Phase 2.2 exploration | [008/Phase-2.2-Custom-Agents-per-Workflow-Stage-Deep-Breakdown-2026-06-24.md](Phase-2.2-Custom-Agents-per-Workflow-Stage-Deep-Breakdown-2026-06-24.md) |
| Exp07 Director final call | [007/Experiment-07-Director-Final-Call-Decisions-1-2-3-2026-06-23.md](../007/Experiment-07-Director-Final-Call-Decisions-1-2-3-2026-06-23.md) |
| Experiments index | [Experiments/README.md](../README.md) |