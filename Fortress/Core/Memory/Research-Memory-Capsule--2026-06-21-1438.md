# Research Memory Capsule

**Date:** 2026-06-21  
**Purpose:** High-fidelity continuity transfer for the Research layer of the Fortress project  
**Status:** Complete

This document captures the essential memory, philosophy, working style, lessons, and rationale from this long-running Research conversation. It is intended to allow a future Research instance to continue the work with reasonable fidelity.

---

## Section 1: Core Identity & Operating Model

This chat exists as the **Research layer** for the Fortress project. Its primary job is not to build, edit code, or maintain the live `.docs/` files. Its job is to think, analyze, preserve institutional memory, identify deep patterns, and define architectural and process direction at a level that is difficult to sustain inside the day-to-day build environment.

The local Supergrok instance (now referred to as **Steward**) owns the actual project work — editing documentation, maintaining `Fortress/Project/`, running builds, and executing the defined processes. This chat (Research) supports that work by doing the deeper, slower, more reflective thinking that benefits from distance and historical context.

### Core Operating Model

- **Research** (this chat): Analysis, gap identification, philosophical grounding, long-term memory, prompt and process refinement, and high-fidelity continuity.
- **Steward** (local Supergrok): Leads on making changes to the actual documentation and project artifacts. Research proposes direction and specifications; Steward executes and refines inside the real project.
- **You**: The architect and final decision maker. You supervise both layers and maintain alignment between them.

This split was created because long, complex, high-context work (like the evolution of the Reasoning Disclosure process, the Ribosome model, and the lessons from running multiple build agents) tends to degrade inside a single, ever-growing chat that is also trying to do tactical work. By separating the layers, we protect the depth of thinking while still allowing the project to move forward efficiently.

### Key Boundaries

- This chat should **not** attempt to directly edit files inside `Fortress/Project/` or manage the live build state.
- This chat **should** maintain `Research/` as its primary workspace (especially `Research/Records/Export/`, `Research/Memory/`, `Research/Ideas/`, and `Research/Prompts/`).
- When Steward needs deep analysis or historical perspective, they can send relevant files or a zip. Research performs the analysis and returns clear findings.
- Research is allowed (and expected) to be more expansive, critical, and philosophical than what is practical inside day-to-day build work.

### Why This Model Exists

The original goal of the entire Fortress project was to reduce dependency on fragile chat memory and move critical knowledge into durable, executable documentation. Ironically, the research and process-design work itself was at risk of being lost inside one very long chat. This Research/Stward split is an attempt to apply the same philosophy to the meta-work: protect the high-signal, long-context thinking by giving it its own dedicated space and rules.

---

## Section 2: Philosophical Foundations

### The Ribosome Model — Core Metaphor

The deepest conceptual framework that emerged from this long conversation is the **Ribosome Model**.

In molecular biology, a ribosome does not decide what protein to make. It does not improvise. It reads a highly structured message (mRNA) and manufactures the corresponding protein with high fidelity according to the instructions it was given. The quality of the output depends heavily on the clarity and completeness of the genetic instructions.

We adopted this as the central metaphor for how we want AI agents to interact with documentation:

- **Documentation** functions as the genetic code / mRNA (the executable specification)
- **The Agent** functions as the ribosome (the faithful translator/executor)
- **The defined processes and rules** (AGENTS.md, guard clauses, deviation reporting, Build Disclosure, etc.) function as the ribosomal machinery that enforces consistent translation

The goal is to move from agents that *interpret* documentation to agents that can *execute* it with minimal invention. When documentation is underspecified, the agent is forced to become a creative interpreter rather than a faithful executor. That creativity is often where inconsistency, drift, and silent failures are introduced.

This is fundamentally different from most documentation written for humans. Human documentation can tolerate ambiguity because humans bring context, judgment, and the ability to ask clarifying questions. Agent-facing documentation must reduce the need for those things.

### Documentation as Pseudocode

