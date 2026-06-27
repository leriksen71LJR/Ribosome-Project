# Idea: Shared Memory System Between Frontier, Research, and Steward

**Date:** 2026-06-26  
**Status:** Active  
**Type:** Infrastructure / Memory Architecture  
**Location:** `Fortress/Ideas/Idea-Shared-Memory-System-between-Frontier-Research-Steward-2026-06-26-1420.md`  
**Source:** Copied from `fortress-research` 2026-06-27. Superseded by 2026-06-27 version; kept for history.

---

## Part 1: Summary + Core Problem

### Summary

We need a reliable, low-friction shared memory layer that allows **Frontier**, **Research**, and **Steward** to stay aligned across different chats, sessions, time gaps, and even different AI instances. Because current AI systems have no persistent memory between separate conversations, we must build an external memory system that all three roles can reliably access and contribute to.

The system is built around **Obsidian** as the central, local, version-controllable hub. The goal is to reduce the constant need to re-explain context while still respecting the practical limitations of working across multiple AI chats on a mobile device.

### Core Problem

Current AI coding/research agents (including this instance of Grok) have **no built-in persistent memory** across separate chat sessions. Every new chat starts with a blank slate. This creates several serious problems for a long-running, multi-role project like ours:

1. **Context Loss**  
   Important decisions, principles, open questions, and ongoing work get lost or forgotten between sessions. This is especially damaging when switching between Frontier (idea generation), Research (deep analysis), and Steward (architectural governance).

2. **Repetitive Onboarding**  
   Every time we start a new chat with Steward or Researcher, we have to re-explain the project structure, current priorities, key decisions, and how the memory system works. This is time-consuming and error-prone.

3. **Inconsistent Understanding**  
   Different roles may develop slightly different mental models of the project because they don’t have easy access to the same shared context. This leads to drift in how problems are framed and solved.

4. **Mobile Friction**  
   The user often works on a phone. Any system that requires opening many files, navigating deep folder structures, or doing heavy manual copying becomes impractical and gets abandoned.

5. **Role-Specific Needs**  
   Frontier needs space to explore and propose new ideas freely.  
   Research needs to go deep and connect concepts.  
   Steward needs high-signal, curated information for architectural decisions.  
   A single flat memory system struggles to serve all three well.

Without a deliberate shared memory architecture, the project risks becoming fragmented, with each chat operating in isolation and important knowledge evaporating over time.

---

**End of Part 1**

This section establishes *why* a shared memory system is necessary and what problems it must solve. The rest of the file will cover current approaches, our design choices, trade-offs, and open questions.

## Conversation Version (Plain Language for the Director)

Hey Director, the simple version of this idea is that we need a shared "memory notebook" all our main players can use.

Right now, every time we switch between the idea person (Frontier), the deep thinker (Research), and the builder (Steward), a lot of context gets lost and we have to explain everything again.

The proposal is to use a tool like Obsidian — basically a smart notebook app — as the central place where notes live. It's local, works on phones, lets you link ideas, and we can back it up with git.

Everyone can read and add to it. The AIs can be told to start by checking the notebook and to write important things back into it after they work.

This would cut down on the repetition and help keep everyone on the same page without everything living only in chat history.
