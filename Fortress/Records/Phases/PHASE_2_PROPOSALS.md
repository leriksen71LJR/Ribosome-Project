# PHASE_2_PROPOSALS.md

**Status:** Draft / For Discussion  
**Created:** June 2026  
**Purpose:** Capture thinking and proposals for Phase 2 of the AI Building Agent Training project.

---

## 1. Context: What Phase 1 and 1.1 Taught Us

Phase 1 showed us that agents can build a non-trivial .NET console application from documentation alone, but with varying degrees of fidelity, self-awareness, and discipline.

Phase 1.1 introduced two important process improvements:
- Mandatory structured build reports (`BUILD-*.md`)
- Explicit deviation reporting

These changes improved transparency, but they are still relatively lightweight process controls. They do not yet address deeper questions about **how** we want agents to plan and execute work over longer horizons.

Phase 2 should move beyond "make the agent follow the rules better" and into **how we structure the work itself**.

The central long-term vision emerging from our work is the **Ribosome Model** — a stateless workflow engine where documentation itself acts as the executable process (the ribosome), and incoming tasks/specs are treated purely as data (mRNA). A deeper exploration lives in `.docs/Research/DocumentationAsWorkflow-Research.md`.

---

## 2. Two Major Influences on Phase 2 Thinking

### A. The 120x Video (Architect / Builder Methodology)

The video demonstrated a mature, folder-based handoff system with strong separation between planning and execution.

**Key ideas that resonated:**

- **"The handoff is a folder, not a chat."**  
  Context should live in durable, structured files rather than ephemeral conversation history.

- **Strong separation between Architect and Builder roles.**  
  One agent (or mode) is responsible for discovery, planning, risk assessment, and producing high-quality written artifacts. Another is responsible for implementation against those artifacts.

- **Planning folder structure** (`planning/`) containing:
  - `STATE.md`
  - `DECISIONS.md`
  - `DOMAIN.md`
  - `RISKS.md`
  - `QUESTIONS.md`
  - `FILE_INVENTORY.md`

- **Sprint structure** with four consistent artifacts per sprint:
  - `requirements.md`
  - `blueprint.md`
  - `acceptance.md`
  - `handoff-prompt.md`

- **AGENTS.md as the canonical router** that every agent reads first.
- Thin model-specific adapter files (`CLAUDE.md`, `CODEX.md`) that point back to `AGENTS.md`.

**Strengths observed:**
- Very strong on long-term context management and reducing "chat drift."
- Excellent at forcing explicit planning before coding.
- Scales well to multi-sprint projects.

**Weaknesses / Risks for our context:**
- The system is quite heavy. It may be overkill for the current size and complexity of Fortress.
- It assumes a relatively mature project with clear boundaries. Our current work is still somewhat exploratory.
- The strict Architect/Builder split may reduce the value of having one agent do end-to-end work during training.

### B. Workflow Pipeline Pattern (Our Internal Discussion)

During our extended design sessions, we explored adding a first-class **Workflow Pipeline** capability alongside the existing `IActionHandler` pattern.

**Core ideas:**
- `IPipelineStep<TContext>` + `IPipeline<TContext>` (which inherits from the step interface)
- Optional `IPipelineChainedContext<TContext>` for true Chain of Responsibility behavior inside pipelines
- `PipelineStepResult`
- `IPipelineExecutor<TContext>` as a stateless engine
- Support for both simple linear pipelines and advanced short-circuiting / conditional continuation

**Why this direction felt important:**
- Many real features (export, import, backup, complex reporting, data migration, etc.) are naturally multi-step processes with shared state.
- Forcing everything into single `IActionHandler` implementations creates awkward or bloated code.
- This pattern has proven extremely useful in other systems we've built.

**Current Status of the Design:**
- We have a reasonably solid interface design, but it has not been implemented or tested in code yet.
- There is still healthy tension between "keep it simple" and "give advanced steps real control."

---

## 3. Phase 2 Strategic Options

We see three main directions Phase 2 could take (they are not mutually exclusive):

### Option 1: Adopt 120x-Style Planning & Sprint System (Documentation-First Evolution)