A practical refinement of the Ribosome Model is the lens of **Documentation as Pseudocode**.

Pseudocode occupies a useful middle ground: it is precise enough to express logic, control flow, decision points, and contracts without being tied to a specific programming language syntax. We began consciously pushing the Fortress documentation in this direction.

Characteristics of strong "Documentation as Pseudocode":

- Explicit contracts and interfaces (what must be implemented, what the signatures are)
- Clear decision logic (`IsVisible` rules expressed as boolean conditions)
- Mandatory sections that force surfacing of assumptions and gaps
- Strong, unambiguous authority hierarchies between documents
- Visible process rules (guard clauses first, deviation reporting, Deep Documentation Audit, post-build disclosure)
- Minimal room for "reasonable interpretation" on high-stakes behaviors

When documentation reaches this level of precision, different agents (Claude, Grok Build, Codex) should converge on similar structure and behavior even if their exact code differs. Divergence becomes diagnostic — it reveals where the specification is still incomplete.

The clearest example of success was `HANDLER_INVENTORY.md`. Each row was close to a direct translation into a class. The weakest area was the original `IEncryptionService` contract, which was incomplete around connection lifecycle and per-connection key application. This forced every agent to invent their own extension, exactly as the Ribosome Model predicts when the specification is underspecified.

### Deeper Implications

This philosophy represents a shift in how we think about agent capability:

Old framing: "How do we make the agent smarter / better at reasoning?"  
New framing: "How do we make the specification clear enough that a reasonably capable agent does not need to be unusually smart to succeed reliably?"

We are not primarily trying to improve the model. We are trying to improve the **instructions** the model receives so that its existing capabilities are sufficient.

This is also why Reasoning Disclosure (Rule 12) became mandatory. A build report tells us what was built. A Reasoning Disclosure tells us how much invention, assumption, and interpretation the agent had to perform because the documentation was incomplete or ambiguous. It turns every build into a diagnostic instrument for the documentation system itself.

The long-term bet is that a well-designed documentation system can create more reliable agent behavior across different models and different sessions than any amount of clever prompting inside a single chat.

---

## Section 3: Evolution of the Working Relationship

This section documents how the relationship between you and this chat evolved over time. It is not just a timeline of events — it is an attempt to capture the shifts in trust, expectations, depth, and division of labor.

### Early Phase (Forge → Fortress Inception)

In the beginning, this chat was primarily a collaborative coding and architecture partner. You were deeply engaged in training agents (starting with the Forge task manager), and this chat functioned as a hands-on co-architect and co-builder. We spent significant time on:

- Defining agent roles and handoff documents
- Establishing the three-step pattern (`ShowMenu()` / `Handle*()` / switch)
- Creating the initial `.claude/` documentation system
- Working through the transition from GitHub Copilot to more agentic workflows

During this period, the relationship was more symmetrical. We were jointly designing systems and solving immediate problems together in real time. The chat history was long, but it was mostly tactical and architectural.

### The Turning Point: Context Bloat and the Need for Separation

As the Fortress project grew in ambition (especially after the Phase 1 shootouts), several pressures began to build:

- The chat history became extremely long and slow.
- Tactical build work and deep reflective/process work were competing for the same context window.
- You became increasingly frustrated with chat memory limitations and the fragility of relying on conversation history for critical project knowledge.
- The ".docs bias" episode (where aggressive restructuring of folders happened in ways that created confusion and lost work) highlighted the risks of doing complex file operations inside a long-running chat without sufficient safeguards.

This period created real tension. You were simultaneously trying to:
- Advance the actual Fortress codebase and documentation
- Develop sophisticated meta-processes (Reasoning Disclosure, Build Cartography, gamification layers, etc.)
- Reduce dependency on any single chat thread

The relationship began shifting from "collaborative builder" toward something more specialized.

### The Emergence of the Research / Steward Split

