# Structured Summary: Shared Memory Systems for 2 Local Agents + 1 Cloud Agent

**Location:** `Fortress/Ideas/Shared-Memory-Research-Summary-2026-06-26-1410.md`  
**Source:** Copied from `fortress-research` 2026-06-27

**Research Pass:** Initial deep (bounded ~10 min effort)  
**Date:** 2026-06-26  
**Scope:** Architectures, automation possibilities, key trade-offs, and comparisons. Grounded in project context (Frontier/Research/Steward roles, memory palaces, explicit artifacts, hybrid local/cloud) + external research.

## 1. Architectures

### Core Patterns for Hybrid Local/Cloud
- **Shared Memory (Centralized)**: All agents access a common store (e.g., vector DB, graph, or Obsidian-like markdown vault). Simple coordination via blackboard (agents post/read contributions). Pros: strong consistency, easy sync. Cons: bottleneck at scale, latency for cloud-local roundtrips.
- **Distributed Memory**: Each agent owns private local memory (e.g., local FS/vector on locals, cloud store on cloud agent) with selective synchronization. Pros: low local latency, privacy. Cons: inconsistency risk, complex merging.
- **Hybrid (Most Common in Production)**: Private tiers (local working/episodic memory) + shared tier (canonical facts, decisions). Locals cache heavily; cloud acts as durable hub. Sync via git, event logs, or MCP-style tools.
- **Hierarchical / Layered Memory** (MemGPT/Letta-style, 3 layers):
  1. Working/Core (in-context, small, always hot: current task/role profile).
  2. Episodic/Recall (recent sessions, summarized experiences).
  3. Semantic/Long-term/Archival (structured knowledge: facts, graphs, palaces).
  Agents manage paging/reflection between layers.

Project alignment: Mirrors current explicit artifacts (Current-Context.md as core, Memory Capsules as archival, .codingAgent/memory/ as palaces). Phases/2.1/2.2 provide scoped shared layers.

### Multi-Agent Specific
- **Blackboard Architecture**: Shared "board" where agents contribute/monitor for coordination (low coupling).
- **Actor-Attributed Graphs**: Tag memories by source agent (prevents contamination; supports reputation/trust).
- **Temporal Knowledge Graphs**: Entities + relations + timestamps for "what was true when" (better than flat vectors for drift detection).

For exactly 2 locals + 1 cloud: Locals share fast local blackboard/graph; selective push to cloud for durability/cross-session. Cloud provides global view but locals operate offline-first.

## 2. Automation Possibilities

- **Agent-Managed Reflection & Extraction**: Agents periodically summarize episodes into semantic memory, extract decisions/tensions (project uses self-reflection loops in 2.2 ideas). Automation via prompts or tools like reflection phases.
- **Paging & Scoping**: Like MemGPT/Letta: agent decides what to load (core) vs archive. Automation reduces manual context management (project priority: reduce chat memory dependency).
- **Policy Propagation & Sync**: Automated sync rules (e.g., new decision in local -> propagate to cloud; cloud pushes high-signal to locals via git/MCP). Use watchers for changes.
- **Retrieval Augmentation**: Automated RAG over shared store (vector + graph) for relevant context injection. Multi-strategy (semantic, keyword, temporal, graph traversal).
- **Proactive Consolidation**: Agents autonomously prune staleness, merge duplicates, forecast tensions (project 2.2 idea).
- **/goal Integration**: Long-running /goal tasks can read/write shared memory for state persistence across sessions, reducing re-explaining. Checklist can include memory updates.
- **Role-Aware Automation**: Frontier (exploratory) auto-dumps raw to inbox; Research reflects deeply; Steward curates high-signal handoffs. Guardrails: human/Steward approval for promotion.

High automation reduces repetitive onboarding but requires guardrails (see trade-offs).

## 3. Key Trade-offs

- **Consistency vs Latency vs Cost** (the iron triangle):
  - Strong consistency: Cloud as source, locking/synchronous updates. High latency/cost for locals; good for critical decisions.
  - Eventual consistency: Async sync (git, streams). Low latency locally; risk of stale data/misalignment (e.g., 2 locals diverge).
  - Trade-off: Optimize for latency (caching) -> reintroduce inconsistency. Cost: more writes/checkpoints.
- **Privacy/Security**: Local-only for sensitive; shared for coordination. Actor attribution helps isolation.
- **Staleness vs Freshness**: Over-frequent sync = cost/latency; under = drift (project risk of inconsistent understanding).
- **Coupling vs Autonomy**: Shared memory couples agents (good for alignment, bad for independence). Distributed reduces coupling but increases merge complexity.
- **Scalability**: Centralized bottlenecks >N agents; hybrid scales by scoping (per-role, per-project banks).
- **Automation Risks**: Over-automation leads to noise/low signal (project emphasizes high-signal artifacts, conservative growth). Under = manual burden (mobile friction).
- **Context Bloat**: Dumping shared memory inflates prompts; needs scoping/retrieval.
- Local vs Cloud: Locals excel at low-latency FS; cloud at broad knowledge but session-bound.

Project context amplifies: Mobile Frontier needs low-friction capture; Research/Steward need governed, high-signal.

## 4. Comparisons

