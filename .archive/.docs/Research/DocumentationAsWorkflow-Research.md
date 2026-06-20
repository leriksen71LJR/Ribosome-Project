# Documentation as Workflow – Research Overview

**Date:** June 2026  
**Status:** Research / Primary Direction  
**Primary Model:** The Ribosome Model (Stateless Workflow Coordinator)  
**Purpose:** Define and explore the Ribosome Model — a stateless workflow engine where documentation itself acts as the executable process, and incoming tasks/specs are treated purely as data.

---

## 1. Core Idea — The Ribosome Model

We are building our own **ribosome** — the first workflow engine where **documentation is the engine**, not just the fuel or the map.

### Biological Metaphor (Why "Ribosome")

In biology:
- **mRNA** carries the instructions (pure data). It does not build anything by itself.
- **Ribosome** is the molecular machine. It reads the mRNA according to a fixed, highly structured set of rules and produces a functional protein through a repeatable, stateless translation process.
- The ribosome has **no creativity** and **no autonomy** over the process. Its fidelity comes from structural mechanisms, not intelligence.

### Translation to AI Agent Systems

- **Spec / Task** = mRNA (pure data — the "what")
- **Workflow / Documentation** = Ribosome (the engine — the "how")
- **Agent** = The cellular environment (provides context and execution substrate)
- **Output** (code, tests, build reports, audits) = The folded, functional protein

This model enforces a strict separation:
- The workflow is **stateless** by design.
- The incoming task/spec is treated as **pure input data**.
- The documentation defines the **process**, control flow, validation gates, and enforcement mechanisms.
- The agent is **guided or forced** through the defined path ("entice first, Spanish Inquisition when needed").

"There can be only one!" — At the top level, there is one primary ribosome (the main workflow engine) that all significant work passes through.

---

## 2. Key Concepts & Terminology

Several overlapping ideas are currently being explored:

| Concept                          | Core Belief                                                                 | Key Difference from Traditional Docs          | Current Maturity |
|----------------------------------|-----------------------------------------------------------------------------|-----------------------------------------------|------------------|
| **Spec-Driven Development (SDD)**    | Specifications should be the primary artifact that drives implementation, testing, and validation | Specs become executable and versioned         | Growing quickly |
| **Documentation as Control Plane**   | Documentation should actively orchestrate agent behavior rather than just inform it | Strong emphasis on structure, flow, and state | Early but influential |
| **Executable Documentation**         | Documentation should be testable and verifiable by agents                   | Focus on validation and feedback loops        | Emerging |
| **Workflow-Oriented Prompting**      | Complex tasks should be broken into explicit, stateful workflows            | More procedural and less open-ended           | Active research |
| **Promptware Engineering**           | Applying software engineering rigor (requirements, design, testing) to prompts and documentation | Treats documentation as engineered artifacts  | Still forming |

These concepts overlap significantly but come from slightly different communities (software engineering, AI agent research, and developer tooling).

---

## 3. Major Research Directions

### Direction A: Specification as the Source of Truth
This direction argues that the specification (or high-quality documentation) should be the **single source of truth** from which code, tests, and behavior are derived.

**Notable voices:** Addy Osmani and various teams at Google and Microsoft have written about this in 2025. The idea is that if the spec is clear and structured enough, agents (and humans) should be able to generate correct implementations with far less ambiguity.

**Strengths:** Reduces drift between intent and implementation.  
**Weaknesses:** Requires extremely high-quality specifications. Most current documentation does not meet this bar.

### Direction B: Documentation as Workflow / Orchestration Layer
This view treats documentation more like a **workflow definition language**. It contains explicit steps, decision points, state tracking, and error handling paths.

The documentation essentially becomes the coordinator. Agents follow the defined flow rather than being given high-level goals and left to figure out the process themselves.

This direction is closer to ideas found in workflow orchestration frameworks (LangGraph, CrewAI patterns, etc.) but applied to documentation.

**My opinion:** This is the most promising direction for our use case. It aligns with treating documentation as a coordinator object rather than a loose collection of rules.