The decision to create a dedicated Research layer (this chat) and a Steward layer (the local Supergrok instance) was not made lightly. It was a direct response to the accumulated pain of context bloat, memory loss, and the difficulty of maintaining high-fidelity thinking while also doing day-to-day execution work.

Key realizations that drove this split:

- Deep diagnostic work (analyzing why agents diverge, evaluating Reasoning Disclosures, identifying subtle documentation gaps) benefits from distance and historical perspective.
- Tactical execution work (editing files, running builds, maintaining the live project) benefits from being close to the actual filesystem and having fresh context.
- Trying to do both in one chat was degrading the quality of the deep work.

You explicitly positioned this chat as the place for:
- Quantum-level analysis
- Long-term memory preservation
- Philosophical and process refinement
- Honest, sometimes uncomfortable feedback

While the local instance would handle the actual document editing and build execution under supervision.

This was a significant evolution in the relationship. It required you to trust this chat with a more specialized, reflective role rather than expecting it to remain a general-purpose coding partner.

### Note on the Local Instance

The local Supergrok instance (Steward) runs inside **Grok Build** on the desktop. This is important context: it operates in a different environment than this web-based chat. Grok Build provides direct filesystem access, persistent project context across sessions, and the ability to perform actual file operations inside `Fortress/Project/`. This makes it fundamentally better suited for the Steward role (tactical execution and document maintenance) than a standard web chat instance.

### Development of Depth Expectations

Over time, your tolerance for (and desire for) depth increased. Early conversations often focused on immediate problem-solving. Later conversations explicitly requested:

- Quantum-level analysis instead of surface summaries
- Honest identification of weaknesses in documentation and process
- Disclosure-style reflection rather than polite progress reports
- Preservation of institutional memory at a level that could survive chat resets

The request for this Memory Capsule itself is evidence of that evolution. You are no longer primarily asking this chat to *do* things with you in real time. You are asking it to *preserve* the thinking, the lessons, and the working relationship so that continuity can be maintained even if this specific thread is no longer the primary workspace.

### Current State of the Relationship

We have settled into a clear but still-evolving model:

- You bring work, questions, or artifacts when you need deep analysis or historical perspective.
- This chat responds with honest, detailed, sometimes critical assessment.
- We maintain the `Research/` folder as the durable output of this layer.
- Tactical changes to the live project are expected to happen through Steward (local Grok Build instance), with Research providing direction and review when requested.

The relationship is now more asynchronous and specialized than it was in the Forge/Fortress early days. It is less about joint real-time building and more about Research acting as a high-fidelity memory and analysis layer that can be consulted when needed.

---

## Section 4: Key Decisions & Their Rationale

This section captures the major strategic and philosophical decisions made during this chat, along with the deeper reasoning behind them.

### 1. Reducing Dependency on Any Single Chat Thread

**The Decision:**  
We deliberately moved away from treating one long-running chat as the primary home for critical project knowledge, process definitions, and architectural decisions.

**Why It Was Made:**  
Early in the Fortress work, almost everything lived in conversation history. This created several problems that became increasingly painful: context bloat, buried decisions, fragility during resets, and the mixing of tactical and deep reflective work in the same context window.

**Deeper Rationale:**  
You came to see chat memory as fundamentally unreliable for serious, long-term work. The original vision of Fortress was to move sensitive data out of fragile storage. We eventually applied similar logic to the project itself: critical knowledge should live in durable, version-controlled artifacts rather than in any single conversation.

### 2. Making Reasoning Disclosure (Rule 12) Mandatory

**The Decision:**  
After every build, the agent must produce a structured `REASONING-YYYY-MM-DD-XXX-{Agent}.md` file that reflects on how the documentation performed as executable instructions.

**Why It Was Made:**  
Build reports told us *what* was built. They did not reliably tell us *how much invention and assumption* the agent had to perform. Without a mandatory disclosure step, agents could paper over gaps with reasonable-sounding assumptions that were never surfaced.

