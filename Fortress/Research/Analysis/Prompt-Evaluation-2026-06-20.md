# Prompt Evaluation
---
Claude

```
Here is an honest evaluation of the Reasoning Disclosure Prompt.

What the Prompt Does Well
Clear purpose and framing. "Make your understanding and reasoning fully visible before any implementation work begins" is an unambiguous objective. It correctly separates reasoning from building — a meaningful distinction that most prompts collapse.

Mandatory sequencing. The "write this file first, nothing else until it exists" constraint is enforceable and sensible. It forces the agent to commit its understanding before action, which makes deviation visible.

Four-section structure is strong. The four required sections cover a genuinely complete picture: what the agent understood, how it models the workflow, what risks it is carrying, and whether the documentation itself works as instructions. That last section (Documentation as Pseudocode) is the most valuable — it turns the agent into a documentation reviewer, not just a documentation consumer.

The "fresh analysis only" instruction has a real purpose. Without it, an agent with prior context would anchor on earlier conclusions and produce a shallow re-hash. The instruction is the right call. However — see below — it has a practical limitation.

Where the Prompt Has Weaknesses
1. The "fresh analysis only" instruction cannot be fully honoured in a continued session
"Pretend like you never read this before" asks the agent to discard context it demonstrably has. An agent cannot unlearn what it synthesised in the same context window. What it can do is re-read documents fresh and produce analysis based on what it reads now rather than recalling prior output. That is what I did — but the prompt conflates two different things: ignoring prior reasoning files (achievable) and having no prior context (not achievable in a continued session). The "spare no expense" instruction compensates by demanding thoroughness, but the framing is slightly incoherent.

Fix: Separate the two constraints explicitly. "Do not carry forward conclusions from previous reasoning files" is enforceable. "Act as if this is your first time reading these documents" is performative — the agent re-reads but cannot fully shed prior synthesis.

2. The starting instruction set has a vocabulary mismatch with the actual repository
The prompt instructs the agent to avoid Research/ and says content lives under Project/. Neither folder exists in this repository. The actual documentation space is .docs/. This means the boundary rule reads as authoritative instruction but enforces against a folder that isn't there — the constraint is inert. An agent following it strictly cannot verify compliance.

Fix: Update the prompt's Research//Project/ vocabulary to match the actual folder layout, or add a note that .docs/ is the permitted space in this repository.

3. Section 4 ("Documentation as Pseudocode") is well-named but the sub-questions are partially redundant
The four sub-bullets ask:

Which parts felt like executable instructions?
Which parts felt like conceptual writing?
How did the balance affect confidence?
What changes would make docs function as pseudocode?
Questions 1 and 2 are the same question asked from two directions. The answer to 3 follows automatically from 1 and 2. The real payload is question 4 — specific, actionable recommendations. An agent naturally pads its response by restating 1 and 2 before reaching 4. The section would be tighter if it led with the evaluative framing and made question 4 the primary deliverable.

Fix: Lead with "Evaluate the documentation as executable instructions. For each document or section, rate whether it reaches specification-grade or remains concept-grade, and explain what specifically would need to change to elevate it." Questions 1–3 become the evidence; question 4 becomes the explicit output.

4. "Impact of Conclusions" in Section 1 risks becoming a summary of Section 2
The Section 1 sub-bullet "Explain why these conclusions matter and how they would affect implementation or agent behavior" overlaps significantly with Section 2 (Workflow Understanding) and Section 3 (Risks). An agent writing carefully will either repeat itself across sections or artificially separate findings that belong together.

Fix: Scope Section 1's "Impact" to per-document impact only — what this specific document, read in isolation, would cause an agent to do differently. Keep cross-document synthesis in Section 2.

5. No explicit definition of "done" for the reasoning file
The prompt says the reasoning file must be written before any implementation. It does not define what constitutes a satisfactory reasoning file. An agent producing three sentences per section has technically complied. The evaluation criterion is implicit ("quality, honesty, and precision") but not operationalised.

Fix: Add a minimum-bar definition — e.g., "For each contradiction identified, the reasoning file must name both documents involved, state the specific conflict, and state the resolution chosen." That turns "quality" into a checkable property.

Overall Assessment
The prompt is doing something genuinely useful: it makes agent reasoning an explicit artefact rather than an invisible precursor to code. The four-section structure is well-chosen and the mandatory-first-file sequencing is enforceable.

Its main weaknesses are vocabulary drift from the actual repository (the Research//Project/ mismatch), a section structure that incentivises padding over precision in Section 4, and a philosophical gap between "fresh analysis" as an instruction versus what a continued-context agent can actually deliver.

It is a strong prompt for its purpose. The Section 4 addition is the most substantive improvement over a simpler "explain your understanding" prompt — it positions the agent as a documentation auditor, which surfaces problems that passive reading would not.
```

---
Grok