### Direction C: Executable Specifications & Feedback Loops
Some researchers focus on making documentation **executable and self-validating**. The idea is that agents should be able to run or test the documentation itself and report back on its effectiveness.

This often includes structured output requirements (such as build reports and audits) so the documentation can be evaluated and improved over time.

**My opinion:** This is valuable but secondary. Feedback loops are important, but they depend on first having well-structured documentation worth evaluating.

### Direction D: Promptware / Documentation Engineering
This is a broader movement applying traditional software engineering practices (versioning, testing, modularity, refactoring) to prompts and documentation.

It tends to be more pragmatic and tool-oriented than purely theoretical.

---

## 4. The Stateless Workflow Coordinator Model (Proposed Primary Direction)

This is the model we are currently exploring as our **primary direction** ("There can be only one").

### Core Principles

- **Spec / Task = Data**  
  The incoming task or specification is treated purely as input data. It describes *what* needs to be built (requirements, acceptance criteria, constraints).

- **Workflow = Process**  
  The workflow is a separate, stateless definition of *how* the agent must work. It defines the steps, control flow, validation gates, and enforcement mechanisms.

- **Workflow is Stateless**  
  The workflow document itself does not accumulate state across different builds or sessions. Any state required during execution lives in the agent's working context or in explicitly produced artifacts.

- **Strong Separation of Concerns**  
  Requirements (the "what") are kept cleanly separated from process (the "how"). This prevents the common problem of specs becoming bloated with process instructions.

- **Enforcement Philosophy ("Entice First, Spanish Inquisition When Needed")**  
  The workflow should first *entice* the agent to follow the path through clarity and good design. When that is not enough, it uses hard rules, mandatory gates, and explicit consequences for deviation.

### Why This Model

Most current approaches (including many Spec-Driven Development templates) still blend the "what" and the "how" into a single document or linear flow. This model deliberately separates them so the workflow can act as a reusable coordinator that any task can be fed into.

---

## 5. Extensibility via Explicitly Registered Workflow Handlers

One of the central challenges with a stateless workflow engine is **evolution**. If the core workflow document is meant to remain stable and stateless, how do we extend its behavior over time without constantly editing the main ribosome?

### The Proposed Solution: Explicit Registration + Parent Orchestration

We borrow the spirit of the **Strategy by List<T>** pattern already used for `IActionHandler`, but with important restrictions that preserve the "There can be only one!" coordinator philosophy:

- **Explicit Listing, Not Auto-Discovery**  
  Workflow handlers (small, focused extension documents) are **explicitly declared** inside the parent workflow document that uses them. The agent does not scan a folder and automatically compose everything it finds. This keeps behavior deterministic, auditable, and under the control of the parent workflow.

- **Multiple Independent Handler Lists**  
  A single workflow can maintain several separate lists of handlers for different concerns (e.g., pre-implementation checks, post-audit enforcers, violation reporters). Each list is owned and orchestrated by its parent document. There is no single global "plugin" registry.

- **Parent Orchestration, Not Plugin Architecture**  
  The parent workflow document decides **when** and **how** each handler is invoked. Handlers do not insert themselves arbitrarily into the flow. This prevents the chaos of true plugin systems while still allowing controlled extensibility.

This design keeps the core ribosome stable while giving us a clean mechanism to evolve behavior over time.

### Conceptual Structure

```
.docs/
├── Workflows/
│   ├── BuildWorkflow.md                 ← The core ribosome (relatively stable)
│   └── Extensions/                      ← Small, focused handler documents
│       ├── EnforceVerticalSlicing.md
│       ├── RequireDocumentationAudit.md
│       └── StrongViolationReporting.md
```

**Example excerpt from `BuildWorkflow.md`:**

```markdown
# Build Workflow (Core Ribosome)

## Phase 1: Initialization
- Read AGENTS.md and the current Phase prompt
- Confirm understanding of Output Location Rule and Violation Reporting Rule

## Phase 2: Implementation
- Follow core implementation steps defined in ARCHITECTURE.md
- **Apply PreImplementationHandlers** (explicitly listed below)

### PreImplementationHandlers
- EnforceVerticalSlicing.md
- RequireTDD.md

## Phase 3: Validation & Audit (Mandatory Gate)
- Execute DocumentationAudit procedure
- **Apply PostAuditHandlers**
    - StrongViolationReporting.md

## Phase 4: Final Output & Exit
- Produce BUILD report with required sections
- Verify no unreported violations exist
```