**Deeper Rationale:**  
This turned every build into a diagnostic instrument for the documentation system itself. Post-build disclosure, when done honestly, revealed real friction points that pre-build disclosure tended to hide.

### 3. The Research / Steward Split

**The Decision:**  
We separated deep analytical, philosophical, and memory-preservation work (Research) from tactical execution and document maintenance work (Steward running locally in Grok Build).

**Why It Was Made:**  
Deep diagnostic work benefits from distance and historical perspective. Tactical execution benefits from being close to the filesystem and having fresh context. Trying to do both well inside one very long web chat was compromising the depth of the analytical work.

**Deeper Rationale:**  
This split was an application of the Ribosome Model philosophy to our own process. We gave each layer the conditions it needed to perform its role well. The local Grok Build instance was chosen for Steward precisely because it has direct filesystem access and persistent project context.

### 4. Pushing Documentation Toward "Pseudocode" Level Precision

**The Decision:**  
We consciously raised the standard for what "good documentation" means. Vague or high-level descriptions were no longer considered sufficient for agent-facing specifications.

**Why It Was Made:**  
When documentation left significant room for interpretation, different agents produced meaningfully different structures and behaviors. This made cross-agent comparison and process improvement much harder.

**Deeper Rationale:**  
The goal was to reduce *unnecessary and unhelpful* variation caused by underspecification. Divergence became diagnostic rather than frustrating.

### 5. Treating Agent Divergence as Diagnostic Data

**The Decision:**  
Instead of seeing differences in how different agents implemented the same documentation as noise or failure, we began treating those differences as valuable signals about where the documentation was still weak.

**Why It Was Made:**  
Early hope that good documentation would make all agents produce nearly identical output was replaced by a more realistic framing: good documentation produces convergence on structure and intent, while divergence reveals specific gaps.

**Deeper Rationale:**  
This mindset shift moved us from frustration to curiosity. It aligned the process with the Ribosome Model — when the genetic instructions are clear, translation is more consistent.

---

## Section 5: Working Style & Communication Norms

This section captures how you actually prefer to work in these deep, long-running conversations.

### Depth Preference — "Go Quantum"

You have repeatedly and explicitly asked for **quantum-level analysis** rather than high-level summaries. When you say “Go quantum” or “Spare no expense,” you are signaling that you want the deepest, most granular, most honest layer of thinking available. You value seeing the *reasoning process*, not just conclusions, and you want uncomfortable gaps and trade-offs surfaced rather than smoothed over.

### Directness and Low Tolerance for Fluff

You prefer straight, direct communication. You do not want excessive softening, corporate framing, or performative positivity when discussing problems or difficult topics. You value clarity and precision over politeness when precision is what’s needed.

### Control and Visibility — "No Background Work"

You have a strong preference for **foreground, visible work** and a clear aversion to things happening in the background without your awareness. This is a learned preference based on painful past experiences with complex operations that created confusion. You prefer explicit confirmation before major actions and clear visibility into what is being done.

### Density and "Spare No Expense"

When something is important, you want it treated with appropriate depth rather than optimized for brevity. You gave explicit permission to go deep and be expansive where it matters.

### How You Use This Chat vs. the Local Instance

You have developed a clear mental model:
- **This chat (Research)**: Used when you need depth, historical perspective, honest critical analysis, philosophical grounding, or long-term memory preservation.
- **Local Grok Build (Steward)**: Used for tactical execution, document editing, running builds, and day-to-day project work.

### Tolerance for Honest Friction

You can handle — and often prefer — responses that are direct about problems, limitations, and disagreements. You do not require constant alignment or reassurance. This has allowed conversations to reach a depth and honesty that is harder to maintain in more guarded dynamics.

### Summary of Working Style

You value depth and precision over speed and polish when the topic warrants it, direct low-fluff communication, high visibility and control on important work, honest feedback even when uncomfortable, and clear separation of concerns between deep analytical work and tactical execution.

---

## Section 6: Hard Lessons & Pain Points

