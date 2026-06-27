# Conversation Notes: Shared Memory System – Roles, Centralization, and Frontier Inbox

**Date:** 2026-06-27  
**Type:** Conversation Capture / Synthesis  
**Sources:** 
- Shared-Memory-Research-Summary-2026-06-26-1410.md
- Idea-Shared-Memory-System-between-Frontier-Research-Steward-2026-06-26-1420.md
- Idea-Shared-Memory-System-2026-06-27.md
- Recent chat discussion on frontier inbox, centralization model, and role responsibilities

**Note:** This is a fresh file. The original 26 and 27 files were left completely unchanged.

**Implementation Note:** Planned as first part of phase 2.2 — **parked** until after 2.1 shootout. See [`Shared-Memory-Steward-Assessment-2026-06-27-1800.md`](Shared-Memory-Steward-Assessment-2026-06-27-1800.md).  
**Location:** `Fortress/Ideas/Conversation-Notes-Shared-Memory-Roles-Centralization-2026-06-27-1530.md`

**Status update (2026-06-27):** Director chose to proceed with Phase 2.1 execution first (option 1). Shared memory system remains planned for Phase 2.2 after 2.1 foundations.

---

Hey Director, this file pulls together the shared memory thinking from the 26th and 27th plus the latest conversation points we just covered. It's meant to be an easy-to-read snapshot of where the idea stands right now.

## The Three Roles

We have three main players who need to stay aligned:

- **Frontier**: The idea person. Comes up with new thoughts, often while on the move or brainstorming freely. Wants freedom to throw out raw ideas without too much structure. Mobile-friendly capture is critical.

- **Research**: The deep thinker. Looks at things carefully, connects dots, writes plans and analysis. Surfaces tensions, trade-offs, and recommendations. Does **not** make final design choices.

- **Steward**: The builder and owner. Takes the ideas and plans and actually makes them real in the project. Owns the final stuff that gets used. Curates high-signal handoffs.

The notebook (shared memory) should be easy for the human **Director** to use too.

## The Core Problem

AIs forget everything between separate chats. Every new session requires re-explaining context, decisions, and how things work. This wastes time, causes drift, and is especially painful on a phone.

We need a reliable, low-friction shared "memory notebook" that all three roles (plus you as Director) can read and write to.

## The Recommended Approach: Smart Mix + Notebook Style

A hybrid works best:
- Some private/fast memory for each role's day-to-day.
- A strong shared layer for the important common stuff (decisions, plans, lessons, big picture).
- Organized in layers (quick stuff, recent/episodic, long-term semantic).

Use a notebook-style system (like Obsidian) because:
- Stores as regular markdown files (easy to version with git).
- Human-readable on phone or computer.
- Easy linking between ideas.
- Local-first for speed and privacy.
- Cloud agents can still access it.

## The Frontier Inbox

This was clarified in detail during the conversation.

The frontier inbox is the special "first stop" for raw, unpolished ideas from the Frontier role.

**Capture (easy for Frontier):**
- One obvious place in the shared notebook, e.g. `Ideas/Frontier-Inbox.md` (or a small Inbox/ area inside Ideas/).
- Just open it and append bullets, half-thoughts, questions, or sparks. No structure required.
- Works great on phone with quick add.
- Timestamp entries (manually or automatically).

**Processing (Research):**
- Research regularly mines the inbox.
- Clusters ideas, extracts value, turns raw sparks into proper dated files in Ideas/ or Phases/.
- Does reflection work and links things.
- Marks or archives processed items.

**Steward handoff and ownership:**
- Steward deliberately stays out of the raw inbox.
- Only looks at what Research has refined.
- Only Steward (with Director oversight) decides what becomes official: decisions, plans, Core/ updates, or handoffs via Records/Export/.
- Guardrail: Automation can help dump raw material and summarize. But promotion to owned status always requires a conscious Steward step.

**Automation hooks:**
- Agents can be told to append new sparks to the inbox.
- Long-running /goal tasks can write observations here.
- Research sessions start by checking Current-Context + the inbox.

The inbox lives inside **Ideas/** because it's still active thinking. Good stuff graduates to Phases/, Core/, or Records/Export/.

This keeps Frontier creative and fast while giving Research fuel and keeping Steward's world high-signal.

## Centralized Core + Thin Per-Role Customizations

From the recent discussion (your summary + expansion):

"So we would centralize almost everything, making files easy to manage and easy to version control. Each architect's or agent's project folder just becomes a place for per-role customization. With files centralized, version control becomes easy."

**What this means:**

- Almost all important shared content lives in one primary location (the notebook vault / our `Research/` folder with its 5-folder structure: Archive/, Core/, Ideas/ (with Frontier-Inbox), Phases/2.1 & 2.2/, Records/).
- This central core is the single source of truth.
- Git handles versioning, history, diffs, and sync across everyone.

Each role's or agent's "project folder" or workspace becomes a **thin layer** on top:
- Role-specific prompts or "hats" (e.g., "You are acting as Frontier right now — raw capture only").
- Small private scratch notes the role is still exploring.
- Custom views, quick-capture settings, or workspace configs.
- Local references/symlinks that pull from the center.
- Truly private customizations that don't belong in the shared core yet.

**How it plays out here:**
- Central `Research/` holds the authoritative versions.
- Local Supergrok (as Steward/builder in `Fortress/Project/`) reads from the center when needed but keeps build-oriented customizations separate. Research/ is generally read-only for pure build work.
- Frontier workspace is very light — fast access to the inbox + capture tools.
- Cloud agents access the central files.
- When Research refines or Steward promotes, changes land in the central files (following date format, promotion rules, etc.).
- The frontier inbox stays central so everyone sees the raw stream.

**Why powerful:**
- One copy of the real content → simple management and reliable git version control.
- No duplication drift.
- Each role still gets a tailored experience.
- Fits the hybrid memory model and works with our existing 5-folder cleanup.
- Plays nicely with frontier inbox, automation, and clear ownership.

## Who Makes the Final Design Choices and Assists the Director?

This was the last key clarification.

- The **human Director** has ultimate oversight and makes final decisions on major architectural and process directions.
- The **Steward** is the role that makes the final design choices (on documentation architecture, structure, curation, and what becomes owned deliverables) and primarily assists the Director.
  - Steward owns the final stuff.
  - Steward curates high-signal handoffs.
  - Steward leads on actual changes and decides what gets promoted (with Director oversight on the big calls).
  - "Only Steward (with Director oversight) decides what becomes official work."
- **Research** assists by doing deep analysis, surfacing options and trade-offs, and offering strong recommendations — but **does not make final design choices**.
- **Frontier** assists with raw idea generation.

In short: When you want design choices made and owned, and someone to help turn the vision into real, governed deliverables, you work with the Steward.

This chat is currently operating in the **Research** layer. The local VS Code Supergrok instance acts as Steward.

## Guardrails and Strongest Ideas

- Keep human/Steward judgment in the loop for anything important.
- Automation is great for capture, reflection, and updating notes — but not for final promotion or ownership.
- Use the centralized core + thin layers approach for easy git management.
- The frontier inbox gives Frontier freedom while feeding the rest of the system.
- Build on what we already have (Current-Context, STRUCTURE.md, Phases/ subfolders, explicit artifacts) instead of starting from scratch.

This model reduces re-explaining, supports mobile Frontier, keeps high signal, and respects clear ownership.

---

*This file is a new capture for easy reference. It does not replace or modify the original 26 and 27 files. Originals remain as they were.*

*We can promote useful pieces from here into Core/ or the main Idea file later if it makes sense.*