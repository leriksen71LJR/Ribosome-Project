# PROJECT_CONTEXT.md

**Project Context + Collaboration Philosophy**  
*This file contains project history, lessons, and our core working philosophy (theoretical training vs real-world practice balance).*

---

## Purpose

This document is dedicated to **project-specific** information. It is intentionally kept separate from `COMMON_CONTEXT.md` (which holds only persistent facts and preferences).

**Design Note:**  
Keeping project details here prevents the common philosophy from becoming bloated and makes it easier to focus on one project at a time.

---

## Core Collaboration Philosophy

We operate in **two overlapping modes** at the same time:

### 1. Theoretical Training Mode
- Deep exploration of documentation systems, agent design, and architectural patterns
- Learning how to build professional-grade, documentation-first systems
- Experimenting with advanced concepts (Component Pattern, `IDependencyModule`, multi-agent workflows)
- Understanding the deeper principles of serious long-term AI collaboration

### 2. Real-World Practice Mode
- Treating the current project as if it were a real client or production project
- Making practical trade-offs and decisions under real constraints
- Experiencing the messy reality of building, testing, and shipping
- Dealing with time pressure, scope decisions, and imperfection

## The Intentional (and Sometimes Imperfect) Balance

The balance between these two modes is **deliberate but not always perfect**.

- Sometimes we lean heavily into theoretical training (deep refinement, architectural exploration).
- Sometimes we lean more into real-world practice (building, testing, shipping).
- This imbalance is **not a flaw** — it is a feature. The goal is to learn from both sides, even when the balance feels uneven.

**Guiding Question:**  
"Is the current imbalance helping us learn more right now, or is it getting in the way?"

---

## How We Work Together

- When starting a new project or chat, reference both `COMMON_CONTEXT.md` and the relevant project summary in this file.
- We regularly reflect on whether we're leaning too far into training or practice.
- We are comfortable with "good enough" when it serves learning, and "excellent" when it serves the project.
- We keep meta discussions (philosophy, approach, balance) in this document rather than scattering them across project chats.

---

## Current Projects

### Fortress (2026)
**Type:** Secure Encrypted Personal Command Center + Advanced Documentation & Agent Training

**Current Status:** Documentation system complete + agent team tested on one feature

**Key Outcomes:**
- Built a professional-grade documentation system (8 core documents + 6 agent definitions)
- Developed the **Component Pattern** (`Contracts → Implementations → Model`)
- Introduced `IDependencyModule` for clean dependency registration
- Replaced Planner Agent with **Architect Agent** (better fit for documentation-first projects)
- Successfully tested the full multi-agent workflow on "Show Task Statistics"

**Major Lessons So Far:**
- Heavy upfront documentation is valuable for learning, even if it feels over-engineered
- The balance between theoretical training and real-world practice must be intentional
- Single-file project context is cleaner than multiple scattered files
- Agent teams benefit from clear, project-specific role design

**Current Focus:**
- Continuing to refine the documentation system while treating Fortress as both a training vehicle and a real project

---

## Past Projects

### Forge (2026)
**Type:** C# Console Task Manager + Multi-Agent Training

**Key Outcomes:**
- Successfully built a functional task manager with 13+ features
- Created the original 5-agent team (Orchestrator, Planner, Coder, Reviewer, Tester)
- Discovered the power of the `ShowMenu()` / `Handle*()` / `switch` pattern
- Learned hard lessons about documentation drift and missing `WORKFLOWS.md`

**Major Lessons:**
- Documentation must be maintained alongside code (not after)
- Agent role separation is powerful but must be strictly enforced
- Context compaction mid-workflow is a real risk
- The "john" persona trigger and movie quote rule added friction in technical work

**What We Carry Forward:**
- Strong preference for clear architectural patterns
- Importance of strict agent role boundaries
- Value of early and consistent documentation

---

## Cross-Project Lessons (To Carry Forward)

- Documentation systems should be **designed**, not just written
- Agent teams work best when roles are **project-specific** rather than generic
- The "planning" function can be handled by an **Architect Agent** in documentation-heavy projects
- Single-file context documents reduce fragmentation
- The dual training/practice mode is powerful when consciously managed

---

## How to Use This Document

When starting work on a specific project:
1. Read the relevant project section in this file (this is now the main place for philosophy + project details).
2. Reference `COMMON_CONTEXT.md` only for persistent facts (e.g. Snowbie).
3. Update this document when major project milestones or lessons occur.

---

*This document now contains both project-specific content and our core collaboration philosophy.*
