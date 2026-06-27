# Phase 2 — Perspectives Investigation

**Date:** 2026-06-21  
**Purpose:** Investigate the 9 items using multiple perspectives/angles to generate and catalogue high-quality ideas before moving into design or implementation.

**Organizing Principle:** Primary organization is by **Item**. The 9 perspectives are used as investigative angles within each item to surface ideas, risks, and opportunities.

---

## Item 1: How far should “Documentation as Program” be pushed?

**Core Idea:** Need for clear criteria to decide when to use prose vs structured/pseudocode in agentic development.

**Key Ideas from Perspectives:**
- There is growing interest in hybrid approaches that balance human readability with machine usability.
- Structured prompting frameworks can help reduce ambiguity when precision matters.
- Over-structuring risks harming human comprehension and increasing maintenance burden.

**Most Relevant Perspectives Applied:**
- Effort vs Impact
- Human vs Build Agent Experience
- Long-term Maintainability

**Notable Ideas:**
- Define lightweight guidelines for when to shift from prose to structured formats.
- Avoid trying to make all documentation fully executable.

**Key Risks / Open Questions:**
- Risk of over-engineering if pushed too far.
- How to maintain readability for humans while improving agent reliability?

---

## Item 2: Ribosome Model formalization & first Workflow Handler implementation

**Core Idea:** Making explicit what “minimal invention” means and how to support or measure it in the system.

**Key Ideas from Perspectives:**
- Related concepts focus on reducing non-determinism and making assumptions explicit.
- Reliable agentic systems research emphasizes observability of reasoning and grounding in specifications.

**Most Relevant Perspectives Applied:**
- Risk Perspective
- Effort vs Impact
- Alignment with Phase 1.2A
- Sequencing & Dependencies

**Notable Ideas:**
- Formalize what “minimal invention” looks like in practice (e.g., required disclosure of assumptions, decisions taken, and recommended documentation improvements).
- Define base Workflow Handler responsibilities and required outputs.

**Key Risks / Open Questions:**
- If too rigid, could limit useful agent behavior.
- If too loose, the model loses value.

---

## Item 3: Explicit Decision Procedures + Avoiding process theater

**Core Idea:** Creating useful decision procedures without creating heavy or performative processes.

**Key Ideas from Perspectives:**
- Research favors lightweight, embedded decision practices over separate heavy governance layers.
- Over-formalization tends to be ignored or gamed.

**Most Relevant Perspectives Applied:**
- Risk Perspective
- Effort vs Impact
- Human vs Build Agent Experience
- Metrics & Success Criteria

**Notable Ideas:**
- Design the Decision Procedure Registry to be deliberately lightweight (max ~1 page per procedure).
- Seed the registry from real ambiguities (e.g., from Phase 1.2A shootouts) rather than theory.

**Key Risks / Open Questions:**
- Risk of creating process theater if not kept lightweight.
- How to ensure procedures are actually used rather than ignored?

---

## Item 4: Minimal viable Workflow Handler abstraction + First real Workflow Pipeline example

**Core Idea:** Strengthening the Workflow Handler model while integrating new requirements into existing systems.

**Key Ideas from Perspectives:**
- Mature systems prefer integrating additional signals into existing reports rather than creating new parallel artifacts.
- Clear separation between C# internal contracts and Web API contracts is important.

**Most Relevant Perspectives Applied:**
- Risk Perspective
- Alignment with Phase 1.2A
- Sequencing & Dependencies
- Edge Cases & Failure Modes

**Notable Ideas:**
- Integrate Invention Disclosure into `BuildDisclosure.md` (as structured subsections + one summary table) instead of creating a new artifact.
- Differentiate handling between internal C# contracts and Web API contracts.

**Key Risks / Open Questions:**
- Risk of fragmenting the single build report we consolidated in Phase 1.2A.
- How to apply this consistently across different types of handlers?

---

## Item 5: Stale Examples Override Current Rules + Missing PHASE_1_1_IMPROVEMENTS.md Specification

**Core Idea:** Automatically detecting and addressing stale or missing documentation.

**Key Ideas from Perspectives:**
- Automated drift detection is mature in infrastructure and can be adapted for documentation.
- Effective techniques include schema change detection and freshness SLAs.

