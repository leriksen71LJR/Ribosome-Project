# Experiment 07 — Phase 2.1 Guidance Plan

**Date:** 2026-06-23  
**Type:** Research + Planning Document (Guidance for Steward)  
**Focus:** Evolving Experiment 06 through deliberate Strategy Pattern and Seams integration — Phase 2.1

---

## 1. Purpose of Experiment 07

This experiment exists to define how Research should guide the Steward in shaping **Phase 2.1**.

We are not here to build the documentation. We are here to do the hard thinking first — to surface what matters, what is at stake, and what choices are worth wrestling with — so the Steward can engage with clarity rather than inherited assumptions.

The core question this document addresses is:

> How do we evolve the Experiment 06 architecture so that Strategy Pattern thinking and seam visibility become more intentional and visible, without sacrificing the structural clarity and fidelity that Experiment 06 achieved?

---

## 2. Posture: Thinking Partners Who Initiate

We approach this work as **thinking partners who initiate**.

This means:
- We take responsibility for framing the real problems and tensions.
- We bring forward our current best thinking and recommendations, along with the reasoning behind them.
- We deliberately leave space for the Steward to engage critically, rather than handing over finished answers.
- We treat guidance as an act of collaboration, not transmission.

This posture is intentional. It exists because the quality of Phase 2.1 will depend as much on *how* the Steward thinks about these issues as it will on any specific structural decision we recommend.

---

## 3. What We Are Trying to Protect and Improve

Experiment 06 made meaningful progress. It raised fidelity and reduced fragmentation compared to Experiment 05. At the same time, it made **Strategy Pattern** more implicit and **seam visibility** lower.

Phase 2.1 should not abandon what Experiment 06 achieved. It should strengthen what was weakened.

The central tension is this:

> How do we make Strategy Pattern and Seams handling more explicit and actionable, while preserving the navigability and executable clarity that Experiment 06 established?

This tension should sit at the center of the Steward’s thinking as they evaluate any proposed changes.

---

## 4. Recommended Structural Direction

### 4.1 Seams

We recommend treating seams as first-class, visible structures.

Our current position is that a dedicated `seams/` folder under `.docs/` is worth introducing. Seams are not merely decisions to be recorded; they are recurring points of friction, ambiguity, and invention risk. Making them visible as a distinct category of documentation improves both human comprehension and build agent reliability.

A seam file should exist when the concern meets at least two of the following criteria:
- It is genuinely cross-cutting (affects multiple components or processes).
- It has already produced measurable invention or divergence in previous builds.
- It is likely to recur and benefit from consistent handling over time.
- Hiding it inside a component plugin or ADR has created confusion or drift.

We see a useful distinction between **seams** and **strategies**. A seam is a system boundary or known risk point. A strategy is a selectable behavior or approach. While they sometimes overlap, conflating them tends to blur responsibility.

**Questions for the Steward:**
- Does the proposed decision criteria above feel like the right threshold for creating a seam document, or is it too loose / too strict?
- How should `seams/` relate to `adr/` over time? Should every seam eventually graduate to an ADR once a decision is made, or should some seams remain as living documentation?
- What is the minimum viable content for a seam file so it adds clarity without becoming ceremony?

### 4.2 COMPONENTS.md, PLUGIN.md, and REGISTRY.md

We see three distinct but related roles:

- **COMPONENTS.md** acts as the **general recipe**. It should articulate the expectations and processes that apply to all components — how they should be validated, built, verified, and tested. It defines the *how* of working with components at a general level.
- **PLUGIN.md** files contain the **specific ingredients and particulars** for each individual component. They are the executable detail.
- **REGISTRY.md** (proposed new file under `components/`) serves as the **connector**. It links the general expectations in `COMPONENTS.md` to the specific implementations in each `PLUGIN.md`.

This separation keeps `COMPONENTS.md` from becoming overloaded while giving it clear responsibility for defining the standards and processes that all plugins should follow.

**Recommended direction:**
- Keep `COMPONENTS.md` stable in its core purpose as the high-level recipe.
- Introduce a minimal `components/REGISTRY.md` that maps how individual plugins relate to the general expectations.
- Move or clarify guidance around plugin validation, building, verifying, and unit testing into `COMPONENTS.md` (or clearly delegate it through the REGISTRY).
- Keep `PLUGIN.md` files focused on the concrete, component-specific work.

**Questions for the Steward:**
- How much of the "general recipe" (validation, testing expectations, build process) should live directly in `COMPONENTS.md` versus being referenced from `REGISTRY.md`?
- What is the minimal useful content for `REGISTRY.md` so it actually connects the two layers without becoming another document agents must read?
- How do we prevent `COMPONENTS.md` from drifting into either being too vague or too prescriptive as it takes on responsibility for the general recipe?

---

## 5. An Emerging Pattern: Recipe, Ingredients, and Connector

As we have worked through the structural questions in this document, a simple pattern has begun to surface:

- **COMPONENTS.md** functions as the **general recipe** — the overarching expectations, processes, and standards that apply across all components.
- **PLUGIN.md** files function as the **specific ingredients and particulars** — the concrete, component-level detail.
- **REGISTRY.md** (proposed) functions as the **connector** — the lightweight layer that links the general recipe to the specific implementations.

