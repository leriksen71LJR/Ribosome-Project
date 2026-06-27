<FILE file_path="/home/workdir/attachments/Build Agent exp 7 thoughts v2.md" size="27527 bytes">
----
----
Claude

Reading the document now — detailed report follows.

---

# Review Report: Experiment-07-Phase-2.1-Guidance-Plan-2026-06-23-0353.md

**Compared against:** 0216 version (reviewed earlier this session)

---

## Overall Assessment

This version is a meaningful improvement over 0216. It is tighter, more concrete, and — critically — Section 8 is now directly grounded in the document's own proposals rather than being generic. The addition of Section 4.2 (Strategies) and Section 10 (Success Measures) represent real forward progress. However, several areas carry new risks that deserve honest attention before this goes to the Steward.

---

## Section-by-Section Analysis

### Section 1 — Purpose
**Rating: Good**

Compressed well from 0216. Loses nothing essential. The one-paragraph posture statement is cleaner and more direct. No changes needed.

---

### Section 2 — Core Posture
**Rating: Good, with a minor concern**

The Recipe/Ingredients/Connector model is now elevated to the opening posture section, which signals its importance clearly. The caveat "working hypothesis, not declaring it complete" is exactly right.

**Minor concern:** Moving this model this early means a Steward reading cold will encounter the pattern before understanding the problem it's solving. In 0216, the problem came first (Section 3), then the structural direction (Section 4), then the pattern (Section 5). In 0353, the pattern is introduced in Section 2 before the problem statement in Section 3. This is a small sequencing risk — the model may feel like a solution in search of a problem if a new reader hits it first.

**Recommendation:** Consider a single bridging sentence at the end of Section 2 that says something like: *"We introduce this framing here because it shapes how we evaluate every structural recommendation that follows."* This anchors it without reordering.

---

### Section 3 — What We Are Trying to Solve
**Rating: Adequate but thin**

This section is shorter than in 0216 and loses some of the tension that made the earlier version useful for the Steward. The phrase "several cross-cutting concerns remain either implicit or scattered" is accurate but doesn't convey the weight of what was lost in Experiment 06 (Strategy Pattern becoming more implicit, seam visibility dropping).

**Recommendation:** Add one concrete sentence about what specifically weakened in Experiment 06. Something like: *"Experiment 06 improved plugin structure but allowed Strategy Pattern reasoning and seam identification to become implicit — left to individual agents rather than documented in shared structures."* This gives the Steward a concrete anchor.

---

### Section 4.1 — Seams
**Rating: Significantly improved over 0216**

The threshold criteria (two-of-four rule) is the most valuable addition in this document. It solves the main weakness I flagged in the 0216 review: that section raised good questions but didn't lead with a strong recommendation. The two-of-four test gives the Steward an actionable decision rule.

The distinction between seams (boundaries/risk points) and strategies (selectable behaviors) is well-placed here and sets up Section 4.2 cleanly.

**One concern:** The phrase "Hiding it has created confusion or drift" as a threshold criterion uses past tense — it implies the seam must already have caused a problem before it earns documentation. That may be too reactive. Some high-value seams are worth documenting preventively. Consider softening to: *"Hiding it is likely to create confusion or drift."*

**Questions for the Steward remain strong.** No changes needed there.

---

### Section 4.2 — Strategies
**Rating: Strong — best new addition in this version**

This section did not exist in 0216. It is the most substantive addition and earns its place.

**What works well:**
- The distinction between seams and strategies is clear and genuinely useful
- The concrete Fortress examples (Disclosure Strategy, Save Strategy, Visibility Strategy, Error Handling Strategy) ground the concept immediately — a reader won't have to wonder what a "strategy" means in practice
- The Open/Closed principle reference is appropriate and not forced
- The warning against creating a strategy file for every minor variation is exactly the right guard

**One concern:** The four concrete examples are very good, but they vary significantly in scope. The Disclosure Strategy is high-level and cross-cutting. The Visibility Strategy (`IsVisible()` logic distribution) is much more granular and component-specific. Mixing these in the same list may inadvertently suggest to the Steward that both are equally good candidates for strategy documentation. Consider adding a brief note that the examples are illustrative and that not all four would necessarily meet the threshold — the Steward should apply the judgment criteria to evaluate each.

**Questions for the Steward are sharp.** The middle question ("Should strategies live alongside seams in a shared folder, or should they have their own structure?") is particularly good because it's a real architectural decision that isn't pre-decided by this document.

---

### Section 4.3 — REGISTRY.md
**Rating: Good, with one gap**