**Most Relevant Perspectives Applied:**
- Effort vs Impact
- Long-term Maintainability
- Edge Cases & Failure Modes

**Notable Ideas:**
- Add automated staleness/drift detection as part of the Documentation Audit step.
- Treat missing critical content as technical debt that should be restored.

**Key Risks / Open Questions:**
- Automation might create false positives or miss nuanced staleness.
- How much should be automated vs human-reviewed?

---

## Item 6: Reconcile contradictory folder structure + Resolve Execute vs ExecuteAsync inconsistency

**Core Idea:** Automatically detecting and resolving contradictions across documentation.

**Key Ideas from Perspectives:**
- Automated consistency and drift detection tools are increasingly used.
- The trend is toward continuous, automated checking rather than periodic manual reviews.

**Most Relevant Perspectives Applied:**
- Effort vs Impact
- Alignment with Phase 1.2A
- Edge Cases & Failure Modes

**Notable Ideas:**
- Add automated consistency scanning between key documents as part of the Documentation Audit.

**Key Risks / Open Questions:**
- Risk of over-investing in cleanup versus higher-leverage work.
- How to prioritize which contradictions matter most?

---

## Item 7: Documentation Audit as mandatory workflow step

**Core Idea:** Elevating documentation quality checks to a required step in the build/delivery process.

**Key Ideas from Perspectives:**
- Leading practice is moving toward hybrid automated + human documentation audits as part of CI/CD.
- CI/CD pipelines are increasingly used to enforce compliance, quality gates, and audit trails.

**Most Relevant Perspectives Applied:**
- Effort vs Impact
- Sequencing & Dependencies
- Metrics & Success Criteria

**Notable Ideas:**
- Define a minimum mandatory Documentation Audit checklist.
- Integrate it as a formal (but not overly heavy) step in the build pipeline.
- Use recurring invention patterns as a trigger for documentation improvements.

**Key Risks / Open Questions:**
- Risk of becoming bureaucratic if not carefully scoped.
- How to balance automation with necessary human judgment?

---

## Item 8: Explicit Workflow Handler registration pattern

**Core Idea:** Clean patterns for registering handlers and enabling controlled extensibility.

**Key Ideas from Perspectives:**
- Registry and plugin patterns are well-established for managing dynamic components.
- Capability-based and self-registering approaches help scale extensibility without central bottlenecks.

**Most Relevant Perspectives Applied:**
- Long-term Maintainability
- Sequencing & Dependencies
- Archaeology / Future Maintenance

**Notable Ideas:**
- Define a clear registration and validation process for Workflow Handlers.
- Support capability declarations to enable more flexible discovery.

**Key Risks / Open Questions:**
- Risk of over-engineering the registration system early.
- How to handle versioning and deprecation cleanly?

---

## Item 9: Gamification / Observability tooling strategy without Goodhart’s Law

**Core Idea:** Designing observability focused on reasoning quality rather than simple outcome metrics.

**Key Ideas from Perspectives:**
- Strong consensus that narrow metrics in agentic systems often trigger Goodhart’s Law.
- Better approaches focus on tracing reasoning, tool use, and decision paths.

**Most Relevant Perspectives Applied:**
- Risk Perspective
- Human vs Build Agent Experience
- Metrics & Success Criteria

**Notable Ideas:**
- Design observability around making reasoning and invention visible.
- Avoid implementing strong scoring or gamification systems that could distort behavior.

**Key Risks / Open Questions:**
- High risk of Goodhart effects if metrics are poorly designed.
- How to surface invention signals without creating perverse incentives?

---

## Cross-Perspective Synthesis

**Strongest Recurring Themes:**
- Making invention visible without creating heavy new artifacts.
- Reducing ambiguity through lightweight, embedded mechanisms.
- Strong preference for **integration** into existing systems rather than new parallel processes.
- Repeated warnings about **process theater** and **Goodhart effects**.

**Highest Potential Ideas So Far:**
- Decision Procedure Registry (lightweight, seeded from real ambiguities).
- Integrating Invention Disclosure into `BuildDisclosure.md`.
- Automated drift/staleness detection as part of Documentation Audit.

**Open Questions:**
- How to balance structure with flexibility across different types of work?
- Where should human judgment remain mandatory vs where automation is sufficient?

---

**End of Phase 2 Perspectives Investigation**