| Architecture | Strengths (for 2L+1C) | Weaknesses | Project Fit |
|--------------|-----------------------|------------|-------------|
| **Pure Vector (e.g. Mem0, Zep)** | Fast semantic retrieval; easy shared namespace. | Loses structure/relations/time; poor for complex reasoning. | Good base for retrieval over palaces/notes; weak alone vs graphs. |
| **Episodic (MemGPT/Letta)** | Excellent continuity (paging summaries); agent self-manages. | Latency for paging; less great for multi-agent sharing without extensions. | Aligns with reflection loops, capsules; add shared archival tier. |
| **Knowledge Graph (Graphiti, Neo4j)** | Handles relations, temporality, actor attribution; deep reasoning. | Setup/compute heavier; query complexity. | Strong for tensions/strategies (project 2.2); combine with Obsidian for human view. |
| **Blackboard/Shared State** | Emergent coordination; explicit/auditable. | Can become noisy without scoping. | Good for coordination across roles; project already uses explicit docs like this. |
| **Hybrid (Private + Shared + Layers)** | Best of all: low local latency + durable shared + retrieval options. | Design complexity. | **Strongest match**: Current explicit artifacts + future shared vault/graph. |
| **File/Obsidian-like (markdown + git)** | Human-readable, local-first, versioned, mobile-friendly (Obsidian). | No built-in concurrency/query power; needs AI retrieval layer. | Directly inspired by idea; extend with automation for agents. |

Vs single long context: Not scalable for persistence/sharing across agents/sessions.

## Strongest Ideas (with rationale)
1. **Hybrid Hierarchical Memory with Agent Self-Management** (e.g., Letta-style + shared graph tier): Combines low-latency local, durable cloud, and automation for reflection/paging. Rationale: Directly addresses inconsistency, staleness, and automation while fitting local/cloud split. Project's memory palaces + capsules are a manual version; automate it.
2. **Scoped Shared + Private with Actor Attribution**: Use namespaces/banks (per-role, per-project) + graph tagging. Rationale: Balances sharing for alignment with isolation for roles; prevents contamination. Supports /goal autonomy without full coupling.
3. **Blackboard + Temporal Graph Hybrid**: Shared board for coordination + graph for structured knowledge. Rationale: Emergent multi-agent behavior + deep retrieval; low friction for humans (markdown layer). Matches project emphasis on explicit, governable artifacts.
4. **Automation via Reflection + Selective Sync**: Agents extract/summarize/write autonomously; git/MCP for sync. Rationale: Maximizes automation (reduces onboarding, enables long-running), with guardrails. Project already has bootstrap + reflection ideas.

These stand out for balancing the 2L+1C constraints, project philosophy (Ribosome model, high-signal, conservative), and real-world patterns (hybrid wins in production).

## Open Questions
- What consistency model works best for 2 locals + cloud (eventual with conflict resolution, or scoped strong)?
- How to automate memory promotion/extraction without losing signal or introducing drift (especially across roles)?
- Integration with /goal: Can long-running tasks use shared memory for state across pauses/sessions? What hooks needed?
- Mobile/local constraints: How to keep capture low-friction for Frontier while enabling rich retrieval for others?
- Scope boundaries: What should be shared vs private (e.g., exploratory Frontier ideas vs Steward decisions)?
- Tooling: Best way for agents to read/write (MCP, file tools, graph queries)? How to version/audit shared changes?
- Evaluation: Metrics for "good" shared memory (reduced re-explaining, alignment accuracy, automation coverage without bloat)?
- Scaling beyond 3 agents: Does the hybrid hold, or need hierarchical governance?

**Stopping condition met**: Core topics covered at satisficing depth for initial pass. Summary produced. No further iteration.

**Evidence of bounding**: Focused on 4 areas + project grounding + external sources; halted after synthesis. (Approx effort aligned to ~10 min target via targeted searches/reads.)

**References**: Internal (Idea-Shared-Memory file, Memory-Palaces idea, Current-Context, STRUCTURE.md, Memory Capsule); external (MemGPT/Letta, Mem0, hybrid patterns from production reports, graph vs vector comparisons, blackboard architectures). 

This completes the bounded research pass.

## Conversation Version (Plain Language for the Director)

Hey Director, here's the simple take on this research about shared memory for our three roles (Frontier for ideas, Research for deep thinking, Steward for building).

The core issue is that AIs forget everything between chats. So we need a shared "notebook" system that all three can use and update.

We looked at different ways to set this up:
- One central shared spot (easy to stay in sync but can be slow).
- Each has their own notebook and they copy only the important bits (fast but can get out of date).
- A smart mix: private notes for speed + shared important stuff. This seems best for us.

We can organize it in layers like how our brains work: quick stuff for right now, recent work, and big long-term facts.

The AIs can do a lot automatically — summarizing what they learned, pulling up the right notes, updating things after work. But the Steward should still own the final important deliverables.

Compared to just dumping everything in one chat or using fancy databases, a notebook-style system (easy for humans to read on phone, linkable, versioned with git) works well because it's human-friendly and AI can use it too.

Biggest ideas: Use a hybrid setup with layers, let AIs handle routine updates and reflection, keep it simple and governed.

Open questions include how to keep everyone in sync without too much hassle, how to blend this with long-running tasks, and what the best balance of automation vs human oversight is.

This is just the starting research — we can build on it step by step.