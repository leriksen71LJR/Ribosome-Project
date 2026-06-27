**Primer: Fortress Research Project – Documentation Architecture for AI Coding Agents**

**Prepared for:** Technical coworker working with AI coding agents  
**Date:** 2026-06-23

---

### 1. The Core Problem

When AI coding agents are given specifications, they frequently make implementation decisions in areas where the documentation is silent, ambiguous, or incomplete. These decisions are referred to as **invention**.

Over time, invention leads to inconsistent behavior across agents, hidden assumptions, and increased long-term maintenance cost. The central premise of this research is that many of these problems stem from documentation that fails to make important decisions, risks, and recurring patterns explicit.

---

### 2. Project Origin

The work began while building **Fortress**, a secure personal information manager developed primarily with AI coding agents. Early builds showed that agents frequently diverged in how they handled cross-cutting concerns and ambiguous requirements, even when given detailed specifications.

This led to a series of experiments focused on improving how documentation is structured and expressed when the primary reader is an AI agent.

---

### 3. Conceptual Evolution

Early work explored highly granular documentation, breaking many concerns into small, dedicated files. While this increased visibility of individual decisions, it also created navigation overhead and fragmentation.

Later work moved toward greater consolidation through component-level plugin files. This improved navigability and executability but made certain cross-cutting concerns and recurring decision patterns less visible.

Current work focuses on a more balanced approach — making important seams and strategies explicit without recreating excessive fragmentation, while paying closer attention to governance and long-term maintainability.

---

### 4. Core Conceptual Models

#### The Ribosome Model

Documentation is treated as analogous to mRNA. The documentation contains the specifications, while the build agent acts as the ribosome that translates it into working code.

**Example:**  
When the specification for applying encryption keys to database connections was incomplete, different agents handled key application inconsistently. This is analogous to faulty mRNA producing inconsistent results. The model frames such problems as documentation quality issues rather than purely agent limitations.

#### Build Disclosure

Build Disclosure is a required post-build report in which agents must explicitly document their decisions, assumptions, deviations, and areas where they had to invent behavior.

**Example:**  
An agent once had to decide what to do when a user entered the wrong master password. Because the documentation was unclear, it chose to show an error and remain locked. The agent reported this decision and the documentation gap in its Build Disclosure, making the missing behavior visible so it could be addressed.

#### Recipe, Ingredients, and Connector Pattern

This model distinguishes three levels of documentation:

- **Recipe** documents define general rules and philosophy that apply across the system.
- **Ingredient** documents contain the specific, executable details for individual components.
- **Connector** documents map relationships between the general rules and specific implementations.

**Example:**  
In Fortress, the original structure made it difficult to answer a basic question: “Where do I look to understand how components should be registered and validated?” Some rules lived in one document, others were scattered across multiple plugin files, and still others were only implied. The Recipe / Ingredients / Connector model aims to reduce this confusion by clearly separating general rules (`COMPONENTS.md`), component-specific details (`PLUGIN.md` files), and the mapping between them (`REGISTRY.md`).

---

### 5. Current Operating Model and Key Relationships

The project operates with four primary roles:

- **Research** analyzes problems, develops concepts, and produces guidance documents. It surfaces tensions and offers reasoned recommendations without making final decisions.

- **Steward** is a specialized build agent whose *exclusive* role is the architecture and curation of the documentation system. The Steward does **not** write production code. Its focus is on designing, organizing, and maintaining the structure, clarity, and long-term integrity of the documentation.

- **Build Agents** implement code based on the documentation. Their primary role is to interpret and apply the documentation faithfully while reporting gaps, inventions, and recurring patterns they encounter.

- **Director** is the human in the loop. The Director provides oversight, makes final decisions on major architectural and process directions, and ensures alignment between Research, the Steward, and the Build Agents.

This model creates a clear separation of concerns: Build Agents focus on implementation, the Steward focuses exclusively on documentation architecture and curation, Research generates analysis and proposals, and the Director maintains human oversight and final authority.

---

### 6. Phase 2.1 Direction

Phase 2.1 focuses on evolving the documentation architecture in a controlled way. Key areas include:

- Making **seams** (points of ambiguity or cross-component friction) more visible and structured.
- Treating recurring **strategies** (named, selectable approaches to common problems) as explicit documentation when they meet defined criteria.
- Introducing a lightweight **Registry** layer to connect high-level rules with component-specific details.
- Establishing better practices for the **lifecycle** of documentation artifacts over time.

**Example of a Seam:**  
The interaction between the Security and Storage components around encryption key application is a seam. The storage service must apply the derived encryption key to every database connection, but the original specification did not clearly define responsibility or timing. Making this seam explicit reduces the chance of agents inventing different solutions.

**Example of a Strategy:**  
A **Disclosure Strategy** could define consistent rules for how and when agents should report invention and assumptions in build reports. Without such a strategy, each agent may disclose different levels of detail, reducing the overall usefulness of build feedback.

---

### 7. Key Tensions Being Navigated

Several fundamental tensions are actively considered:

- **Visibility vs. Weight**: Making seams and strategies explicit improves clarity but increases the volume of documentation that must be maintained.
- **Early Structure vs. Emergent Understanding**: Creating explicit structures early can reduce inconsistency, but risks turning provisional decisions into lasting parts of the system too soon.
- **Agent Role in Maintenance**: Regular Build Agents can effectively surface gaps and drift. The Steward, as the dedicated documentation architect, holds primary responsibility for reviewing proposals and maintaining the integrity of the documentation system.
- **Intentional Granularity**: Applying explicit structure only where it adds meaningful value, rather than reflexively creating new files.

---

This primer provides an overview of the project’s origins, conceptual development, current operating model, and direction. It is intended as an accessible introduction for someone working with AI coding agents who wants to understand the thinking behind this work.