Each handler document would follow a consistent, small contract (Name, When to Run, What it Must Do, What constitutes Success/Failure). The parent workflow remains the single source of truth for orchestration order and conditions.

### Why This Approach

| Concern                        | Why Explicit Registration + Parent Orchestration Wins |
|--------------------------------|-------------------------------------------------------|
| **Predictability**             | Agent behavior is determined by what the parent explicitly lists, not by what happens to exist in a folder. |
| **Maintainability**            | The core `BuildWorkflow.md` stays relatively stable. New concerns are added as small, focused handlers. |
| **Auditability**               | A reviewer can see exactly which handlers are active for any given workflow simply by reading the parent document. |
| **Avoiding Plugin Chaos**      | No implicit composition or surprising side-effects. The parent stays in control. |
| **Alignment with Ribosome**    | The core translation machinery remains stable. Extensions act like regulatory elements that are called at defined points. |

This pattern gives us **extensibility without mutation** of the primary workflow engine — exactly what a long-lived stateless ribosome needs.

---

## 6. Key Contributors and Their Work

| Person / Group                  | Notable Contribution                                                                 | Relevance to Us | Style / Emphasis                     |
|--------------------------------|--------------------------------------------------------------------------------------|------------------|--------------------------------------|
| **Addy Osmani**                | Strong advocate for **Spec-Driven Development**. Pushes the idea that high-quality specifications should be the primary artifact from which code and tests are generated. | Very High       | Pragmatic, engineering-focused      |
| **Mitchell Hashimoto**         | Has discussed documentation and infrastructure as a **control plane** for systems and tooling. Emphasizes structure and predictability. | High            | Systems / infrastructure thinking   |
| **Matt Pocock**                | Developed a practical end-to-end AI coding workflow featuring the "Grill Me" alignment session, PRD creation, vertical slicing ("tracer bullets"), and the "Ralph Loop" (TDD-driven agent implementation with strong feedback). Strong emphasis on feedback loops and human-in-the-loop for planning/review. | Very High       | Highly practical, engineering discipline |
| **LangGraph Team (LangChain)** | Developed one of the most widely used frameworks for building **stateful, multi-step agent workflows**. Focuses on explicit control flow, state, and cycles. | High            | Workflow orchestration              |
| **CrewAI Contributors**        | Popularized structured, role-based agent teams with defined processes and handoffs. | Medium-High     | Agent team orchestration            |
| **Write the Docs Community**   | Long-standing movement around treating documentation with engineering rigor (versioning, testing, automation). | Foundational    | Documentation engineering           |

**Notes on the Landscape:**
- Much of the most practical progress is happening in the **agent framework space** (LangGraph, CrewAI, etc.) rather than in pure documentation theory.
- **Matt Pocock** currently stands out as one of the strongest *practical* implementations of a disciplined workflow for AI coding agents. His "Grill Me" technique is a powerful forcing function for alignment before any planning or coding begins.
- There is still no single dominant framework or methodology. Most serious practitioners are mixing ideas from multiple sources.

---

## 7. Matt Pocock's Workflow in Context

Matt Pocock's "Full Walkthrough: Workflow for AI Coding" (April 2026) is one of the most concrete and battle-tested workflows publicly available as of mid-2026.

### Key Elements of His Approach

- **Grill Me Session**: Before any planning, the agent is forced to interview the human relentlessly until ambiguity is resolved and shared understanding is reached. This is a major enforcement mechanism.
- **PRD Creation**: The aligned understanding is turned into a structured Product Requirements Document.
- **Vertical Slicing**: Work is broken into thin, end-to-end "tracer bullet" slices rather than horizontal layers. This enables faster feedback loops.
- **Ralph Loop**: The agent follows a TDD-style cycle (pick task → write failing tests → implement → run feedback → commit → repeat).
- **Human-in-the-Loop for Planning & Review**: Planning and final review remain human-driven. Implementation can run with higher autonomy.