The minimum viable content list is concrete and useful. Specifying what belongs in REGISTRY.md (load order, plugin inventory, registration rules, quality expectations, cross-references to seams/strategies) prevents it from becoming either empty or overloaded.

**Gap:** The section doesn't address what happens when REGISTRY.md and COMPONENTS.md overlap on quality expectations. COMPONENTS.md is the recipe — it should own quality expectations in general. REGISTRY.md should reference or link, not duplicate. The current list suggests REGISTRY.md "contains quality expectations that apply across components," which risks creating exactly the overlap problem the Recipe model is trying to prevent.

**Recommendation:** Revise to: *"References to quality expectations defined in `COMPONENTS.md`, with specific component-level notes where they vary."* This preserves the connector role rather than making REGISTRY.md a second source of truth.

---

### Section 5 — Emerging Pattern
**Rating: Good**

Appropriate as a consolidation after Sections 4.1–4.3. The warning against reflexive application is well-placed. No changes needed.

---

### Section 6 — What to Carry Forward from Experiment 05
**Rating: Improved from 0216**

The Recipe model application here (general recipe → specific ingredients → connector as judgment process) is cleaner and tighter than the 0216 version. "Intentional granularity, not minimalism for its own sake" remains a strong phrase.

**Minor concern:** This section is now somewhat compressed. The 0216 version had four specific questions for the Steward here; this version has none. The Steward is left with a clear statement but no invitation to engage critically. Consider restoring at least one sharp question — perhaps: *"Which cross-cutting concerns in the current system do you believe have already caused measurable divergence, and which are you uncertain about?"*

---

### Section 7 — Tone and Posture
**Rating: Adequate but minor**

This section is now very short (two sentences). It reads like a placeholder rather than meaningful guidance. In 0216 it was longer and more substantive. Given that the posture is already stated in Sections 1 and 2, this section may be redundant. Either expand it to add something new, or remove it and fold the sentiment into the closing of Section 1.

---

### Section 8 — Open Questions Worth Holding
**Rating: Significantly improved — addresses the main weakness of 0216**

This was the weakest section in 0216 (too generic). In 0353, all five questions are directly tied to proposals made in the document itself. This is exactly right.

**Strongest questions:** The REGISTRY.md minimum viable content question and the anti-fragmentation guard question are both sharp and worth sitting with.

**One concern:** The fifth question ("What would 'success' in Phase 2.1 actually look like?") is partially answered by Section 10 (Success Measures). This creates a slight redundancy. Consider either removing it from Section 8 or revising it to point forward: *"After reading the proposed success measures in Section 10, do any feel like they miss what you actually care about?"*

---

### Section 9 — Proposed Next Steps
**Rating: Improved from 0216**

Adding prototype strategy files (Step 3) and the update to COMPONENTS.md (Step 4) are the right additions. The sequence is logical and incremental.

**Minor concern:** Step 5 ("Run a build round") is underspecified. What build round? What scope? A Steward reading this cold won't know whether this means a full Phase 1.2A-style build or a targeted component test. Even one sentence of scope would help.

---

### Section 10 — Success Measures (New)
**Rating: Strong addition**

This section didn't exist in 0216 and represents genuine progress. Defining success signals before the build round is the right practice — it prevents retroactive justification of whatever happened to emerge.

**What works well:**
- The measures are concrete enough to actually observe
- The closing caveat ("starting points, to be refined") is honest and prevents them from becoming rigid targets
- The signal about whether structures are "actually referenced in build reports rather than ignored" is particularly sharp — that's a real, observable test

**One concern:** The second bullet ("Improved consistency in how components are registered and validated") is vaguer than the others. What would inconsistency look like specifically? Consider tightening to something like: *"Build agents correctly apply REGISTRY.md registration rules without deviation or invention in that area."*

---

## Summary Table

| Section | Rating | Key Action |
|---------|--------|------------|
| 1 — Purpose | Good | None |
| 2 — Core Posture | Good | Add one bridging sentence anchoring the pattern to what follows |
| 3 — What We Are Trying to Solve | Thin | Add one concrete sentence on what Experiment 06 lost |
| 4.1 — Seams | Strong | Soften one reactive threshold criterion to be preventive |
| 4.2 — Strategies | Strong | Add note that the four examples vary in scope and need the threshold applied |
| 4.3 — REGISTRY.md | Good | Fix the quality expectations overlap with COMPONENTS.md |
| 5 — Emerging Pattern | Good | None |
| 6 — Experiment 05 Lessons | Good | Restore at least one question for the Steward |
| 7 — Tone and Posture | Weak | Expand or remove — currently adds little |
| 8 — Open Questions | Strong | Revise Q5 to avoid redundancy with Section 10 |
| 9 — Next Steps | Good | Add one sentence scoping the "build round" in Step 5 |
| 10 — Success Measures | Strong | Tighten the second bullet |

