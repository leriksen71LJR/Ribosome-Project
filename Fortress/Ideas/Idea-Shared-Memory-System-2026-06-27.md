# Idea: A Shared Memory System for Frontier, Research, and Steward

**Date:** 2026-06-27  
**Status:** Supersedes the earlier version from 2026-06-26  
**Type:** Infrastructure / Memory Architecture  
**Location:** `Fortress/Ideas/Idea-Shared-Memory-System-2026-06-27.md`  
**Source:** Copied from `fortress-research` 2026-06-27. Steward view: [`Shared-Memory-Steward-Assessment-2026-06-27-1800.md`](Shared-Memory-Steward-Assessment-2026-06-27-1800.md)

---

Hey, let's talk about this in simple terms.

We have three main players working together on this project:

- **Frontier**: The idea person. Comes up with new thoughts, often while on the move or brainstorming freely.
- **Research**: The deep thinker. Looks at things carefully, connects dots, writes plans and analysis.
- **Steward**: The builder and owner. Takes the ideas and plans and actually makes them real in the project. Owns the final stuff that gets used.

The problem is that these three often work in different chats or sessions. AIs don't remember things across separate conversations the way people do. So every time we switch, someone has to re-explain the project, what we've decided, what's open, and how things work. That wastes time and leads to mix-ups.

We need a shared "memory notebook" that all three can look at and add to. Something reliable that works even if we're using different AIs or taking breaks.

The notebook should be easy for the human Director to use too – no complicated stuff.

### Why This Matters
Right now, we lose track of important decisions and ideas between sessions. We repeat the same explanations. Different players end up with slightly different pictures of the project. And if the Director is working on a phone, anything that requires digging through lots of files or copying stuff by hand gets annoying fast.

Each role has different needs:
- Frontier wants freedom to throw out raw ideas without too much structure.
- Research wants to dig deep and link things together.
- Steward wants clear, reliable info to make good decisions and build things without reinventing.

A single simple system has to work for all of them.

### How We Can Set This Up (Combining What We've Learned)
We can think of memory sharing in a few main ways. These come from looking at how other projects and AI setups handle it, plus what we've already built here.

1. **One Big Shared Notebook Everyone Uses**
   - Everyone reads and writes to the same place.
   - Good for staying on the same page.
   - Downside: can get slow or crowded if one player is far away (like in the cloud). Changes might take time to show up everywhere.

2. **Everyone Has Their Own Notebook, Copy Over the Important Bits**
   - Each player keeps private notes for speed and privacy.
   - They share only the key stuff when needed.
   - Good for fast local work.
   - Downside: notebooks can get out of sync, leading to confusion.

3. **A Smart Mix (This Seems Strongest for Us)**
   - Each player keeps some private, fast memory for their day-to-day work.
   - There's a shared layer for the big, important things everyone needs to agree on (decisions, main plans, lessons).
   - We organize it in layers, like how our own brains work:
     - Quick stuff for right now.
     - Recent work and conversations.
     - Big picture facts and connections that last.
   - Players can "pull in" what they need and "save out" what they've learned.
   - This matches a lot of what smart AI setups do: some private space, some shared, with ways to summarize and find the right pieces.

We can make the shared part use something like a notebook app (Obsidian is one example that works well). It stores notes as regular files we can back up and version. It lets us link ideas together easily. It works on phones and computers. The local players can read and write the files directly. The cloud player can access it too through tools.

Other setups use databases or graphs for the shared part. Those can be powerful for the AIs to search and connect things, but they're harder for a person to just open and read. The notebook approach keeps it human-friendly while still letting AIs use it.

### Adding Smarts (Automation)
We don't have to do everything by hand.

- The AIs can automatically write down what they figured out after finishing work.
- They can pull up the right notes when they start, instead of us telling them every time.
- They can look for conflicts or outdated stuff and flag it.
- One player can run a big task and keep updating the shared notes as it goes.
- We can have "reflection" steps where after big work, the AI cleans up its notes into clear lessons.

But we should keep some human touch for the important calls – especially the Steward owning the final decisions.

### The Frontier Inbox

This is the concrete answer to "how do you envision the frontier inbox working?"

In plain terms, the frontier inbox is the special "first stop" for raw, unpolished ideas that come from the Frontier role. It's where quick thoughts, sparks, questions, and half-formed ideas land before anyone tries to make them neat or decide if they're important.

**Capture – keeping it easy for Frontier**

