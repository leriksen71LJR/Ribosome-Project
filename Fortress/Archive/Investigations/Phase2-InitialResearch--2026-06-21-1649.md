# Investigation 001: Phase 2 Research Items — Ribosome Model Priority

**Date:** 2026-06-21  
**Purpose:** Systematic web research on the 11 key items requiring research for Phase 2 of the Fortress project. Items are presented in order of highest relevance to the core Ribosome Model.

**Ordering Principle:** Items are sequenced by how central they are to the Ribosome Model philosophy — turning documentation into executable specification ("mRNA") and minimizing agent invention during translation. Foundational conceptual work and direct applications of the model come first. Supporting hygiene, implementation details, and tooling come later.

---

## 1. How far should “Documentation as Program” be pushed?

**Summary:**  
This question sits at the heart of Phase 2 philosophy. Research on Literate Programming, Docs as Code, and Executable Specifications shows both the power and the practical limits of making documentation highly precise and machine-oriented. The key insight is to define clear criteria for when prose remains valuable versus when logic, state machines, or pseudocode should take over. This scoping decision influences almost all subsequent Phase 2 work.

**Key Sources:**
- Wikipedia – Literate Programming
- “Docs as Code” (Write the Docs)

**Speculative / Emerging Directions (Deepened):**
- “Literate Programming With LLMs? — A Study on Rosetta Stone” (IEEE, 2026): Explores how large language models can participate in literate programming workflows.
- “The Best Way to Vibe Code is Literate Programming” (2025): Argues that Literate Programming is especially powerful when combined with modern AI coding assistants, moving beyond one-shot generation toward holistic, narrative-driven development.
- “Natural Language Outlines for Code: Literate Programming in the LLM Era” (FSE 2025): Proposes natural language outlines as a primary interface for AI-assisted development.
- IBM TechXchange 2025 discussions on Literate Programming + Agentic AI assistants: Shows industry interest in reviving Knuth’s ideas for AI-augmented development workflows.
- “Write LLM-friendly docs” (Fern, 2026): Discusses how documentation must evolve to serve both humans and AI agents effectively as agent usage grows.

---

## 2. Ribosome Model formalization & first Workflow Handler implementation

**Summary:**  
The Ribosome Model is Fortress’s central metaphor. Related external research includes biological metaphors in computing, declarative paradigms in agentic systems, and workflow-as-code platforms. The formalization effort should focus on making the metaphor operational: clear contracts, minimal invention, and high-fidelity translation.

**Key Sources:**
- Temporal and durable execution literature.
- Broader discussions on declarative workflows.

**Speculative / Emerging Directions:**
- “Biological metaphors in the design of complex software systems” (2001, still relevant): Explores genetics, neurology, and immunology metaphors for software.
- “Biomimicry in software engineering” discussions: Examines nature as a “super system metaphor” for sustainable and resilient architectures.
- “Pathways to cellular supremacy in biocomputing” (Nature, 2019): Explores domains where biological computing might outperform traditional computers — interesting parallel thinking for specification-driven systems.
- Emerging work on agentic AI agents for biological research (2026 surveys): Shows how biological metaphors are being operationalized in modern AI agent architectures.

---

## 3. Explicit Decision Procedures for ambiguous rule situations + Avoiding process theater

**Summary:**  
Ambiguity in rules is a major source of agent variance. Research covers decision frameworks, NLP-assisted ambiguity detection, and the risk of “policy theater.” For Phase 2, Decision Procedures should be lightweight and structural rather than heavy governance processes.

**Key Sources:**
- “Defining an ambiguity framework” (Medium)
- Decision-making frameworks (RAPID, RACI)
- Academic work on NLP + fuzzy logic for requirements ambiguity.

**Speculative / Emerging Directions:**
- “Framework to Mitigate SRS Ambiguity Incorporating Formal Methods” (IEEE, 2025): Proposes translating vague requirements into precise mathematical models.
- “Reducing Ambiguity in Requirements Elicitation via Gamification” (IEEE RE): Explores gamified approaches to surfacing ambiguity.
- Research on formal methods and decision procedures in requirements engineering for reducing interpreter burden on agents/systems.

---

## 4. Minimal viable Workflow Handler abstraction + First real Workflow Pipeline example

**Summary:**  
Research on modern workflow engines (especially durable execution platforms) favors “workflow as code” over visual models. Key principles include durability, clear separation of concerns, and expressing logic in regular code. The first pipeline should validate durability, state management, error handling, and observability.

**Key Sources:**
- Temporal literature on Durable Execution and workflow-as-code.

**Speculative / Emerging Directions:**
- “The (R)evolution of Scientific Workflows in the Agentic AI Era” (arXiv, 2025): Explores autonomous, swarm-like agentic workflows and governance challenges.
- “Agentic AI Workflows: Why Orchestration with Temporal is Essential” (2026): Focuses on durable orchestration for non-deterministic AI agents.
- “Advanced LangGraph Orchestration”: Argues traditional engines fail for agentic systems and proposes graph-based declarative abstractions.
- Broader industry shift toward agentic workflow orchestration platforms in 2025–2026.

---

## 5–9. Remaining Items (Lower Ribosome Priority)

These items remain in their current form with existing practical + speculative content where previously added. They support the core model but are less central to the philosophical foundation.

- **5.** Stale Examples + Missing PHASE_1_1_IMPROVEMENTS.md Specification
- **6.** Contradictory folder structure + Execute vs ExecuteAsync inconsistency
- **7.** Documentation Audit as mandatory workflow step
- **8.** Explicit Workflow Handler registration pattern (includes speculative note on dynamic registries)
- **9.** Gamification / observability tooling without Goodhart’s Law

---

**End of Investigation 001 (Ribosome Model Priority + Speculative Pass)**

*Speculative layer strengthened on the top 4 items (Documentation as Program, Ribosome formalization, Decision Procedures, and Workflow abstractions).*