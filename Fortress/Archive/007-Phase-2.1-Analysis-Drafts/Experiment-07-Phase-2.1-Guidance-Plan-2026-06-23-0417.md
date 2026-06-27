# Experiment 07 — Phase 2.1 Guidance Plan

**Date:** 2026-06-23  
**Status:** Draft for internal review  
**Tone:** Contemplative, thinking-partner posture

---

## 1. Purpose of This Document

This document prepares guidance for **Phase 2.1** of the Fortress documentation architecture. Its role is not to design the final structure, but to help the Steward think clearly about how to evolve Experiment 06 using the Strategy Pattern and Seams thinking developed in prior work.

We operate as **thinking partners who initiate**. We bring forward clear positions and recommendations while deliberately surfacing real tensions, trade-offs, and open questions. We do not hand over finished answers.

---

## 2. Core Posture

We recommend treating the documentation system as a set of **recipes, ingredients, and connectors**:

- **Recipe** files define the general rules and philosophy for a domain.
- **Ingredient** files contain the specific, executable details.
- **Connector** files link the general guidance to the specific implementations without overloading the recipe layer.

This pattern is still a working hypothesis. We are testing it rather than declaring it complete.

---

## 3. What We Are Trying to Solve

Experiment 06 introduced a cleaner plugin model than Experiment 05, but several cross-cutting concerns remain either implicit or scattered. The goal of Phase 2.1 is to make the most important seams and strategies more visible and maintainable without recreating the fragmentation of Experiment 05.

---

## 4. Structural Recommendations

### 4.1 Seams

We recommend introducing a dedicated `seams/` folder under `.docs/`.

A seam should earn its own file when it meets at least two of the following:
- It is genuinely cross-cutting.
- It has already produced measurable invention or divergence.
- It is likely to recur.
- Hiding it has created confusion or drift.

We distinguish between **seams** (system boundaries and risk points) and **strategies** (selectable behaviors). While they sometimes overlap, conflating them tends to blur responsibility.

**Questions for the Steward:**
- Does the proposed threshold feel right, or is it too loose or too strict?
- How should `seams/` relate to `adr/` over time?
- What is the minimum viable content for a seam file?

### 4.2 Strategies

We recommend treating **strategies** as a distinct but related category to seams.

A strategy is a named, selectable approach to solving a recurring problem. Unlike a seam (which marks a point of tension or ambiguity), a strategy represents a deliberate choice about *how* something should be done when multiple reasonable approaches exist.

**Why this matters:**

Many of the invention patterns observed in earlier experiments were not caused by missing contracts, but by missing clarity about *which strategy* should be used in a given situation. When strategies remain implicit, different agents (or even the same agent on different days) make different choices. Making strategies explicit reduces this variance while still preserving the ability to evolve the chosen approach over time.

**Concrete examples relevant to Fortress:**

- **Disclosure Strategy**: How much invention should be surfaced in build reports, and in what format? (One-file combined report vs. separate reasoning files.)
- **Save Strategy**: Full-table rewrite vs. incremental updates vs. change tracking.
- **Visibility Strategy**: How `IsVisible()` logic should be distributed between handlers and context.
- **Error Handling Strategy**: Whether to use guard clauses aggressively, centralized exception handling, or per-handler recovery.

**Why explicit strategy documentation works well:**

- It makes trade-offs visible rather than forcing agents to rediscover them.
- It supports the Open/Closed principle — new strategies can be added without modifying core contracts.
- It creates a natural home for the “why” behind a decision, which is often lost when only the final implementation is documented.
- It reduces the risk of convergent invention on high-impact behavioral choices.

We do **not** recommend creating a strategy file for every minor variation. A strategy should earn its own documentation when the choice has recurring impact across components or when hiding the decision has already produced divergence.

**Questions for the Steward:**
- Which current behavioral choices in the system feel most in need of explicit strategy documentation?
- Should strategies live alongside seams in a shared folder, or should they have their own structure?
- How do we prevent the creation of strategy files from becoming another source of low-value documentation?

### 4.3 REGISTRY.md (Connector Layer)