This pattern is appealing because humans (and build agents) tend to infer structure more easily when similar relationships appear consistently. If this model holds, people may more readily understand how different parts of the documentation system relate to one another without needing to re-learn the logic in every new area.

**However, we are not yet confident this pattern should be applied broadly.**

**Risks we see:**
- It could introduce more documents than necessary if applied too eagerly.
- It might create a false sense of uniformity where the underlying concerns are actually quite different (seams vs components vs quality mechanisms).
- Over-applying any single pattern risks repeating the over-structuring we saw in Experiment 05.

**Questions for the Steward:**
- Does this "Recipe + Ingredients + Connector" framing feel useful as a general heuristic, or does it feel like an artificial constraint?
- In which areas would you *not* want to apply this pattern, even if it creates some inconsistency?
- How should we decide when a new concern (seams, quality, disclosure, etc.) deserves its own "recipe" document versus being absorbed elsewhere?

---

## 6. What to Carry Forward from Experiment 05

Experiment 05 correctly identified that some concerns in the system deserve to be treated as **explicit, composable structures** rather than being absorbed into component definitions or left implicit. This was its core insight. However, it applied this idea at too fine a grain. Many small strategy files were created for concerns that did not justify their own dedicated artifact, resulting in navigation cost that outweighed the clarity gained.

We believe the underlying impulse remains valid. The question is not *whether* to make certain concerns explicit, but *at what level of abstraction* we should do so.

Using the emerging pattern we are testing in this document, we can frame the decision this way:

- **The general recipe** worth carrying forward is this: Certain cross-cutting concerns (seams, exception behaviors, disclosure approaches, quality mechanisms) benefit from being named, documented, and treated as first-class, composable elements rather than being scattered or buried.
- **The specific ingredients** are the actual seams, strategies, and exception cases themselves. These should only be extracted into their own structures when they are genuinely cross-cutting and recurrent.
- **The connector** is the judgment process we use to decide when something deserves its own structure versus when it should remain inside a component plugin or ADR.

The failure mode in Experiment 05 was treating the *pattern* (Strategy Pattern) as the goal, rather than treating improved visibility and reduced invention as the goal. We ended up with many small files because we could, not because each one carried meaningful weight.

**Our current judgment:**

We should carry forward the discipline of making important seams and cross-cutting concerns explicit. However, we should apply this discipline at a coarser grain. A seam or strategy should earn its own dedicated file or folder only when it is likely to be referenced across multiple components or when hiding it has already produced measurable invention risk.

This is not an argument for minimalism for its own sake. It is an argument for **intentional granularity** — making something explicit only when the cost of keeping it implicit is higher than the cost of giving it its own home.

**Questions for the Steward:**

- Using the recipe model, which concerns in the current system feel like they deserve their own “general recipe” layer versus remaining as specific ingredients inside component plugins?
- Where might we be tempted to apply the Strategy Pattern too eagerly again, simply because the pattern exists?
- How should we evaluate whether a new seam or cross-cutting concern is significant enough to justify its own structure, rather than being handled inside an existing plugin or ADR?
- What signals would tell us that we are starting to repeat Experiment 05’s mistake of over-structuring?

---

## 7. Tone and Nature of Guidance

Guidance produced for Phase 2.1 should be **detailed yet contemplative**.

This means:
- We explain the reasoning behind recommendations, not just the recommendations themselves.
- We surface trade-offs and open questions even when we have a preferred direction.
- We treat the Steward as someone who needs to think, not just execute.

We are initiators. We bring forward clear positions when we have them. We also deliberately create space for the Steward to push back, refine, or reject those positions.

This is not about being vague. It is about refusing to collapse complex decisions into simple instructions before the Steward has had a chance to engage with what is actually at stake.

---

## 8. Open Questions Worth Holding

The following questions are grounded in the specific structural proposals made in this document:

- Using the Recipe + Ingredients + Connector model, where should the line be drawn between what lives in `COMPONENTS.md` (the general recipe) versus what lives in `REGISTRY.md` (the connector) versus what lives in individual `PLUGIN.md` files?
- What is the minimum viable content for `components/REGISTRY.md` so that it actually functions as a useful connector rather than becoming another document that build agents learn to skip?
- For the proposed `seams/` folder: What decision rule should we use to determine when a seam earns its own file, and how do we prevent that structure from growing faster than its value?
- If we introduce both `seams/` and `REGISTRY.md`, how do we keep the overall documentation system from drifting back toward the fragmentation we saw in Experiment 05?
- What would "success" in Phase 2.1 actually look like in the next build round? Fewer undocumented assumptions in build reports? Higher component fidelity? Clearer handling of seams? Something else measurable?

These questions matter because the quality of Phase 2.1 will depend heavily on how deliberately we answer them.

---

## 9. Proposed Next Phase of Work

If the Steward accepts the general direction outlined here, the next work could usefully focus on:

1. Defining the minimal viable shape of `components/REGISTRY.md`.
2. Prototyping what a `seams/` folder might contain (starting with 2–3 high-value seams).
3. Drafting the specific language that would live in `COMPONENTS.md` regarding plugin expectations (validation, building, verifying, testing).
4. Testing these changes against a small build round to observe their effect on invention and fidelity.

This work should remain iterative and observational rather than sweeping.

---

**End of Experiment 07 Guidance Plan**
