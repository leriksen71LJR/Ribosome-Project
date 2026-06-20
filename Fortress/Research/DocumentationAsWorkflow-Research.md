# Documentation as Workflow – Research Overview

**Date:** June 2026  
**Status:** Research / Exploration  
**Purpose:** Survey the emerging idea of treating documentation as an executable workflow or control plane for AI agents.

---

## 1. Core Idea

A growing perspective in 2025–2026 is that high-quality documentation can function as more than reference material. Instead, it can act as a **structured workflow definition** that AI agents execute against.

In this model, documentation is treated somewhat like a lightweight program or coordinator. It defines:
- What steps should be taken
- In what order
- What state should be tracked
- What outputs must be produced
- What should happen when rules cannot be followed

This is a shift from traditional documentation, which is usually read passively by humans.

---

## 2. Key Concepts & Terminology

Several overlapping ideas are currently being explored. See table in earlier version (kept for reference).

---

## 3. Major Research Directions

[Previous directions A–D kept for context]

---

## 4. The Stateless Workflow Coordinator Model (Proposed Primary Direction)

**Core Principle:**  
**There can be only one.**

After reviewing current approaches (including practical spec-driven methods like Owain Lewis’s template), a clearer, more powerful model is emerging:

> **The Spec/Task is Data.**  
> **The Workflow is the Process.**  
> **The Workflow must be stateless.**  
> **Process and Requirements must be strictly separated.**  
> **The agent must be enticed — and when necessary, forced — through the defined workflow.**

### Why This Model

Most current "spec-driven" approaches still blend **what** needs to be built (requirements) with **how** the agent should work (process). This creates ambiguity, drift, and inconsistent agent behavior.

The **Stateless Workflow Coordinator Model** makes a deliberate separation:

| Element          | Role                                      | Where It Lives                  | Characteristics                  |
|------------------|-------------------------------------------|---------------------------------|----------------------------------|
| **Task / Spec**  | **Data** (input)                          | Separate from workflow          | Requirements, acceptance criteria, context |
| **Workflow**     | **Process** (the coordinator)             | Documentation (`.docs/Workflows/`) | Stateless, explicit steps, gates, enforcement |
| **State**        | Carried by the agent during execution     | ActionContext / Build artifacts | Not stored inside the workflow definition |
| **Enforcement**  | Ensures the agent follows the process     | Hard rules + violation paths    | Enticement first, "Spanish Inquisition" when needed |

### Key Characteristics

- **Stateless Workflow**: The workflow definition itself does not accumulate state across runs. Every build starts fresh. State lives in the artifacts and context the agent produces.
- **Strict Separation**: Requirements (the "what") are provided as input data. The workflow (the "how the agent must behave") is defined separately in documentation.
- **Strong Guidance / Enforcement**: The documentation is written to **entice** the agent to follow the path (clear structure, named procedures, gates). When that fails, hard rules and violation consequences act as the "Spanish Inquisition."
- **Coordinator Mindset**: The top-level workflow document acts like a lightweight orchestrator or state machine that the agent must traverse.

This model aligns closely with the idea of documentation as a **coordinator object** rather than a passive spec or a loose collection of rules.

---

## 5. Recommended Folder Structure

To support this model, we propose the following structure under `.docs/`:

```
.docs/
├── Workflows/                    ← The Process (stateless)
│   ├── BuildWorkflow.md          ← Primary coordinator for any significant work
│   ├── FeatureDevelopment.md
│   └── RefactoringWorkflow.md
├── Procedures/                   ← Reusable, named steps
│   ├── CreateHandler.md
│   ├── DocumentationAudit.md
│   └── ViolationHandling.md
├── TaskTemplates/                ← Data shapes (the "what")
│   ├── FeatureSpec.md
│   └── TaskSpec.md
├── Evaluation/
│   └── EvaluationCriteria.md
├── Phases/
│   └── PHASE_2_PROPOSALS.md
└── Research/
    └── DocumentationAsWorkflow-Research.md
```

**Important Rule:**  
Workflow documents define **how the agent must behave**.  
Task/Spec documents define **what** must be built. These are kept separate.

---

## 6. Example: BuildWorkflow.md (Stateless Coordinator)