We recommend creating `components/REGISTRY.md` as the primary connector between `COMPONENTS.md` (the general recipe) and the individual `PLUGIN.md` files (the specific ingredients).

**Minimum viable content for `components/REGISTRY.md` (initial version):**

- A clear statement of the component load order and its rationale.
- A lightweight inventory of all current plugins with their dependencies.
- Registration rules (how and where handlers and services must be registered).
- Quality expectations that apply across components (validation, testing, deviation reporting).
- Cross-references to relevant seams and strategies that affect multiple components.

The goal is to keep this file minimal but meaningful. It should not duplicate content that properly belongs in `COMPONENTS.md` or in individual plugins.

---

## 5. An Emerging Pattern: Recipe, Ingredients, and Connector

We are testing a consistent structural pattern: `COMPONENTS.md` as the general recipe, `PLUGIN.md` files as specific ingredients, and `REGISTRY.md` as the connector.

This pattern improves inferability. When applied consistently, both humans and build agents can more readily understand how the documentation system works without re-learning the logic for every new area.

We are not yet confident this pattern should be applied broadly or reflexively. It should be used where it demonstrably reduces invention or improves clarity, not because the pattern exists.

---

## 6. What to Carry Forward from Experiment 05

Experiment 05 correctly identified that some concerns deserve to be treated as explicit, composable structures. Its failure was applying this idea at too fine a grain.

Using the recipe model, the insight worth carrying forward is this:

- The **general recipe** is that certain cross-cutting concerns benefit from being named and treated as first-class elements.
- The **specific ingredients** are the actual seams, strategies, and exception cases that meet a meaningful threshold.
- The **connector** is the judgment process we use to decide when something deserves its own structure.

We should apply this discipline at a coarser grain than Experiment 05. A concern should earn its own file only when the cost of keeping it implicit is higher than the cost of giving it structure. This is **intentional granularity**, not minimalism for its own sake.

---

## 7. Tone and Posture

This document is deliberately contemplative. We offer clear positions while raising substantive questions. Our goal is to help the Steward think, not to hand over a completed design.

---

## 8. Open Questions Worth Holding

These questions are grounded in the specific proposals made in this document:

- Using the Recipe + Ingredients + Connector model, where should the line be drawn between what lives in `COMPONENTS.md`, what lives in `REGISTRY.md`, and what lives in individual `PLUGIN.md` files?
- What is the true minimum viable content for `components/REGISTRY.md` so that it functions as a useful connector rather than becoming another document agents learn to skip?
- For both `seams/` and a potential strategies structure, what decision rule should we use to determine when something earns its own file, and how do we prevent that structure from growing faster than its value?
- If we introduce `seams/`, strategies, and `REGISTRY.md`, how do we keep the overall system from drifting back toward the fragmentation seen in Experiment 05?
- What would “success” in Phase 2.1 actually look like after the next build round? Fewer undocumented assumptions? Higher component fidelity? Clearer handling of seams and strategies? Something else measurable?

---

## 9. Proposed Next Steps for Phase 2.1

1. Define the minimum viable `components/REGISTRY.md`.
2. Prototype 2–3 seam files using the proposed decision criteria.
3. Prototype 1–2 strategy files with concrete examples.
4. Update `COMPONENTS.md` with light references to `REGISTRY.md` and the new structures.
5. Run a build round and measure against the success signals below.

---

## 10. Success Measures for Phase 2.1 (Proposed)

We suggest tracking the following signals after the first build round that uses the new structures:

- Reduction in undocumented assumptions or inventions appearing in build reports (especially around seams and behavioral choices).
- Improved consistency in how components are registered and validated.
- Clearer handling of cross-cutting concerns (measured by whether build agents can articulate the strategy or seam without re-deriving it).
- Whether the new structures (seams, strategies, REGISTRY.md) are actually referenced in build reports and disclosures, rather than ignored.
- Steward and agent feedback on whether the documentation feels more coherent or more fragmented.

These measures are starting points. They should be refined after we see how the structures actually behave in practice.

---

*End of document*