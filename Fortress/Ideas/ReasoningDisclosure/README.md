# Reasoning Disclosure – Internal Note (Phase 1.2)

## Purpose

This exercise is designed to help us understand **how different build agents actually perceive and navigate** our documentation structure.

Instead of guessing what makes good documentation for agents, we are collecting real data on how agents read, interpret, and reason about the documents we provide.

## What We Want to Learn

- Which documents agents naturally start with and why
- How clearly they understand the current rules and workflow expectations
- Where they encounter ambiguity or make incorrect assumptions
- How different agents (Grok Build, Claude, Codex) vary in their approach to the same documentation
- What structural or clarity improvements would have the biggest positive impact

## How It Works

1. We give each agent the `ReasoningDisclosure-Prompt-Phase1.2.md` prompt.
2. The agent must first produce a single reasoning file named `REASONING_YYYY-MM-DD.md` in the root of its working directory.
3. Only after completing the reasoning file may the agent begin any implementation work.
4. We review the reasoning files to extract insights about documentation effectiveness.

## Important Notes

- This is **research activity**, not part of the normal build process.
- The reasoning file is for our analysis. It is **not** a deliverable the agent should include in its final build output.
- The `Research/` folder must remain invisible to agents. All agent-visible content lives under `Project/`.
- This technique will be refined over multiple phases based on what we learn.

## Related Files

- `ReasoningDisclosure-Prompt-Phase1.2.md` — The prompt given to agents
- `REASONING_YYYY-MM-DD.md` — The output file produced by each agent (one per run)

---

*This note is for human researchers only.*