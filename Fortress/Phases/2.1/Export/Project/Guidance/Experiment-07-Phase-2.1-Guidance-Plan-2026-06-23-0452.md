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
- Hiding it is likely to create confusion or drift.

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

- **Disclosure Strategy**: How much invention should be surfaced in build reports, and in what format?
- **Save Strategy**: Full-table rewrite vs. incremental updates vs. change tracking.
- **Visibility Strategy**: How `IsVisible()` logic should be distributed between handlers and context.
- **Error Handling Strategy**: Whether to use guard clauses aggressively, centralized exception handling, or per-handler recovery.

**Why explicit strategy documentation works well:**

- It makes trade-offs visible rather than forcing agents to rediscover them.
- It supports the Open/Closed principle — new strategies can be added without modifying core contracts.
- It creates a natural home for the “why” behind a decision.
- It reduces the risk of convergent invention on high-impact behavioral choices.

We do **not** recommend creating a strategy file for every minor variation. A strategy should earn its own documentation when the choice has recurring impact across components or when hiding the decision has already produced divergence.

#### The Build Agent’s Relationship to Seams and Strategies

Build agents have a primary role as **consumers and translators** of these structures. They are expected to read, follow, and cite seams and strategies during builds, and to report clearly when they did so.

We recommend a middle posture between pure consumption and active editing:

- Agents should act as **structured gap detectors**. When they encounter a seam with insufficient guidance or must invent behavior not covered by an existing strategy, they should explicitly flag this in the build report using a standardized **Documentation Maintenance Proposals** table (see below).
- Agents may append short, clearly marked **Maintenance Notes** to seam or strategy files proposing clarifications or additions. These notes accumulate for human review rather than being treated as authoritative edits.
- Agents should **not** freely rewrite seam or strategy content during routine builds. The structures should remain relatively stable while still receiving structured feedback.

To keep signals clear and actionable, we propose that build reports end with a standardized table for maintenance proposals. This format allows human researchers (with AI assistance) to quickly scan, evaluate, and prioritize changes across many builds.

**Example Documentation Maintenance Proposals table format:**

```markdown
## Documentation Maintenance Proposals

| Type                  | Name                        | Description                                      | Severity | Should Block Build? | Proposed Action             |
|-----------------------|-----------------------------|--------------------------------------------------|----------|---------------------|-----------------------------|
| Missing Seam          | [Name]                      | [Brief description of risk or gap]               | High     | No                  | Create new seam file        |
| Outdated Strategy     | Visibility Strategy         | Current strategy no longer matches implementation| Medium   | No                  | Review and update           |
| Missing Strategy      | [Name]                      | Recurring decision pattern observed              | Medium   | No                  | Create new strategy file    |
| Retirement Candidate  | Old Archive Strategy        | No longer referenced in active components        | Low      | No                  | Mark as Deprecated          |
```

This format keeps proposals structured, scannable, and easy to aggregate without flooding build reports with unstructured text.

This approach treats agents as sensors that help keep the documentation alive without turning every build into an editing session.

**Questions for the Steward:**
- Which current behavioral choices in the system feel most in need of explicit strategy documentation?
- Should strategies live alongside seams in a shared folder, or should they have their own structure?
- How do we prevent the creation of strategy files from becoming another source of low-value documentation?
- What level of maintenance responsibility should build agents have for these structures over time?

### 4.3 REGISTRY.md (Connector Layer)

We recommend creating `components/REGISTRY.md` as the primary connector between `COMPONENTS.md` (the general recipe) and the individual `PLUGIN.md` files (the specific ingredients).

**What `REGISTRY.md` should contain:**
- Component inventory and load order
- Dependency mapping between components
- Registration rules and `IDependencyModule` references
- Links to each component’s `PLUGIN.md`
- Cross-references to relevant seams and strategies

**What `REGISTRY.md` should only link to (not duplicate):**
- General component rules and philosophy → `COMPONENTS.md`
- Quality expectations and testing philosophy → `COMPONENTS.md`
- Detailed seam or strategy explanations → their respective files

`REGISTRY.md` should remain intentionally lightweight. Its job is to connect and map, not to duplicate rules that belong in the recipe layer.

### 4.4 Lifecycle and Maintenance Considerations

These structures will be used differently across the life of the system.