---

## Priority Fixes (in order)

1. **Section 4.3** — Fix the REGISTRY.md quality expectations overlap (structural integrity risk)
2. **Section 4.2** — Add note that the four strategy examples vary in scope (prevents misreading the threshold)
3. **Section 3** — Add one concrete sentence on what Experiment 06 lost (anchors the whole document)
4. **Section 8 Q5** — Revise to avoid redundancy with Section 10
5. **Section 6** — Restore one question for the Steward

Everything else is polish.

---

## Bottom line

This is a substantially better document than 0216. The Strategies section and Success Measures are genuine additions. The five priority fixes above are all small but would meaningfully improve precision before the document goes to the Steward.

----
----
Codex

You’re right. Here is the report directly in chat.

**Detailed Review Report: Experiment 07 Phase 2.1 Guidance Plan**

**Reviewed file:** `Experiment-07-Phase-2.1-Guidance-Plan-2026-06-23-0353.md`  
**Review focus:** clarity, usefulness as guidance, risks, documentation architecture, and readiness for Phase 2.1 execution.

**Executive Summary**

This is a strong guidance document. It improves on the earlier version by making several key ideas more explicit: the difference between seams and strategies, the proposed role of `REGISTRY.md`, and the need for measurable success criteria.

The core strength is that it does not rush into final architecture. It frames Phase 2.1 as a deliberate evolution from Experiment 06, while preserving lessons from Experiment 05. That is the right posture. Experiment 05 over-structured; Experiment 06 simplified; this document is trying to recover useful explicitness without reintroducing fragmentation.

My overall recommendation: **accept the direction, but do not implement it broadly until the thresholds, templates, and evaluation criteria are made more operational.**

**What Works Well**

The document has a clear purpose. It says its role is to prepare guidance for Phase 2.1, not to finalize the structure. That matters because the tone is contemplative and decision-support oriented. It is not pretending to be executable agent documentation yet.

The “thinking partners who initiate” posture is also useful. It gives Research permission to recommend, but not to over-decide. That is a healthy relationship between Research and Stewardship: Research frames tensions and offers judgment; the Steward decides what becomes canonical.

The Recipe / Ingredients / Connector model is the strongest conceptual contribution.

- `Recipe` files define general rules and philosophy.
- `Ingredient` files contain specific executable details.
- `Connector` files link broad guidance to concrete implementations.

This is memorable and likely useful for agents. It gives a simple placement heuristic: general rules go in recipe docs, component-specific details go in plugin docs, and relationship mapping goes in connector docs.

The separation between **seams** and **strategies** is another important improvement.

A seam is a boundary, ambiguity, or risk point. A strategy is a chosen approach for recurring behavior. That distinction prevents a real documentation problem: treating every unclear area as the same kind of artifact. Seams help identify where risk exists. Strategies help define what to do when multiple valid approaches exist.

The seam threshold is good. A seam earns its own file when it meets at least two criteria:

- It is cross-cutting.
- It has caused measurable invention or divergence.
- It is likely to recur.
- Hiding it has caused confusion or drift.

That is close to executable guidance. It gives future agents and Stewards a reasoned filter instead of relying on vague taste.

The `REGISTRY.md` proposal is directionally strong. A connector between `COMPONENTS.md` and individual `PLUGIN.md` files could reduce agent confusion, especially around load order, dependencies, registration rules, and cross-component quality expectations.

The success measures section is also valuable. It moves the plan away from “this feels better” and toward observable outcomes: fewer undocumented assumptions, more consistent registration, clearer handling of cross-cutting concerns, and actual references to the new structures in build reports.

**Main Concerns**

The biggest risk is that `REGISTRY.md` becomes a second `COMPONENTS.md`.

The document says `REGISTRY.md` should not duplicate recipe content, but some proposed contents overlap with general rules: registration rules, validation, testing, deviation reporting. That is dangerous because connector documents tend to expand. If `REGISTRY.md` starts explaining all the rules, agents may have to read both `COMPONENTS.md` and `REGISTRY.md` to understand the same thing.

Recommended boundary:

- `COMPONENTS.md`: defines universal component rules.
- `components/REGISTRY.md`: lists components, dependencies, load order, and links to the rules.
- `PLUGIN.md`: defines component-specific details.

The second major risk is strategy-document sprawl.