**Focus:** Improve how we *plan and structure work* before any code is written.

**Proposed changes:**
- Introduce a `planning/` folder with the key state documents.
- Define a standard sprint artifact structure (`requirements.md`, `blueprint.md`, `acceptance.md`, `handoff-prompt.md`).
- Make `AGENTS.md` even stronger as the single source of truth.
- Create thin adapter files for different agents.
- Potentially introduce an "Architect Mode" vs "Builder Mode" distinction in prompts.

**Pros:**
- Directly addresses context management and long-term project coherence.
- Aligns with our goal of making high-quality documentation the primary artifact.
- Would likely improve the quality of plans before implementation begins.

**Cons:**
- Adds significant process overhead.
- May slow down the tight feedback loops we currently enjoy during training.
- Risks turning simple feature work into heavy ceremony.

### Option 2: Implement and Mature the Workflow Pipeline Pattern (Code Pattern Evolution)

**Focus:** Give agents (and future human developers) a proper tool for building multi-step, stateful workflows.

**Proposed changes:**
- Finalize the `IPipelineStep<TContext>`, `IPipeline<TContext>`, and `IPipelineChainedContext<TContext>` interfaces.
- Implement `IPipelineExecutor<TContext>`.
- Add guidance in `CODING_DESIGN.md` and `ARCHITECTURE.md` on when to use `IActionHandler` vs `IPipeline`.
- Create one or two real examples inside Fortress (e.g., a more sophisticated Export or Backup workflow).
- Update the agent prompts to understand and respect the new pattern.

**Pros:**
- Directly solves a real architectural gap in the current Fortress design.
- Gives us a powerful, reusable pattern that can be used across many future projects.
- The design work is already mostly done — we would be moving from discussion to implementation.

**Cons:**
- This is more of a "code pattern" improvement than a "how we work with agents" improvement.
- It may not address the bigger context and planning problems we saw in Phase 1.

### Option 3: Hybrid / Staged Approach (Recommended)

**Phase 2a (near term):**
- Introduce lightweight planning artifacts (especially `DECISIONS.md` and `RISKS.md`) without going full 120x sprint structure.
- Strengthen `AGENTS.md` and add a `planning/` folder with minimal required files.
- Run one or two features using this lighter planning approach and evaluate.

**Phase 2b (after we have data):**
- Decide whether to go deeper on the 120x-style system or stay lighter.
- Simultaneously implement the Workflow Pipeline pattern, as it is largely orthogonal to the planning system.

**Pros:**
- Lower risk. We can learn from real usage before committing to heavy process.
- Allows us to improve both planning discipline *and* code architecture in the same phase.
- Keeps momentum while still moving the project forward meaningfully.

**Cons:**
- Slightly less decisive than picking one clear direction.

---

## 4. Recommendation

Given that our primary goal is **training better AI building agents**, I recommend **Option 3 (Hybrid)** with the following emphasis:

1. **Prioritize improvements to planning and context management** (inspired by the 120x video) because this had the biggest visible impact on output quality in Phase 1.
2. **Treat the Workflow Pipeline pattern as a first-class code architecture deliverable** in Phase 2, because it solves a real gap and we already did most of the thinking.
3. Keep the process changes relatively lightweight in the first half of Phase 2 so we can gather data before making heavier commitments.

We should also explicitly decide whether Phase 2 is primarily about:
- Making *agents* better at long-running, well-planned work, or
- Making the *Fortress codebase* a better example of clean architecture.

These two goals are related but not identical.

---

## 5. Open Questions for Discussion

- How heavy do we actually want the planning process to become during training?
- Should we introduce an explicit "Planning Mode" (similar to Plan Mode in Grok Build) as part of Phase 2?
- Do we want to start productizing the documentation system itself in Phase 2 (making it reusable across multiple projects), or keep the focus narrow on Fortress?
- How should the Workflow Pipeline pattern interact with the existing `IActionHandler` system? Should most multi-step work eventually move to pipelines?

---

*This document is intentionally open-ended. Its purpose is to capture current thinking so we can make better decisions once we have data from Phase 1.1.*