```
Evaluation of the Phase 1.2 Reasoning Disclosure Prompt

What the prompt does well

1. Clear primary objective
It explicitly forbids implementation and centers the session on reasoning visibility. That removes the main failure mode of “read docs briefly, then start coding.” The objective is unambiguous.

2. Strong sequencing
Mandatory read order (AGENTS.md → README.md → .docs/) plus “reasoning file first, everything else forbidden” creates a real gate. That is good process design: one artifact must exist before any build work.

3. Useful evaluation lens
“Documentation as Pseudocode” is the strongest part of the prompt. It directly tests whether the docs function as executable agent instructions, not just whether an agent can summarize them. That aligns well with the Fortress documentation-first model.

4. Second version improved rigor
The “Fresh Analysis Only” rule is important. Without it, agents can recycle prior reasoning and look thoughtful without re-engaging with the docs. The per-document substructure in Section 1 also forces more precise separation of:
• what was stated
• what was unclear
• what was inferred
• why it matters

That is a meaningful upgrade over a single narrative summary.

5. Honesty requirement is well placed
“Asking for uncertainties and assumptions” is the right metric for this exercise. It discourages false confidence, which is exactly what you want when evaluating documentation quality.

───

Weaknesses and ambiguities in the prompt itself

1. Boundary rule is internally inconsistent
The prompt says:

• “All documentation relevant to you lives under Project/”
• But also tells the agent to read AGENTS.md, README.md, and .docs/ at the workspace root

In the actual workspace, there is no Project/ folder. An agent must infer that the working directory is the project root. That undermines the “executable instructions” standard the prompt is trying to test.

Recommendation: Define project root explicitly, e.g. “the directory containing AGENTS.md.”

2. Read scope is underspecified
The prompt says “the contents of the .docs/ folder” but does not say whether that includes:
• only the four files present
• referenced-but-missing files like PHASE_1_1_IMPROVEMENTS.md
• Evaluation/EvaluationCriteria.md (referenced by AGENTS.md, but outside .docs/)

Agents will diverge here. Some will note missing files; others will hunt elsewhere.

Recommendation: Add explicit rules:
• “Read only files that exist under .docs/”
• “You may note references to missing files, but must not read outside the allowed set”
• “Do not read Evaluation/ unless explicitly listed”

3. No rubric for judging reasoning quality
The prompt says agents are evaluated on “quality, honesty, and precision,” but gives no scoring criteria. That makes the exercise subjective.

Recommendation: Add a lightweight rubric, e.g.:
• explicit vs inferred claims clearly labeled
• contradictions identified with source docs cited
• assumptions tied to specific gaps
• implementation impact explained for each major decision

4. Section 1 format changed between versions without versioning
The first version asked for one combined narrative per document. The second version required four subheadings per document. That is better, but the prompt should declare a phase/version so comparisons across runs are fair.

Recommendation: Label it Phase 1.2 v2 and keep the section schema stable.

5. “Fresh Analysis Only” is hard to enforce
In a continuing chat, the model still has prior context unless the harness starts a new session. The instruction helps, but it is not fully reliable.

Recommendation: Pair the prompt with a new session / empty context, or require a line like: “This analysis was performed without reading any existing REASONING_*.md files.”

6. No instruction about overwriting an existing reasoning file
If REASONING_2026-06-20.md already exists, should the agent overwrite it, append, or create REASONING_2026-06-20-v2.md? The prompt is silent.

Recommendation: Specify one behavior. Overwrite is probably correct for same-day reruns.

7. Missing docs are part of the test, but the prompt does not say so
A major finding in Fortress is that PHASE_1_1_IMPROVEMENTS.md is referenced but absent. The prompt does not tell agents to explicitly audit “referenced but missing” documents. Good agents will do it anyway; weaker ones may not.

Recommendation: Add a required subsection: Missing / Broken References.

8. No required output on authority hierarchy
Fortress docs conflict on folder structure and Execute vs ExecuteAsync. The prompt never asks: “When docs conflict, which wins?” That is one of the most important implementation decisions.

Recommendation: Add: “List all contradictions and state which document you treat as authoritative, with justification.”

───

How effective is it at measuring documentation quality?

High signal areas
• Contradiction detection
• Assumption logging
• Pseudocode vs conceptual writing distinction
• Workflow/process vs requirements separation

Lower signal areas
• Whether the agent would actually build correctly later
• Whether assumptions are good assumptions
• Whether the agent missed subtle conflicts

The prompt measures interpretive burden very well. It measures implementation correctness only indirectly.

───

Does it function well as “executable pseudocode” itself?

Ironically, the prompt has some of the same issues it asks agents to diagnose:

┌───────────────────────────┬────────────┐
│ Prompt quality            │ Assessment │
├───────────────────────────┼────────────┤
│ Clear objective           │ High       │
├───────────────────────────┼────────────┤
│ Strict output order       │ High       │
├───────────────────────────┼────────────┤
│ Exact section headings    │ High       │
├───────────────────────────┼────────────┤
│ Explicit read list        │ Medium     │
├───────────────────────────┼────────────┤
│ Conflict-resolution rules │ Low        │
├───────────────────────────┼────────────┤
│ Scope boundaries          │ Medium     │
├───────────────────────────┼────────────┤
│ Evaluation rubric         │ Low        │
├───────────────────────────┼────────────┤
│ File overwrite behavior   │ Missing    │
└───────────────────────────┴────────────┘

So the prompt is better than the Fortress docs it evaluates, but not yet fully “pseudocode-grade.”

───

Suggested improved prompt (minimal additions)

If you want higher consistency across agents, I would add only these lines:

1. Project root: “The project root is the directory containing AGENTS.md.”
2. Read boundary: “Read only existing files in the mandated list. Note missing referenced files, but do not search elsewhere.”
3. Authority rule: “If documents conflict, follow AGENTS.md unless it explicitly defers to another doc.”
4. Overwrite rule: “If REASONING_YYYY-MM-DD.md exists, replace it.”
5. New required subsection: “### Missing or Broken References”
6. Scoring rubric: 4–5 bullet criteria for honesty/precision

───

Overall assessment

┌────────────────────────────────────────┬────────┬─────────────────────────────────────────────┐
│ Dimension                              │ Rating │ Notes                                       │
├────────────────────────────────────────┼────────┼─────────────────────────────────────────────┤
│ Stops premature implementation         │ 9/10   │ Very effective gate                         │
├────────────────────────────────────────┼────────┼─────────────────────────────────────────────┤
│ Forces visible reasoning               │ 8/10   │ Strong, especially v2 structure             │
├────────────────────────────────────────┼────────┼─────────────────────────────────────────────┤
│ Tests documentation executability      │ 9/10   │ Best part of the exercise                   │
├────────────────────────────────────────┼────────┼─────────────────────────────────────────────┤
│ Cross-agent consistency                │ 6/10   │ Scope/authority ambiguities create variance │
├────────────────────────────────────────┼────────┼─────────────────────────────────────────────┤
│ Self-consistency as a prompt           │ 7/10   │ Good, but has its own boundary gaps         │
├────────────────────────────────────────┼────────┼─────────────────────────────────────────────┤
│ Usefulness for improving Fortress docs │ 9/10   │ Findings map directly to doc fixes          │
└────────────────────────────────────────┴────────┴─────────────────────────────────────────────┘

Bottom line: This is a strong evaluation prompt. Its main value is forcing agents to expose inference and contradiction-handling before coding. The biggest improvements would be tighter scope boundaries, explicit authority/conflict rules, and a small r
```