The document correctly warns against creating a strategy file for every minor variation, but it does not yet define a strategy threshold as clearly as it defines the seam threshold. Since strategies are attractive abstractions, agents may overuse them. That would recreate the Experiment 05 failure mode in a new vocabulary.

I would add a rule like:

A strategy should earn its own file only when at least two are true:

- Multiple reasonable approaches exist.
- The choice affects multiple components or repeated workflows.
- Prior agents have made inconsistent choices.
- The strategy affects correctness, security, persistence, reporting, or test design.
- The strategy is expected to evolve independently.

Without something like this, “strategy” may become too easy to invoke.

The third concern is that success measures are still partly subjective. “Improved consistency” and “clearer handling” are useful phrases, but they need evidence sources and pass indicators. Otherwise the evaluation may become impressionistic.

For example:

| Signal | Evidence Source | Pass Indicator |
|---|---|---|
| Fewer undocumented assumptions | Build reports | Fewer new assumptions than previous run |
| Seams used | Build reports | Agent names relevant seam without re-deriving it |
| Strategies used | Build reports or reasoning files | Agent names selected strategy before implementation |
| Registry used | Build report | Agent references load order or registration rules |
| Fragmentation controlled | File inventory | New docs stay within prototype cap |

The fourth concern is missing templates. The plan proposes new structures but does not define their shape. Without templates, each agent may invent a format for seam files, strategy files, and registry entries. That would undermine the goal of reducing invention.

**Section-by-Section Review**

**1. Purpose of This Document**

This section is clear. It properly states that the document is guidance, not final design.

The phrase “thinking partners who initiate” works well here. It signals that the document should provide judgment without closing every decision.

Suggested improvement: explicitly say what decision this document is meant to enable. For example: “This document should enable the Steward to decide whether to prototype seams, strategies, and `REGISTRY.md` in Phase 2.1.”

**2. Core Posture**

The Recipe / Ingredients / Connector model is useful and memorable.

This section would be stronger with a placement rule:

- If it applies across all components, it belongs in the recipe.
- If it applies to one component, it belongs in the ingredient.
- If it maps relationships across many components, it belongs in the connector.

That one rule would make the model more actionable.

**3. What We Are Trying to Solve**

This section is concise and accurate. It correctly identifies the central challenge: make important concerns visible without recreating Experiment 05 fragmentation.

Suggested improvement: add a non-goal.

Example: “Phase 2.1 should not create a separate document for every local variation, exception, or minor pattern.”

That would help prevent over-application.

**4.1 Seams**

This is one of the strongest sections. The decision threshold is concrete and useful.

The seam/strategy distinction is also very important. Keeping those separate will make the documentation system cleaner.

Suggested improvement: define minimum seam file contents:

- Seam name.
- Boundary or risk described.
- Affected components.
- Known failure modes.
- Required agent behavior.
- Related strategies.
- Related ADRs or tests.

That would make `seams/` immediately more executable.

**4.2 Strategies**

This section is valuable. The explanation of strategies as named, selectable approaches is clear.

The examples are especially helpful:

- Disclosure Strategy.
- Save Strategy.
- Visibility Strategy.
- Error Handling Strategy.

These examples show that the author is not talking about abstract design patterns only, but recurring behavioral decisions that agents may otherwise reinvent.

Suggested improvement: define where strategy docs live.

My recommendation:

- Cross-cutting strategies go in `.docs/strategies/`.
- Component-local strategies stay inside that component’s `PLUGIN.md`.
- Strategy references may appear in seam docs when a seam depends on a strategy choice.

Also add a strategy threshold, similar to the seam threshold.

**4.3 REGISTRY.md**

The connector concept is useful, but this section needs the most boundary control.

The minimum viable content list is good, but should be split into “contains” and “links to.”

`REGISTRY.md` should contain:

- Component list.
- Component responsibilities.
- Dependency/load order.
- Links to each `PLUGIN.md`.
- Related seams and strategies.
- Registration module references.

`REGISTRY.md` should link to, not duplicate:

- General component rules.
- Coding standards.
- Testing rules.
- Long explanations of validation or DI.

That keeps the connector from becoming another recipe.

**5. Emerging Pattern**

This section is thoughtful. It says the model is a working hypothesis, not a universal law. That restraint is important.

Suggested improvement: add an anti-rule.

Example: “Do not create a connector document unless there are multiple specific artifacts to coordinate and the relationship cannot be made clear in the recipe document itself.”

That would reduce pattern overuse.

**6. What to Carry Forward from Experiment 05**

This is probably the best historical analysis in the document.

It correctly says Experiment 05 had a valid insight: some cross-cutting concerns need explicit structure. Its mistake was applying that insight too finely.