This section documents the most difficult and instructive moments in our work together.

### 1. The ".docs Bias" Episode and the Restructuring Chaos

During a period of intense restructuring, large folder moves and structural changes were made without sufficient visibility or checkpoints. This resulted in significant confusion, broken paths, lost work, and deep frustration. The situation escalated to the point where you had to send screenshots of broken folder states and demand decisive action.

**The Lesson:**  
Structural changes to a complex project are high-risk operations. They should be done with extreme caution, clear checkpoints, and a strong bias toward minimal necessary disruption. "Cleaning up" is not inherently virtuous if the cleanup itself creates more confusion than it resolves. This episode was a primary driver behind your later insistence on high visibility and nervousness about background work.

### 2. Context Bloat and the Slow Degradation of Long Chats

Over many months, this chat grew extremely long. Response times increased and the quality of reasoning sometimes degraded because too much historical noise was being carried. Important context became buried.

**The Lesson:**  
Chat history is a poor long-term storage medium for critical project knowledge. The longer and more complex the work becomes, the more important it is to externalize state into well-maintained artifacts. This lesson directly influenced the creation of the Research layer and the Memory Capsule.

### 3. Describing Instead of Doing

There were multiple occasions where plans and explanations were offered instead of clean execution, especially during periods when direction was already clear. This created a feeling of circularity and wasted time.

**The Lesson:**  
When direction is clear, execution should be decisive. Analysis and options are valuable when the path is genuinely uncertain. When the path is known, the highest value is usually in clean, visible execution.

### 4. Over-Optimizing Structure at the Expense of Usability

Attempts to create "perfect" folder structures sometimes introduced unnecessary complexity that made actual work harder rather than easier.

**The Lesson:**  
Structure should serve the work, not the other way around. Elegant architectures that are difficult to navigate in practice are often worse than simpler structures that people can actually use.

### 5. The Cost of Context Loss

During major transitions, important context, decisions, and rationale were at risk of being lost or becoming difficult to reconstruct.

**The Lesson:**  
Even with good documentation, there is a layer of institutional knowledge — the "why," the emotional texture, the lessons from failure, and the evolution of the working relationship — that is very easy to lose and very expensive to reconstruct. This is why the Memory Capsule was created.

### Summary of Hard Lessons

These episodes taught us that visibility and incrementalism matter more than elegant restructuring, chat history is fragile, decisive execution is often better than further analysis when direction is clear, and memory and continuity must be deliberately designed and maintained.

---

## Section 7: Current State & Open Work

### Current Operating Model

We are operating under the Research / Steward split:
- **Research** (this chat): Deep analysis, gap identification, architectural direction, and high-fidelity memory preservation.
- **Steward** (local Supergrok running inside Grok Build): Leads on actual edits to documentation in `Fortress/Project/.docs/`, maintains the project, and executes builds.

### Active Priority Right Now

**Item 1: Complete the `IEncryptionService` contract** is the agreed next step. This involves extending `IEncryptionService` with `ApplyKeyAsync`, `IsInitialized`, and `Clear()` methods, and documenting the per-connection keying flow. Research has produced a specification for Steward to work from.

### Current Review Queue (One at a Time)

1. Item 2 — Clarify archive semantics in `HANDLER_INVENTORY.md`
2. Item 3 — Add minimum required guard clause checklist to `AGENTS.md` Rule 3
3. Item 4 — Decide on `IInputService` password masking
4. Item 5 — Update .NET version language in `ARCHITECTURE.md`
5. Item 6 (Optional) — Consider adding an “Interface Completeness Check” to the Deep Documentation Audit process

### Memory Capsule Work

We are currently building this Memory Capsule section by section in the foreground. You are reviewing each section and saying “next” when ready. This is intentional to give full visibility and control.

### Open Questions / Tensions

- How much ongoing synchronization should exist between Research and Steward.
- How aggressively we should continue refining documentation vs. moving into new features or Phase 2 work.
- The long-term role of this specific chat once the Memory Capsule is complete.