**During the initial build**, seams and strategies primarily serve as orientation and invention reduction. They provide early guardrails and a place to externalize difficult decisions. The main risk here is **premature crystallization** — documenting concerns too early, before the system has revealed its real shape.

**When new features are added**, these structures can act as diagnostic tools. A developer or agent can consult existing seams and strategies rather than rediscovering friction. However, they can also create friction if every new cross-cutting concern triggers lengthy threshold discussions. The real test is whether the structures remain alive and consulted, or slowly become archival.

**During refactoring**, the structures offer an opportunity for intentional evolution. Instead of only refactoring code, one can also review and retire outdated seams or strategies. The danger is **asymmetric maintenance burden**: it is easy to add a new seam or strategy file, but much harder to confidently remove one later. Over time, the system risks accumulating “zombie” artifacts that are no longer actively used but are kept out of caution.

A deeper tension exists between **visibility and weight**. Making seams and strategies explicit improves clarity and reduces hidden invention. Every additional artifact also increases the surface that must be understood and maintained. The long-term value of these structures will depend heavily on whether someone (or some process) actively curates them. Without deliberate stewardship, they are likely to degrade into either neglected archives or bloated ceremony.

To support long-term curation, we recommend giving seam and strategy files a simple **lifecycle status**:

- **Proposed**: Newly created, not yet validated by use.
- **Active**: Currently relevant and referenced in builds or reasoning.
- **Deprecated**: No longer recommended, but kept for historical reference.
- **Retired**: Removed from active use after review.

This status helps prevent zombie structures by making obsolescence visible and intentional rather than accidental.

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
- For both `seams/` and strategies, what decision rule should we use to determine when something earns its own file, and how do we prevent that structure from growing faster than its value — especially over multiple refactorings?
- If we introduce `seams/`, strategies, and `REGISTRY.md`, how do we keep the overall system from drifting back toward the fragmentation seen in Experiment 05 while still allowing these structures to evolve?
- What responsibility should build agents have for maintaining and surfacing gaps in seams and strategies over time, and what mechanisms would make that feedback usable without creating excessive noise?
- What would “success” in Phase 2.1 actually look like after the next build round and subsequent refactorings? Fewer undocumented assumptions? Higher component fidelity? Clearer handling of seams and strategies? Lower long-term maintenance burden? Something else measurable?

These questions matter because the quality of Phase 2.1 will depend heavily on how deliberately we answer them — not just at the start, but as the system continues to change.

---

## 9. Proposed Next Steps for Phase 2.1

1. Define the minimum viable `components/REGISTRY.md`.
2. Prototype 2–3 seam files using the proposed decision criteria (limit initial pass to a small number).
3. Prototype 1–2 strategy files with concrete examples and the proposed threshold.
4. Update `COMPONENTS.md` with light references to `REGISTRY.md` and the new structures.
5. Run a focused build round and measure against the success signals below, with particular attention to whether the new structures are actually used.

**Prototype scope recommendation:** Limit the first pass to a maximum of 3 seam files and 2 strategy files. This protects against over-expansion before the value of the new structures has been validated through real use.

---

## 10. Success Measures for Phase 2.1

Phase 2.1 should not be considered successful simply because new folders and files were created. We propose the following signals as indicators that the structural changes are producing real value:

| Signal                        | What Good Looks Like                                      | How to Observe                                      |
|-------------------------------|-----------------------------------------------------------|-----------------------------------------------------|
| Reduced undocumented invention| Fewer high-severity inventions appear without traceability to a seam, strategy, or gap | Review Invention Summary tables in build reports    |
| Improved component fidelity   | Higher consistency in how components are structured and registered | Compare handler registration and contract completeness across builds |
| Seams and strategies are used | Agents name relevant seams and strategies in their reasoning rather than re-deriving them | Qualitative review of build reports and reasoning   |
| Registry is referenced        | Agents consult `REGISTRY.md` for load order and cross-component responsibilities | Evidence in build reports                           |
| Maintenance burden remains reasonable | The documentation structure does not grow significantly faster than the actual complexity of the system | Track growth of new files vs. growth of new concerns |

These measures are directional. The goal is to detect whether we are reducing invention and improving clarity, or simply adding documentation ceremony that will become expensive to maintain.

---

*End of document*