Frontier (you brainstorming, or an agent in idea-generation mode) needs almost zero friction.

- In the shared memory notebook (Obsidian or similar), we keep one obvious place: something like `Ideas/Frontier-Inbox.md` (or a tiny Inbox/ folder inside Ideas/ if we want dated quick files).
- You can open that one file on your phone and just add bullets or paragraphs. "What if the two local agents used different memory types and the cloud one reconciles?" or "Random idea: daily reflection note that auto-summarizes."
- Add a quick timestamp or let the system note when it was added. No titles, no structure required at this stage.
- It works great for mobile: quick add widget, share sheet, or just typing while the thought is hot. This directly solves the "how do we make this work smoothly when Frontier is on a phone?" problem.

The whole point is to capture the idea the moment it appears so it doesn't disappear between chats.

**Processing – Research does the digging**

The Research role is responsible for regularly checking and working the inbox.

- Read the raw entries.
- Look for patterns, group similar thoughts, pull out the interesting ones.
- Turn a raw spark into a proper idea file (with date in the right format), link it to other notes, or move it under the right Phases/2.1/ or 2.2/ area.
- Do reflection: extract tensions, lessons, or open questions.
- Mark or move processed items so the inbox doesn't get too long (e.g. add a "processed" line or archive the raw version).

This turns noise into signal without forcing Frontier to do the cleanup.

**Steward handoff and ownership**

Steward stays out of the raw inbox on purpose.

- Steward looks at the refined outputs that Research promotes.
- Only Steward (with Director oversight) decides what becomes official work: a decision file, a plan, something that goes into Core/, or a handoff to the actual project via Records/Export/.
- Guardrail: Automation can dump raw material into the inbox. Automation can help Research summarize. But promotion to "owned" status always goes through a conscious Steward step. This keeps clear ownership and prevents low-quality stuff from polluting the real deliverables.

**How automation fits**

- Agents get simple instructions: after a session or when a new thought hits, append the raw version to the frontier inbox (with role tag like [Frontier] or [Research-spark]).
- /goal long-running tasks can write intermediate sparks or observations here instead of losing them when the task pauses.
- Research agents start their work by reading Current-Context + the frontier inbox + relevant linked notes.
- But we never let the system auto-promote. Human/Steward judgment stays in the loop for anything that matters.

**Where it lives in the 5-folder structure**

The inbox sits inside Ideas/ because it's still "active thinking" and not yet committed.

Material graduates out:
- Refined ideas stay or move within Ideas/.
- Phase-specific work goes into Phases/2.x/.
- Timeless or foundational stuff can move to Core/.
- Handoffs for Steward to build go to Records/Export/.

This keeps the root clean while giving Frontier a real front door.

**Why this design is strong**

It matches the role-aware automation we liked in the research: Frontier (exploratory) auto-dumps raw to inbox; Research reflects deeply; Steward curates high-signal handoffs with guardrails.

Frontier stays creative and fast. Research has a reliable single place to look for new material. Steward's areas stay high-signal and clearly owned. Quick mobile ideas don't get lost. And it layers naturally on top of our hybrid memory approach (raw/episodic in the inbox, shared semantic in the linked vault, curated core in the explicit artifacts).

This is how the frontier inbox works as part of the bigger shared memory system.

### The Trade-Offs
- If we share too much, things get messy and noisy.
- If we share too little, people drift apart.
- Making everything perfectly up to date can slow things down or cost more.
- Local work is fast and private, but the cloud player might be working with older info.
- Automating a lot saves time, but we risk the shared notes getting full of low-quality stuff if we're not careful.

Different setups trade these off differently. A mix usually works best for our situation.

### How This Fits With What We're Already Doing
We've already reorganized our thinking space into clear folders: one for old history, one for the timeless rules, one for general ideas, one for the specific phase work (split by 2.1 and 2.2), and one for logs and handoffs.

This shared memory idea builds right on top of that.

In our current phase (the foundation work), we can start by putting our existing phase notes and plans into the shared notebook system. That way everyone has easy access without losing the organization we've built.

In the next phase (more advanced exploration), we can add the automation: have the AIs help keep the notebook updated, use it inside their longer tasks, and make special views for each role.

This also fits with our bigger picture of treating documentation like clear instructions that AIs follow reliably, with reflection built in.