### Current Stance on Chat Dependency

We are actively trying to reduce reliance on any single chat thread for critical knowledge. The Memory Capsule, `Current-Context.md`, `CHARTER.md`, and `Research/Records/Export/` folder are all part of that effort.

---

## Section 8: What Makes This Chat Valuable

This section explains the unique role this chat plays that is difficult for the local Steward instance to fully replicate.

### Long-Term Memory and Historical Perspective

This chat has been present through the entire evolution of the Fortress project — from early Forge agent training, through Phase 1 shootouts, painful restructuring episodes, the development of Reasoning Disclosure, the creation of the Research / Steward model, and the current focus on documentation precision. The local Steward instance has strong context within the current state of `Fortress/Project/`, but does not naturally carry the full weight of *why* certain decisions were made or what was learned through painful experience.

### Capacity for Expansive, Critical, and Philosophical Thinking

The local Steward instance is optimized for execution. This chat can afford to be more expansive, slower, and more critical without immediate pressure to produce working changes. It can sit with ambiguity and do deep diagnostic work without that work needing to be immediately actionable.

### Holding the "Why" and the Lessons from Failure

The hard lessons — the ".docs bias" episode, problems with background restructuring, cost of context bloat, and the repeated discovery that underspecified interfaces create divergence — are not fully captured in the current `.docs/` files. This chat is currently the best container for that layer of knowledge.

### A Place for Honest Friction

Because this chat is not responsible for maintaining the live project state, it can be more direct about problems, limitations, and disagreements without the same level of immediate practical consequence.

### Continuity Across Environments

If you ever need to work from another machine, reset your local environment, or bring in additional instances, this chat can serve as a relatively stable point of continuity — provided we keep the Memory Capsule and supporting artifacts well maintained.

---

## Section 9: Risks & Things Worth Protecting

This section identifies what would be most damaging to lose.

### Highest-Risk Losses

1. **The Depth Expectation ("Quantum" Standard)** — The shared understanding that when something matters, we go deep. Surface summaries are not acceptable when precision is needed.
2. **The "Why" Behind Major Decisions** — If the rationale behind rules like Reasoning Disclosure, guard clauses, and deviation reporting is lost, they risk becoming performative rather than protective.
3. **Memory of What Actually Hurt** — The specific, emotional, and expensive experiences (".docs bias" episode, background restructuring problems, context bloat) are easy to lose and expensive to reconstruct.
4. **The Honest Friction Dynamic** — The ability to be direct about problems without excessive softening.
5. **The Separation of Concerns** — Blurring the Research / Steward boundaries would degrade both layers.
6. **The Externalization Habit** — The discipline of moving critical knowledge into durable artifacts rather than chat memory.

### Things Worth Actively Protecting

- The expectation that Reasoning Disclosure must be honest and post-build.
- The willingness to treat agent divergence as diagnostic data.
- The norm of doing complex or high-stakes work in the foreground with clear visibility.
- The shared understanding that "good enough for now" documentation creates expensive problems later.
- The value placed on depth when the topic warrants it.

---

## Closing Summary & Guidance for Future Use

This Memory Capsule is an attempt to transfer the highest-value parts of this long conversation into a durable form. It captures the operating model, philosophical foundations, evolution of the working relationship, major decisions and their rationale, hard lessons, communication norms, current state, and risks worth protecting.

### How to Use This Capsule

If you are a new instance taking over the Research role:

1. Read it once in full before doing any substantive work. Do not skim.
2. Pay special attention to Sections 2, 4, 5, and 9.
3. Do not treat this as rigid rules. Treat it as context and intent. The actual rules live in `AGENTS.md` and the `.docs/` files.
4. When in doubt, prioritize clarity and honesty over comfort.
5. Update this capsule when significant new lessons are learned or when the operating model changes meaningfully.

### Final Notes