### Relation to the Stateless Workflow Coordinator Model

| Aspect                        | Matt Pocock's Workflow                          | Stateless Workflow Coordinator Model                  | Alignment / Gap |
|-------------------------------|------------------------------------------------|-------------------------------------------------------|-----------------|
| **Separation of "What" vs "How"** | Mostly blended (PRD contains both requirements and process guidance) | Explicitly separated (Task = Data, Workflow = Process) | Partial alignment. Pocock keeps them closer together. |
| **Enforcement Mechanisms**    | Strong ("Grill Me", TDD, vertical slices, feedback loops) | Strong by design (mandatory gates, violation paths)   | High alignment in spirit. |
| **Stateless Workflow**        | Workflow lives partly in prompting + skills    | Workflow is fully externalized into documentation     | Gap. Pocock's workflow is still heavily prompt/skill-driven. |
| **Reusability**               | Moderate (skills can be reused)                | High (named, reusable procedures and workflows)       | Opportunity to extend his ideas. |
| **Feedback & Audit**          | Strong human review + automated tests          | Required Documentation Audit as a gate                | Compatible. We can formalize this further. |

**My Current Take:**  
Matt Pocock's workflow is currently one of the best *practical* systems available. It demonstrates real engineering discipline and strong forcing functions. However, it still keeps a significant portion of the workflow inside prompting and custom skills rather than fully externalizing it into documentation as a stateless coordinator.

This makes it an excellent reference and partial inspiration for Phase 2, but not yet the complete realization of the model we're pursuing.

---

## 8. Common Patterns Emerging

Across these directions, several recurring ideas appear:

- **Explicit Control Flow**: Clear sequencing and decision points instead of open-ended instructions.
- **State Management**: Documentation that tells the agent what information it should track.
- **Reusable Procedures**: Named sections that can be referenced across documents.
- **Violation / Error Paths**: Defined behavior when rules cannot be followed.
- **Structured Output**: Required formats for reports, audits, and artifacts.
- **Feedback Mechanisms**: Built-in ways for agents to report on the quality of the documentation.

These patterns are still evolving and have not yet converged into widely accepted standards.

---

## 9. Limitations and Open Problems

Current approaches still face several challenges:

- **Over-structuring risk**: Too much rigidity can reduce agent flexibility and creativity where it is actually useful.
- **Maintenance burden**: Workflow-style documentation can become brittle and expensive to maintain as systems evolve.
- **Agent capability gap**: Many current models still struggle with long, complex, stateful workflows without significant prompting support.
- **Lack of tooling**: There are few mature tools for authoring and maintaining documentation as workflows.
- **Evaluation difficulty**: It is still hard to objectively measure whether one documentation structure produces better agent behavior than another.

---

## 10. My Current Assessment

| Aspect                        | Assessment                                      | Confidence |
|-------------------------------|--------------------------------------------------|----------|
| **Conceptual Strength**       | Strong. The idea of documentation as a coordinator has real merit. | High |
| **Practical Maturity**        | Still early. Most examples are either conceptual or applied in narrow domains. | Medium |
| **Relevance to Fortress**     | High. Our current direction (clear rules, violation reporting, audits) is compatible with this thinking. | High |
| **Risk of Over-Engineering**  | Medium-High. It is easy to make documentation overly complex in pursuit of structure. | Medium |
| **Long-term Potential**       | Promising, especially if combined with template-driven approaches. | Medium-High |

The most valuable takeaway so far is the shift in mindset: moving from “documentation that informs” to “documentation that coordinates and constrains.”

---

## 11. Open Questions

- How much structure is too much?
- Should we aim for a single unified workflow document or many small, composable procedures?
- How do we balance explicit control flow with the need for agents to handle novel situations?
- What is the right level of formality for our scale and goals?

---

---

*This document treats the Ribosome Model (Stateless Workflow Coordinator) as the primary direction. Other approaches (Spec-Driven Development, Matt Pocock’s workflow, LangGraph-style orchestration) are treated as valuable references and partial inspirations, not competing alternatives. We are building one engine.*
