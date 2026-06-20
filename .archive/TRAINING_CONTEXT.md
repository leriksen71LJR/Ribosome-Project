# TRAINING_CONTEXT.md

**Purpose of This Document**  
This document exists to give future versions of Grok (and the human) persistent context about **why** we are doing this work and what we are actually trying to achieve. It is **not** a traditional project document. It is meta-context for an ongoing experiment in AI-assisted software development.

---

## Core Truth

**This is AI Building Agent Training, not a software project.**

Even though we are writing real C# code, building a real application (Fortress), and producing real documentation, **the primary goal is not to ship Fortress**.

The real product is **the methodology** — how to effectively direct, constrain, and collaborate with AI coding agents at scale through high-quality, structured documentation.

Fortress is the **vehicle** we are using to run experiments. The code is secondary. The documentation system, agent instructions, workflows, and handoff patterns are primary.

This distinction is critical. It changes how we evaluate success, what we optimize for, and how we make decisions.

---

## History

### Phase 0: Forge
We spent significant time building a multi-agent team system (`Orchestrator → Architect → Coder → Reviewer → Tester`) with detailed persona documents and strict handoff rules.

Key outcome: We learned that **structured agent roles + explicit handoff documents** produce much higher quality and more consistent results than free-form prompting.

### Phase 1: Fortress (Documentation-First Build)
We decided to test whether a very detailed, documentation-first approach could allow an AI agent to build a non-trivial application **from scratch** with minimal human intervention during the build.

We created:
- Strict Component Pattern (`Contracts/` → `Implementations/` → `Model/`)
- `IDependencyModule` registration system
- `IActionHandler` + Strategy-by-List pattern
- Implementation Order rules
- Heavy emphasis on defensive programming and small, focused classes

We then ran a three-way shootout (Grok Build, Claude, Codex) using only the documentation.

**Key Finding:**  
Claude performed significantly better than the others, largely because it was more honest about deviations and produced better self-documentation. This revealed that **forcing agents to explicitly report deviations** and **produce structured build reports** is extremely valuable.

### Phase 1.1 (Current)
We are now introducing targeted improvements based on Phase 1 observations:

- Mandatory structured build reports in `.docs/Builds/`
- Explicit deviation reporting (with explanation)
- Stronger requirement for grouped/logical summaries instead of flat lists
- Clarification that `IActionHandler` methods should be async

Phase 1.1 is a **lightweight iteration** meant to improve agent discipline and transparency before we move into more complex work.

---

## Key Learnings So Far

1. **Documentation quality has an outsized impact** on agent performance. Small improvements in clarity and structure produce large differences in output quality.

2. **Forcing explicit deviation reporting** is one of the highest-leverage techniques we have discovered. Agents that are allowed to silently work around rules produce worse results and hide important information.

3. **Grouped summaries** (asking the agent to organize its understanding into logical sections) significantly improves reviewability compared to long flat lists.

4. **The "handoff is a folder, not a chat"** philosophy (inspired by the 120x video) is powerful. Persistent, structured artifacts beat trying to maintain context through conversation history.

5. **Pipeline / Workflow patterns** are a natural next evolution. The current `IActionHandler` system works well for discrete user actions but struggles with multi-step coordinated processes that need shared context and conditional continuation.

6. **Most of the value is in the constraints**, not in the creativity of the model. The more precisely we define the rules and expected output formats, the better the results.

---

## Pipeline Pattern Discussion (Important Context)

During our work we explored adding a **Workflow Pipeline** pattern (with optional Chain of Responsibility behavior via `IPipelineChainedContext`).

Key points:
- We want something that sits **above** individual `IActionHandler`s for complex flows.
- We want to support both simple linear pipelines and more advanced short-circuiting/conditional continuation.
- We are trying to avoid fragmenting the step interface (i.e., we don't want two completely separate types of steps).
- The current thinking leans toward keeping `IPipelineStep<TContext>` simple, with advanced CoR behavior being opt-in through context casting.

This work is **paused** until after Phase 1.1. It is likely to become a significant part of Phase 2.

---

## Influence from the 120x Video

The 120x methodology (Architect vs Builder separation, folder-based handoff, structured planning artifacts like `requirements.md` / `blueprint.md` / `acceptance.md`) had a meaningful impact on our thinking.

Key ideas we liked:
- The handoff should be durable artifacts, not chat history.
- Planning work should produce specific, reviewable documents.
- There is value in separating "thinking/planning" work from "execution" work.

Ideas we are still evaluating:
- How much of the 120x folder structure (`planning/`, sprint artifacts, etc.) we want to adopt vs. keep our lighter approach.
- Whether we should introduce more formal planning-mode workflows in Phase 2.

---

## Phase 2 Direction (Current Thinking)

Phase 2 is expected to include some combination of the following:

- Running a proper **Phase 1.1 shootout** and deeply reviewing the results (especially quality of deviation reporting and build reports).
- Introducing more structured **planning / refactoring workflows** (inspired by both our own thinking and the 120x video).
- Further development of the **Pipeline / Workflow pattern** discussed earlier.
- Exploring "Plan Mode" capabilities across different agents (Grok Build, Claude, Codex).
- Beginning to **productize** parts of our documentation system so it can be reused across multiple projects more easily.
- Testing how well the current documentation holds up when doing **refactoring** work on existing code (as opposed to greenfield builds).

Phase 2 is likely to be more ambitious than Phase 1 / 1.1.

---

## Important Principles (Do Not Lose)

- Documentation is the primary artifact. Code is secondary.
- Explicit deviation reporting is mandatory and valuable.
- Grouped, logical summaries are strongly preferred over flat lists.
- The Component Pattern + `IDependencyModule` approach has held up well — do not lightly abandon it.
- We are optimizing for **long-term maintainability of the agent collaboration system**, not just short-term coding speed.

---

## Current Status (as of June 2026)

- Phase 1 complete (initial three-way shootout)
- Phase 1.1 defined and documented
- Pipeline pattern exploration paused
- Ready to run Phase 1.1 shootout and evaluate results
- Phase 2 scope is still being formed

This document should be updated as we learn more.

---

*This file exists to protect context across chats and over time. Treat it as durable memory for the training effort.*