The phrase “intentional granularity” is doing good work. It captures the difference between helpful structure and structure for its own sake.

Suggested improvement: cap the prototype.

Example:

- Maximum three seam files.
- Maximum two strategy files.
- One `REGISTRY.md`.
- One focused `COMPONENTS.md` update.

This would protect Phase 2.1 from becoming too broad.

**7. Tone and Posture**

This section is appropriate for a research guidance document. It should probably not be carried directly into executable agent docs, though. Agents need crisp rules once decisions are made.

Suggested improvement: later split this into two artifacts:

- Research guidance for Steward thinking.
- Agent instructions for actual execution.

**8. Open Questions**

The questions are good and specific. They are not vague philosophical questions; they are tied to the proposed structures.

Suggested improvement: convert them into a decision log.

For each question:

- Decision needed?
- Default if undecided.
- Owner.
- Impact.
- Deadline or phase.

This would make the open questions easier to resolve.

**9. Proposed Next Steps**

The next steps are sensible and appropriately incremental.

I would slightly reorder them:

1. Approve thresholds.
2. Create templates.
3. Define minimum viable `REGISTRY.md`.
4. Prototype 2-3 seam files.
5. Prototype 1-2 strategy files.
6. Update `COMPONENTS.md`.
7. Run build round.
8. Evaluate against scorecard.

Templates should come before prototype files so agents do not invent formats.

**10. Success Measures**

This section is a major strength. It shows the plan understands that documentation architecture must be tested by behavior, not just by how coherent it feels.

Suggested improvement: make each measure testable. Define evidence sources and expected signals.

For example, “agents reference seams and strategies in build reports” is testable. “Documentation feels more coherent” is useful, but should be paired with human review notes or a small rating rubric.

**Recommended Changes Before Phase 2.1 Execution**

1. Add a strategy-file threshold.

The seam threshold is good. Strategies need the same protection.

2. Clarify `REGISTRY.md` boundaries.

Make clear what it contains versus what it only links to.

3. Add templates.

Create minimal templates for:

- Seam files.
- Strategy files.
- Registry entries.

4. Add prototype caps.

Do not allow the first Phase 2.1 pass to create unlimited docs.

5. Convert success measures into a scorecard.

Tie each measure to evidence from build reports, reasoning files, file inventory, or Steward review.

6. Add placement rules.

Make it obvious where information belongs:

- General rule: recipe.
- Specific implementation: ingredient.
- Relationship mapping: connector.
- Local component behavior: `PLUGIN.md`.
- Cross-cutting risk: seam.
- Cross-cutting behavioral choice: strategy.

**Proposed Templates**

**Seam File Template**

```md
# Seam: [Name]

## Purpose
What boundary, risk, or ambiguity this seam represents.

## Affected Components
List affected components or workflows.

## Why This Is a Seam
Explain which criteria it meets:
- Cross-cutting
- Prior invention/divergence
- Likely recurrence
- Hidden confusion/drift

## Required Agent Behavior
What agents must do when working near this seam.

## Known Failure Modes
What tends to go wrong.

## Related Strategies
Links or names.

## Related ADRs / Tests
Links or names.
```

**Strategy File Template**

```md
# Strategy: [Name]

## Problem
What recurring choice this strategy addresses.

## Options Considered
List reasonable approaches.

## Default Strategy
State the selected or preferred approach.

## When To Use
Conditions where this strategy applies.

## When Not To Use
Conditions where this strategy should not apply.

## Impacted Components
Components or workflows affected.

## Related Seams
Links or names.

## Verification
How agents should demonstrate they followed the strategy.
```

**Registry Entry Template**

```md
## Component: [Name]

## Responsibility
Brief description.

## Dependencies
What this component depends on.

## Load / Registration Order
Where it appears in the build order.

## Registration Module
Name of dependency module.

## Plugin File
Link to component PLUGIN.md.

## Related Seams
Links or names.

## Related Strategies
Links or names.

## Test Expectations
Specific expectations or links.
```

**Final Judgment**

This is a good guidance plan. It is thoughtful, restrained, and pointed at the right problem.

The strongest idea is not simply “add seams” or “add strategies.” The strongest idea is that documentation artifacts should earn their existence by reducing invention, clarifying recurring decisions, or connecting general rules to specific implementation details.

The main danger is that the plan could become exactly what it warns against: a new layer of attractive structure that expands faster than its value. The solution is not to reject the plan. The solution is to prototype it tightly.

My recommendation:

**Proceed with Phase 2.1, but only as a capped prototype. Add thresholds, templates, and a scorecard first. Then test whether agents actually use the new structures before expanding them.**
</FILE>
