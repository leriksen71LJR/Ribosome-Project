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

We believe seams deserve first-class visibility.

Rather than continuing to route most seam decisions exclusively through ADRs, we recommend introducing a dedicated `seams/` folder under `.docs/`.

**Why this direction feels worth considering:**
- Seams were the primary source of invention risk in earlier work.
- ADRs are effective for recording decisions, but they are not optimized for making seams *visible and actionable* during day-to-day building.
- A dedicated `seams/` structure would make the shape of the system’s known weak points more legible to both humans and build agents.

**Questions for the Steward:**
- Would a `seams/` folder create useful visibility, or would it risk becoming another layer that agents must remember to consult?
- How should seams relate to ADRs? Should every seam eventually have a corresponding ADR, or should some seams remain lightweight and living?
- What level of formality feels appropriate for seam documentation?

### 4.2 COMPONENTS.md and Plugin Connection

`COMPONENTS.md` should remain relatively stable. It currently functions well as a high-level index and load-order definition.

However, it currently under-serves two important responsibilities:
- Helping build agents understand *how* to work with the plugins (validation, building, verifying, testing).
- Providing a clear, minimal connection point between the high-level component registry and the detailed `PLUGIN.md` files.

**Recommended direction:**
- Keep `COMPONENTS.md` stable in its core purpose and structure.
- Introduce a new, minimal file: `components/REGISTRY.md`.
- Have `COMPONENTS.md` point to `REGISTRY.md` as the authoritative place for plugin-level registration and connection details.
- Use `COMPONENTS.md` to articulate expectations around plugin validation, building, verification, and unit testing — without embedding those details directly into the file.

This keeps `COMPONENTS.md` from becoming bloated while still giving it meaningful responsibility for guiding how plugins should be worked with.

**Questions for the Steward:**
- How minimal should `REGISTRY.md` actually be? What belongs there versus what belongs in the individual `PLUGIN.md` files?
- Should `COMPONENTS.md` contain light guidance on validation and testing, or should that live elsewhere (for example, in a quality or process document)?
- What is the right balance between giving build agents clear expectations and avoiding over-specification?

---

## 5. What to Carry Forward from Experiment 05

Experiment 05 was over-granular in its application of Strategy Pattern. Many small strategy files created more navigation cost than clarity.

However, several ideas that surfaced during that work remain valuable:
- The discipline of making cross-cutting concerns (seams, disclosure approaches, exception handling, quality mechanisms) explicit rather than implicit.
- The value of treating certain documentation elements as composable strategies rather than embedding everything inside component definitions.
- The insight that some concerns are better curated *outside* the main component specifications.

**Our current judgment:**
These ideas are worth carrying forward, but they should be applied selectively and at a coarser grain than Experiment 05 attempted. The goal is not to recreate Experiment 05’s structure. It is to recover some of its visibility and intentionality without reintroducing its fragmentation.

---

## 6. Tone and Nature of Guidance

Guidance produced for Phase 2.1 should be **detailed yet contemplative**.

This means:
- We explain the reasoning behind recommendations, not just the recommendations themselves.
- We surface trade-offs and open questions even when we have a preferred direction.
- We treat the Steward as someone who needs to think, not just execute.

We are initiators. We bring forward clear positions when we have them. We also deliberately create space for the Steward to push back, refine, or reject those positions.

This is not about being vague. It is about refusing to collapse complex decisions into simple instructions before the Steward has had a chance to engage with what is actually at stake.

---

## 7. Open Questions Worth Holding

As this work moves forward, several deeper questions deserve ongoing attention:

- How much explicit structure is actually helpful to build agents versus how much becomes cognitive overhead?
- At what point does making seams and strategies more visible start to compete with the goal of keeping the documentation system itself navigable and coherent?
- What is the right relationship between living documentation (plugins, seams, strategies) and recorded decisions (ADRs)?
- How should success in Phase 2.1 be measured? Reduced invention? Improved agent fidelity? Better human comprehension? Something else?

These questions do not need immediate answers. They should remain active in the background of the work.

---

## 8. Proposed Next Phase of Work

If the Steward accepts the general direction outlined here, the next work could usefully focus on:

1. Defining the minimal viable shape of `components/REGISTRY.md`.
2. Prototyping what a `seams/` folder might contain (starting with 2–3 high-value seams).
3. Drafting the specific language that would live in `COMPONENTS.md` regarding plugin expectations (validation, building, verifying, testing).
4. Testing these changes against a small build round to observe their effect on invention and fidelity.

This work should remain iterative and observational rather than sweeping.

---

**End of Experiment 07 Guidance Plan**