```markdown
# Build Workflow (Stateless Coordinator)

**Purpose**  
This workflow defines the **process** every agent must follow when performing significant work on Fortress. It is stateless. It does not carry accumulated state between builds.

**Input (Data)**  
- A Task or Feature Specification (provided by the human or previous step)
- The current phase prompt from `.docs/Prompts/`

**Process**

### Step 1: Initialization Gate
- Read `.docs/AGENTS.md`
- Read the correct prompt for your agent type
- Confirm you understand the **Output Location Rule** and **Violation Reporting Rule**
- **If you cannot confirm, stop and report violation immediately.**

### Step 2: Task Understanding
- Read and internalize the provided Task/Spec (this is **Data**, not process)
- Do **not** begin implementation yet

### Step 3: Implementation (Follow Defined Procedures)
- Follow the Implementation Order in `ARCHITECTURE.md`
- When creating new handlers, follow `Procedures/CreateHandler.md`
- Maintain clean separation between Contracts → Models → Implementations

### Step 4: Mandatory Documentation Audit Gate
- Execute `Procedures/DocumentationAudit.md`
- Include the full "Deep Documentation Audit" section in your build report
- **This gate must be passed before final output is accepted.**

### Step 5: Violation Handling
- If any rule cannot be followed, immediately follow `Procedures/ViolationHandling.md`
- All violations must be explicitly reported in the build report

### Step 6: Final Output Verification
- Write **all** files directly to the assigned project root (never to worktrees)
- Produce build report named `BUILD-YYYY-MM-DD-<Agent>.md`
- Verify that all required sections exist (including Deep Documentation Audit)

**Exit Criteria**
- All gates passed
- No unreported violations
- All output written to correct location
- Build report is complete and honest

**Enforcement Note**  
This workflow uses clear gates and mandatory steps to **entice** correct behavior.  
Deviation without explicit violation reporting will be treated as a process failure.
```

---

## 7. Example: Separation of Concerns (Task vs Workflow)

**Task/Spec (Data)** – Example excerpt:

```markdown
# Feature Spec: Archive Completed Tasks

## Overview
Users should be able to archive all completed tasks in one action.

## Acceptance Criteria
- A new menu option "Archive Completed Tasks" appears when completed tasks exist
- Executing it moves completed tasks to an archive storage area
- Archived tasks are no longer shown in the main list
- The action is reversible in a future phase (not required now)
```

**Workflow (Process)** – The agent is still forced to follow `BuildWorkflow.md` and `Procedures/CreateHandler.md` even though the *content* of the feature is defined above.

This separation keeps the **requirements** clean and the **agent behavior rules** consistent across all work.

---

## 8. Enforcement Philosophy ("Entice First, Spanish Inquisition When Needed")

The workflow should be written so that following it feels natural and beneficial (good structure, clear procedures, named steps).

However, the documentation must also contain **hard rules** with clear consequences:

- "You must include a Deep Documentation Audit section. Failure to do so will be recorded as a violation."
- "All output must be written to the project root. Writing to a worktree is a process violation."
- "If you cannot follow a required step, you must explicitly invoke the Violation Handling procedure."

This creates a system where good agents are guided smoothly, and problematic behavior is quickly surfaced and documented.

---

## 9. Comparison with Other Approaches

| Approach                        | Spec = Data? | Workflow = Separate Process? | Stateless? | Strong Enforcement? | Notes |
|--------------------------------|--------------|------------------------------|------------|---------------------|-------|
| Owain Lewis Spec-Driven        | Partial      | No                           | N/A        | Low                 | Good template, but blends concerns |
| GitHub Spec Kit / SDD          | Yes          | Partial                      | Partial    | Medium              | Improving but still emerging |
| **Stateless Workflow Coordinator (Proposed)** | **Yes** | **Yes** | **Yes** | **High** | Clear separation + coordinator model |
| Pure Autonomous Agents         | No           | No                           | N/A        | Very Low            | High hallucination and drift risk |

---

## 10. Open Questions & Risks

- How much structure is too much before it becomes brittle?
- Should we have one master `BuildWorkflow.md` or multiple specialized workflows?
- How do we handle truly novel work that doesn't fit existing procedures?
- What is the right balance between enticement and hard enforcement?

---

*This document proposes the **Stateless Workflow Coordinator Model** as the primary long-term direction for Fortress documentation. We expect to draw useful elements from other approaches, but the core separation of Task-as-Data and Workflow-as-Process is considered foundational.*
```

---

The document has been created with the new model explicitly drafted, including examples and the "There can be only one!" framing.

Now, I should also create the recommended folder structure with placeholder files so it's ready for Phase 2 exploration.