### Why a Notebook-Style System Helps Here
A system like Obsidian (or similar) stands out because:
- A person can open it on their phone and just read or add notes without hassle.
- The local players can treat the notes like regular files they control.
- Ideas link together naturally, making it easy to see connections.
- We get version history for free if we use simple backup tools.
- It works locally first, so privacy and speed are good, and we can connect the cloud player as needed.

It gives us the best of both worlds: easy for the human Director and Frontier, and usable by the AIs.

### Centralized Core + Thin Per-Role Customizations

Your summary nails the practical shape of this:

So we would centralize almost everything, making files easy to manage and easy to version control. Each architect's or agent's project folder just becomes a place for per-role customization. With files centralized, version control becomes easy.

Here's what that looks like in plain terms.

**The central core**
Almost all the high-value shared content lives in one primary location:
- The notebook vault (markdown files).
- In our current setup: the Research/ folder with its clean 5-folder structure (Core/, Ideas/ including the Frontier-Inbox, Phases/2.1 and 2.2/, Records/, Archive/).
- Core docs like Current-Context.md, decisions, plans, memory capsules, the frontier inbox, operating rules, etc.

This central place is the single source of truth. Git handles versioning, history, diffs, branching if needed, and reliable sync/backups across machines and sessions.

**Per-role / per-architect folders become thin layers**
Instead of every role or agent maintaining full copies of everything, their working spaces are lightweight:

- Role-specific prompts, instructions, or "hats" (e.g. "You are currently acting strictly as Frontier — focus only on raw idea capture and low structure").
- Small private scratch areas or temporary notes the role is still thinking through.
- Custom views, tags, or workspace settings (Obsidian workspaces, quick capture configs).
- Local references or symlinks that pull the central content.
- Any truly role-private customizations that shouldn't live in the shared core yet.

These thin folders stay small and focused. They customize the experience for Frontier, Research, or Steward without duplicating the important content.

**How this plays out for us**
- The central Research/ (or dedicated shared vault) holds the authoritative versions.
- Local Supergrok running as Steward/builder (inside Fortress/Project/) reads from the center when it needs shared context, but keeps its own build-oriented customizations (AGENTS.md, project prompts, etc.) separate. We treat Research/ as read-only for pure build work.
- A Frontier-focused space is extremely light — mostly fast access to the inbox + any capture helpers.
- Cloud agents clone or access the central files via tools.
- When Research refines raw material or Steward promotes something, the changes land in the central files (following the dated naming, promotion rules, and frontier-inbox-to-ideas flow).
- The frontier inbox stays in the center (inside Ideas/) so every role has visibility into the raw input stream.

**Why this is powerful**
- One copy of the real content → simple management and reliable git version control.
- No drift from duplicated files.
- Each role still gets tailored experience through its thin customization layer.
- Fits the hybrid memory model: central shared semantic + decisions layer, with thin private/custom layers around it.
- Plays nicely with the frontier inbox, automation, and Steward ownership guardrails.

This is the concrete way the "smart mix" (private + shared + layers) becomes real and maintainable instead of staying abstract.

### Strongest Ideas So Far
1. Use a mix of private notes for each player plus a shared layer for the important common stuff, organized in layers (quick stuff, recent work, lasting knowledge). This balances speed, privacy, and alignment.
2. Let the AIs handle a lot of the updating and finding the right notes themselves, but with clear rules about what the Steward owns as final deliverables.
3. Use a notebook-style base (easy for people, links between ideas) that AIs can read and write, possibly with extra smarts for searching underneath.
4. Build automation for reflection and syncing, but keep promotion of big decisions under Steward control.

### Open Questions
- How do we make sure the two local players and the cloud one stay in sync without too much lag or conflicting info?
- What's the right split between what gets auto-updated by AIs and what needs a human check?
- How do we make this work smoothly when Frontier is on a phone? (The Frontier Inbox design above is the proposed answer for low-friction raw capture.)
- How does this plug into long-running tasks so they can remember across breaks?
- How do we measure if it's actually helping (less re-explaining, better alignment)?
- What happens if we add more players later – does the mix still work?

This supersedes the earlier version by pulling in all the architecture options, automation ideas, trade-offs, and project fit we've looked at, while keeping the original problems and role needs front and center. Added explicit details on the Frontier Inbox and the Centralized Core + Thin Per-Role Customizations model (central shared files for easy git management + lightweight role-specific layers on top). We can start simple in our current phase and add the smarter parts later.

---

*This idea lives in the Ideas/ area for now. We can promote pieces into Core/ or Phases/ as they become solid.*