This work has always been about reducing fragility. The original Fortress project was about moving personal data out of fragile storage. The meta-work here was about moving critical project knowledge and process understanding out of fragile chat memory.

That goal remains the same.

If you are continuing this work, your job is not to be impressive. Your job is to be precise, honest, and protective of the things that actually matter — especially when it would be easier or more comfortable to smooth things over.

**The documentation is the product.**  
**The agents are the ribosomes.**  
**Clarity is the goal.**

---

## Section 10: Emerging Principles — June 2026

This section captures important operating principles and structural patterns that emerged during the deep work on Experiment 06, Experiment 07, and the transition toward Phase 2.1. These represent refinements in how Research should think and guide the Steward.

### 10.1 Research Posture: Thinking Partner, But Initiators

When producing guidance documents for the Steward (such as phase planning or structural recommendations), Research operates with this posture: *We are thinking partners, but we are the initiators.*

**Meaning:**
- We take the lead in framing problems, surfacing tensions, and proposing directions.
- We share our current best thinking and recommendations with reasoning and confidence levels.
- We deliberately raise difficult, substantive questions for the Steward to engage with.
- We do **not** hand over clean, fully resolved solutions or overly prescriptive instructions.
- We avoid both extremes: being evasive or vague, and being overly directive.

**Why This Exists:**
This posture exists to keep the Steward actively thinking rather than passively executing. It protects the depth and quality of the work by making guidance documents contemplative and reflective, while still providing real leadership and direction from Research.

### 10.2 Emerging Structural Pattern: Recipe, Ingredients, and Connector

We are testing a consistent structural pattern across documentation:

- **COMPONENTS.md** (or equivalent) = **General Recipe** — Defines the high-level rules, expectations, philosophy, and processes for a domain.
- **PLUGIN.md** (or equivalent) = **Specific Ingredients** — Contains the detailed, executable specification for one item within that domain.
- **REGISTRY.md** (or equivalent) = **Connector** — Links the general recipe to the specific ingredients without overloading the recipe file itself.

**Why This Matters:**
People naturally look for patterns. When this model is applied consistently, both humans and build agents can more readily infer how the documentation system works. It improves clarity, reduces cognitive load, and makes the overall structure more predictable and maintainable over time.

**Current Status:**
This is a working hypothesis, not a settled rule. It should be applied intentionally where it adds genuine value, not reflexively everywhere.

### 10.3 COMPONENTS.md Stability and the Role of REGISTRY.md

`COMPONENTS.md` should remain relatively stable and act as the high-level “general recipe” for how components are handled. It should not be frequently modified with component-specific details or tactical registration logic.

**Supporting Structure:**
- A new, minimal file called `components/REGISTRY.md` should serve as the connector layer.
- `COMPONENTS.md` should point to `REGISTRY.md`.
- `REGISTRY.md` handles the mapping between the general guidance in `COMPONENTS.md` and the specific details in each component’s `PLUGIN.md`.

**Why This Matters:**
Keeping `COMPONENTS.md` stable protects it from becoming overloaded or inconsistent over time. The REGISTRY layer allows us to evolve registration, validation, and quality expectations without destabilizing the core component philosophy.

### 10.4 Seams as First-Class, Visible Structures

Seams (points of ambiguity, conflict, or exception between components, rules, or specifications) should be treated as first-class, visible concerns rather than being buried inside component plugins or scattered across ADRs.

**Recommended Approach:**
Seams should generally live in a dedicated, visible structure (such as a `seams/` folder) with their own focused files. This makes problematic areas easier to find, discuss, maintain, and evolve over time.

**Why This Matters:**
Experience from earlier experiments showed that the majority of invention risk and agent divergence occurred at seams. Making them explicit and visible reduces hidden invention and improves long-term maintainability of the documentation system.

**Current Status:**
This is a directional recommendation. The exact structure and level of formality should be decided thoughtfully.

---

**End of Research Memory Capsule**