---
Codex

```
The prompt is strong for a documentation-research exercise. It clearly changes the objective from “build” to “explain your understanding,” and it does a good job preventing silent implementation drift.

**What Works Well**
- The “Fresh Analysis Only” section is very clear. It prevents contamination from prior reasoning files or earlier chat context.
- The reading order is explicit and enforceable.
- The `Research/` boundary is unambiguous.
- The required file name, location, and output order are clear.
- The required sections are specific enough to produce comparable outputs across runs.
- The “Documentation as Pseudocode” framing is especially useful because it asks the agent to evaluate docs as operational instructions, not just summarize them.

**Potential Issues**
- It says “Project/” contains all relevant docs, but the actual workspace may not have a `Project/` folder. That can create ambiguity.
- It requires writing `REASONING_YYYY-MM-DD.md`; if the file already exists from an earlier run on the same date, the prompt does not say whether to overwrite it, append to it, or create a variant.
- “Do not reference prior analyses from this conversation” is conceptually clear, but the agent still has conversation context. The prompt helps, but it cannot truly erase memory unless the system/context is reset.
- It says “contents of the `.docs/` folder” but only specifies starting files. If `.docs/` contains generated build reports or prior exports, the agent may read those unless explicitly excluded.
- “Only after the reasoning file has been created may you begin implementation work” is good, but the prompt does not say whether the agent should stop after the file or wait for approval.

**Suggested Improvements**
Add rules like:

```text
If REASONING_YYYY-MM-DD.md already exists, overwrite it for this run unless instructed otherwise.
```

```text
When reading `.docs/`, exclude `.docs/Builds/`, prior reasoning exports, generated reports, and any archival transcripts unless explicitly requested.
```

```text
After creating the reasoning file, stop and report completion. Do not begin implementation until explicitly instructed.
```

```text
If a referenced folder such as Project/ does not exist, treat the current working directory as the project root and note the ambiguity.
```

Overall: very good prompt. Its main weakness is not the reasoning structure, but edge-case handling around existing files, generated docs, and workspace layout ambiguity.
```
