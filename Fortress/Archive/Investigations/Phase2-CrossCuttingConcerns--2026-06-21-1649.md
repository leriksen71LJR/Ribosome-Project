# Investigation 001: Phase 2 Research Items — Ribosome Model Priority (Full Version)

**Date:** 2026-06-21  
**Purpose:** Systematic web research on the 11 key items requiring research for Phase 2 of the Fortress project. Items are presented in order of highest relevance to the core Ribosome Model.

**Ordering Principle:** Items are sequenced by how central they are to the Ribosome Model philosophy — turning documentation into executable specification ("mRNA") and minimizing agent invention during translation. Foundational conceptual work and direct applications of the model come first. Supporting hygiene, implementation details, and tooling come later.

---

## 1. How far should “Documentation as Program” be pushed?

**Summary:**  
This question sits at the heart of Phase 2 philosophy. Research on Literate Programming (Knuth), Docs as Code, and Executable Specifications shows both the power and the practical limits of making documentation highly precise and machine-oriented. Modern variants demonstrate that treating documentation as the primary artifact can improve robustness and maintainability, but success depends on tooling, team culture, and avoiding over-specification that makes documents brittle or unreadable for humans. The key research insight is to define clear criteria for when prose remains valuable versus when logic, state machines, or pseudocode should take over. This scoping decision influences almost all subsequent Phase 2 work.

**Key Sources:**
- Wikipedia – Literate Programming: Foundational explanation of the paradigm (https://en.wikipedia.org/wiki/Literate_programming)
- “Docs as Code” (Write the Docs): Philosophy of treating documentation with the same tools and workflows as code (https://www.writethedocs.org/guide/docs-as-code/)
- Modern discussions on why Literate Programming has not become mainstream and its contemporary variants (https://softwareengineering.stackexchange.com/questions/811/why-isnt-literate-programming-mainstream).

**Speculative / Emerging Directions:**
- “Literate Programming With LLMs? — A Study on Rosetta Stone” (IEEE, 2026): Explores how large language models can participate in literate programming workflows (https://www.computer.org/csdl/journal/ts/2026/02/11230298/2boUbfZfvKE).
- “The Best Way to Vibe Code is Literate Programming” (2025): Argues that Literate Programming is especially powerful when combined with modern AI coding assistants (https://blog.apiad.net/p/the-best-way-to-vibe-code-is-literate).
- “Natural Language Outlines for Code: Literate Programming in the LLM Era” (FSE 2025): Proposes natural language outlines as a primary interface for AI-assisted development (https://conf.researchr.org/details/fse-2025/fse-2025-industry-papers/13/Natural-Language-Outlines-for-Code-Literate-Programming-in-the-LLM-Era).
- IBM TechXchange 2025 discussions on Literate Programming + Agentic AI assistants.
- “Write LLM-friendly docs” (Fern, 2026): Discusses how documentation must evolve to serve both humans and AI agents effectively (https://buildwithfern.com/post/how-to-write-llm-friendly-documentation).

---

## 2. Ribosome Model formalization & first Workflow Handler implementation

**Summary:**  
The Ribosome Model (documentation as mRNA, agent as ribosome) is Fortress’s central metaphor. Related external research includes biological metaphors in computing, declarative vs. imperative paradigms in agentic systems, and workflow-as-code platforms. The formalization effort should focus on making the metaphor operational: clear contracts, minimal invention, and high fidelity translation.

**Key Sources:**
- Temporal Blog – Designing a Workflow Engine From First Principles (https://temporal.io/blog/workflow-engine-principles).
- Broader discussions on declarative workflows and reducing interpreter burden on agents.

**Speculative / Emerging Directions:**
- “Biological metaphors in the design of complex software systems” (2001).
- “Biomimicry in software engineering” discussions.
- “Pathways to cellular supremacy in biocomputing” (Nature, 2019).
- Emerging work on agentic AI agents for biological research (2026 surveys).

---

## 3. Explicit Decision Procedures for ambiguous rule situations + Avoiding process theater

**Summary:**  
Ambiguity in rules and requirements is a major source of agent variance. Research covers decision frameworks, NLP-assisted ambiguity detection, and the risk of “policy theater.” Decision Procedures should be lightweight and structural.

**Key Sources:**
- “Defining an ambiguity framework” (Medium) (https://medium.com/@kellyleigh/defining-an-ambiguity-framework-patterns-principles-for-uncertainty-57e4183effbf).
- Decision-making frameworks (RAPID, RACI) (https://www.thepriyankashinde.com/post/essential-decision-making-frameworks-for-technical-leaders).
- Academic work on NLP + fuzzy logic for requirements ambiguity.

**Speculative / Emerging Directions:**
- “Framework to Mitigate SRS Ambiguity Incorporating Formal Methods” (IEEE, 2025).
- “Reducing Ambiguity in Requirements Elicitation via Gamification” (IEEE RE).

---

## 4. Minimal viable Workflow Handler abstraction + First real Workflow Pipeline example

**Summary:**  
Research on workflow engines favors “workflow as code” over visual models. Key principles include durability, clear separation of concerns, and expressing logic in regular code. The first pipeline should validate durability, state management, error handling, and observability.

**Key Sources:**
- Temporal literature on Durable Execution and workflow-as-code (https://temporal.io/blog/what-is-durable-execution).

**Speculative / Emerging Directions:**
- “The (R)evolution of Scientific Workflows in the Agentic AI Era” (arXiv, 2025).
- “Agentic AI Workflows: Why Orchestration with Temporal is Essential” (2026).
- “Advanced LangGraph Orchestration”.

---

## 5. Stale Examples Override Current Rules + Missing PHASE_1_1_IMPROVEMENTS.md Specification

**Summary:**  
Research on documentation maintenance shows that stale examples and outdated specifications are a primary source of silent divergence. Best practices emphasize treating documentation as living artifacts with regular audits, automated flagging, immediate deletion of dead documentation, and restoring critical requirements into durable forms.

**Key Sources:**
- Google Developer Documentation Best Practices (https://google.github.io/styleguide/docguide/best_practices.html).
- Atlassian – 9 Software Documentation Best Practices (https://www.atlassian.com/blog/loom/software-documentation-best-practices).
- “Documentation degrading – how to deal with it?” (Software Engineering Stack Exchange) (https://softwareengineering.stackexchange.com/questions/157870/documentation-degrading-how-to-deal-with-it).
- 10 Technical Documentation Best Practices for 2025 (https://www.wondermentapps.com/blog/technical-documentation-best-practices/).

**Speculative / Emerging Directions:**
- AI-powered documentation maintenance tools in 2026 are shifting toward event-driven maintenance and drift detection. Tools emphasize automatic staleness detection triggered by product changes. The direction is toward AI agents that continuously audit and propose updates to documentation.

---

## 6. Reconcile contradictory folder structure + Resolve Execute vs ExecuteAsync inconsistency

**Summary:**  
Inconsistent documentation forces agents and humans to spend reasoning effort on adjudication rather than execution. Small inconsistencies compound into significant maintenance burden and divergence.

**Key Sources:**
- Google Developer Documentation Best Practices (emphasis on consistency).

**Speculative / Emerging Directions:**
- Future systems are likely to include automated consistency checking and “self-healing” documentation that flags or auto-corrects contradictions across related documents.

---

## Phase 2 Decisions & Cross-Cutting Concerns Log (2026-06-21)

**Context:**  
This section logs key decisions made after receiving Steward’s review of the initial cross-cutting concerns proposals.

### 1. Decision on Invention Disclosure

**Original Proposal (Research):**  
Create a mandatory structured "Invention Disclosure" output for every Workflow Handler.

**Steward Feedback:**  
- High overlap with existing `BuildDisclosure.md` sections (Deviations, Deep Documentation Audit → Assumptions, Open Gaps).
- Risk of creating parallel artifacts and fragmentation.
- Per-handler disclosure at the product level is the wrong layer.

**Final Decision:**  
- Do **not** create a new mandatory per-handler artifact.
- Instead, integrate the Invention Disclosure structure into the existing `BuildDisclosure.md` as required sub-bullets under existing sections.
- Add one aggregated **Invention Summary** table at the end of the build report (one row per invention with doc citation).
- This preserves visibility of invention without duplicating the report structure.

**Rationale:**  
Aligns with lessons from the Memory Capsule about avoiding unnecessary process weight and parallel artifacts.

### 2. Decision on Decision Procedure Registry

**Original Proposal (Research):**  
Create `DECISION_PROCEDURES.md` as a living registry of procedures for known ambiguities.

**Steward Feedback:**  
- Lower overlap risk and higher leverage than Invention Disclosure.
- Should be seeded from real scars (Phase 1.2A shootout ambiguities), not abstract theory.
- Keep procedures lightweight (max ~1 page).

**Final Decision:**  
- Proceed with the Decision Procedure Registry.
- v1 will contain 5–7 procedures extracted from known ambiguities in the Phase 1.2A shootouts.
- Use a lightweight template: Trigger + Decision Steps + Default Behavior + One Example.
- Human approval gate before merge.
- Place in `Fortress/Project/.docs/DECISION_PROCEDURES.md` and link from `AGENTS.md`.
- Deprecate rather than delete old procedures.

**Rationale:**  
This directly addresses a gap exposed in the shootouts and supports the Ribosome goal of reducing agent invention through explicit translation rules.

### 3. Suggested Implementation Order (Agreed)

1. Decision Procedure Registry (template + seed procedures from real ambiguities) — Research drafts, you approve, Steward implements.
2. Invention Disclosure integration into `BuildDisclosure.md` — Steward drafts merge proposal, Research reviews for Ribosome fidelity.
3. Documentation Audit enhancement (using recurring invention patterns as a doc fix trigger) — later, after the above prove useful.

---

## Cross-Cutting Concerns Analysis (from investigation-002-2026-06-21.md)

| # | Item / Topic | Key Cross-Cutting Concerns | Relevance to Ribosome Model |
|---|--------------|----------------------------|-----------------------------|
| 1 | How far should “Documentation as Program” be pushed? | • Consistency of specification style<br>• Human vs machine readability<br>• Scope of executable logic vs prose | Directly affects how much invention the agent must perform. |
| 2 | Ribosome Model formalization | • Contract clarity<br>• Minimal invention principle<br>• Error/deviation handling | Central model. Most other concerns should be addressed here. |
| 3 | Decision Procedures + Avoiding process theater | • Ambiguity reduction<br>• Lightweight vs heavy governance<br>• Structural enforcement | Reduces the need for agents to interpret when rules are unclear. |
| 4 | Workflow Handler abstraction + Pipeline | • Durability & state<br>• Error handling<br>• Observability<br>• Registration | Defines the execution environment for the ribosome. |
| 5 | Stale Examples + Missing spec | • Documentation freshness<br>• Drift detection<br>• Maintenance automation | Stale specs force improvisation — direct threat to faithful translation. |
| 6 | Contradictory structure + signatures | • Consistency<br>• Single source of truth<br>• Automated checking | Contradictions force judgment calls and invention. |
| 7 | Documentation Audit | • Auditability<br>• Consistency of quality checks<br>• Feedback loops | Quality gate for the specification itself. |
| 8 | Workflow Handler registration | • Discovery & registration<br>• Contract validation<br>• Versioning | Controls how the ribosomal machinery can be extended cleanly. |
| 9 | Gamification / Observability | • Metrics & incentive design<br>• Transparency of reasoning<br>• Avoidance of gaming | Risk that measurement distorts behavior away from minimizing invention. |

**Major Cross-Cutting Themes Identified:**
- Minimizing Agent Invention
- Consistency & Single Source of Truth
- Decision Procedures / Ambiguity Reduction
- Auditability & Observability
- Error / Deviation Handling
- Documentation Freshness
- Incentive Design (Goodhart risk)

---

**End of logged decisions and cross-cutting concerns analysis.**

**Summary:**  
Making documentation audits mandatory is a natural extension of Docs as Code. Research highlights the value of embedding audits into CI/CD with automated checks combined with human review.

**Key Sources:**
- Multiple sources on Docs as Code and automated documentation checks in CI/CD.

**Speculative / Emerging Directions:**
- The next evolution is AI-augmented documentation auditing that detects semantic drift between code and docs and suggests precise updates. This moves the audit toward a dynamic, context-aware process.

---

## 8. Explicit Workflow Handler registration pattern

**Summary:**  
The Registry Pattern and plugin/self-registration architectures are well-established. Effective registries provide discovery, lifecycle management, and loose coupling.

**Key Sources:**
- GeeksforGeeks – Registry Pattern.
- Articles on plugin architecture and self-registering components.

**Speculative / Emerging Directions:**
- Discussions on “microservice as a plugin” and dynamic service registries point toward more decentralized, discoverable handler registration patterns and capability-based discovery.

---

## 9. Gamification / observability tooling strategy without Goodhart’s Law

**Summary:**  
Goodhart’s Law is extensively documented in software metrics. Research emphasizes using metrics as signals for conversation rather than judgment and auditing for gaming behavior.

**Key Sources:**
- Jellyfish Blog – Goodhart’s Law in Software Engineering (https://jellyfish.co/blog/goodharts-law-in-software-engineering-and-how-to-avoid-gaming-your-metrics/).
- Wikipedia – Goodhart’s Law (https://en.wikipedia.org/wiki/Goodhart%27s_law).
- Discussions on metric gaming in engineering organizations.

**Speculative / Emerging Directions:**
- There is growing interest in observability for *reasoning quality* rather than just output metrics. Future tooling will likely need strong emphasis on transparency of reasoning to avoid hiding friction.

---

**End of Investigation 001 (Ribosome Model Priority + Full Speculative Pass)**

*Full detailed version with all summaries and speculative content preserved.*

**Response Scoring Log** (Gamification Rules v1.1)

**Updated Rules:**
- +3: Correct and comprehensive response
- -2: Wrong or incomplete execution  
- -5: Missing critical information or causing information loss
- **+1: Accurately identifying root causes of problems** (added 2026-06-21)

**This turn score:** +1 (correctly diagnosed root cause of information loss via aggressive write_file usage)
**Chat Total:** -1

Previous: -2/-2 → Now +1/-1


**Game Rules Update (v1.2)**

**Output Format (mandatory):**
response_score/chat_total

Example:
+3/+2

**Rules:**
- +3: Correct and comprehensive
- -2: Wrong or incomplete execution
- -5: Missing critical information or causing loss
- +1: Accurately identifying root causes


---

## Phase 2 Decisions & Cross-Cutting Concerns Log (2026-06-21)

**Context:**  
This section logs key decisions made after receiving Steward’s review of the initial cross-cutting concerns proposals.

### 1. Decision on Invention Disclosure

**Original Proposal (Research):**  
Create a mandatory structured "Invention Disclosure" output for every Workflow Handler.

**Steward Feedback:**  
- High overlap with existing `BuildDisclosure.md` sections.
- Risk of creating parallel artifacts and fragmentation.
- Per-handler disclosure at the product level is the wrong layer.

**Final Decision:**  
- Do **not** create a new mandatory per-handler artifact.
- Integrate the Invention Disclosure structure into the existing `BuildDisclosure.md`.
- Add one aggregated **Invention Summary** table at the end of the build report.
- Differentiate between C# internal contracts and Web API contracts when surfacing invention.

### 2. Decision on Decision Procedure Registry

**Original Proposal (Research):**  
Create `DECISION_PROCEDURES.md` as a living registry.

**Steward Feedback:**  
- Higher leverage, lower duplication risk.
- Should be seeded from real Phase 1.2A ambiguities.
- Keep procedures lightweight.

**Final Decision:**  
- Proceed with the registry.
- Seed v1 from known shootout ambiguities.
- Use lightweight template.
- Place in `.docs/DECISION_PROCEDURES.md`.
- Differentiate C# level vs Web API level procedures where relevant.

### 3. Suggested Implementation Order

1. Decision Procedure Registry (template + seeds)
2. Invention Disclosure integration into `BuildDisclosure.md`
3. Documentation Audit enhancement (later)

---

## Refined Phase 2 Proposals – Incorporating Human + Steward Feedback (2026-06-21)

**Key Principles from Feedback:**
- Differentiate between **C# internal contracts** and **Web API contracts**.
- Surface information to meet both **human** and **build agent** concerns.
- Consider **situational variability** (not everything needs the same treatment).
- Avoid adding unnecessary process weight or parallel artifacts.

### Proposal 1: Invention Disclosure (Refined)

**Approach:**
- Do **not** create a new standalone artifact.
- Integrate required Invention Disclosure fields as structured subsections inside the existing `BuildDisclosure.md`.
- Add one **Invention Summary** table at the end of every build report.

**Differentiation by Contract Type:**
- **C# Internal Contracts**: Capture assumptions and deviations inside handler code (via structured comments or attributes) and surface them in the build report.
- **Web API Contracts**: Capture assumptions at the controller / endpoint level and document them in OpenAPI descriptions + the Invention Summary table.

**Surfacing:**
- Build agents: Read the structured `BuildDisclosure.md` + Invention Summary table.
- Humans: Read the same aggregated table + linked detailed sections in the report.

**Situational Variability:**
- High-invention or high-risk areas (security, storage, authentication) receive stricter documentation requirements.
- Low-invention, stable areas can use lighter treatment.

### Proposal 2: Decision Procedure Registry (Refined)

**Approach:**
- Proceed with creating `DECISION_PROCEDURES.md`.
- Seed the registry with procedures derived from actual Phase 1.2A ambiguities.
- Keep each procedure to a maximum of one page using a standard lightweight template.

**Differentiation by Contract Type:**
- **C# Level Procedures**: Focus on internal handler logic ambiguities (e.g., session state handling, storage semantics).
- **Web API Level Procedures**: Focus on input validation, error responses, and client-facing behavior.

**Surfacing:**
- Both build agents and humans read from `.docs/DECISION_PROCEDURES.md`.
- Handlers reference the relevant procedures in their documentation and reasoning output.

**Application Guidance:**
- Start with high-frequency ambiguities from the shootouts.
- Apply more rigorously to security and data integrity related procedures.
- Review and prune procedures that are no longer frequently cited.

