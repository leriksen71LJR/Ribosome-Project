# Fortress Operating Process

This document defines **how** we work in Fortress. It is the authoritative description of the workflow, session structure, and quality gates.

The goal is to make the process repeatable and largely independent of chat memory.

---

## Charter (Why Fortress Exists)

Fortress is a **research and training project**. The Fortress console application is a vehicle, not the top prize.

**Primary charter:** Train the **Director** (Mr. Bear) in **AI agent coding** — how to brief agents, read their reasoning, judge documentation quality, run shootouts, and curate what they produce.

Secondary outcomes (documentation discipline, Ribosome experiments, working MVP) serve that charter. When structure helps learning, we use it. When structure would slow exploration, we loosen it — deliberately.

**Division of labor:**

| Role | Owns |
|------|------|
| **Director (Mr. Bear)** | Intent, priorities, when to explore vs when to ship, final calls |
| **Research** | Contemplative design, experiments, long-horizon thinking |
| **Steward (Grok)** | Code and folder organization, process capture, export hygiene — offered as a service, not a gate |

Research and the Director are not expected to match steward-level folder discipline. The steward keeps the repo **legible enough to resume** without forcing every idea through a rigid pipeline.

---

## Core Philosophy

We treat **documentation as executable pseudocode** for AI agents.

The quality of the output is primarily determined by the quality and clarity of the documentation, not by the intelligence of the agent. Therefore, we invest heavily in:

- Making reasoning visible before code is written (Reasoning Disclosure)
- Explicit conflict resolution and gap reporting (Rules 10 and 11)
- Maintaining living documentation that reduces the need for chat context

---

## Project Structure and Boundaries

### Fortress/ (root layout)

```
Fortress/
├── Archive/     ← Historical, superseded, legacy (experiments, drafts)
├── Core/        ← Timeless essentials (CHARTER, STRUCTURE, context, memory)
├── Ideas/       ← General ideas and operational tooling
├── Phases/      ← Phase work: Project/ (agent package), Export/ (shootout)
└── Records/     ← Logs, backlog, handoff exports, backups, phase history
```

Plus root ops files: `PROCESS.md`, `STATUS.md`, `README.md`.

`Fortress/` is primarily for **humans** managing and evolving the project. Build agents receive a **shootout copy** of `Phases/{id}/Project/`, not the full Fortress tree.

### Phases/

Each phase is an envelope:

| Path | Purpose |
|------|---------|
| `Phases/{id}/Project/` | **Living agent package** — `AGENTS.md` is project root |
| `Phases/{id}/Export/` | Shootout mirror — `Export/Project/`, `Prompts/`, zip |
| `Phases/{id}/*.md` | Optional steward meta (preflight, handoff notes) |

| Layer | Location | Purpose | Rigidity |
|-------|----------|---------|----------|
| **Experiments** | `Archive/Experiments/` | Prototypes, arguments, REVISED plans | Low — explore freely |
| **Phases** | `Phases/{id}/Project/` | Build-agent product | Medium — must be buildable when used |
| **Export** | `Phases/{id}/Export/` | Zips and prompts for shootouts | High — full copy only when zipping |

**Promotion (Experiment → Phase):** When Research and the Director agree a prototype is ready for agent testing, the steward **copies or moves** the doc tree into `Phases/{id}/Project/` and mirrors to `Phases/{id}/Export/`. No fixed ceremony — a log entry or `STATUS.md` line is enough.

**Multiple phases in flight:** Allowed. The shootout prompt must name **one** phase (e.g. copy `Phases/2.1/Export/Project/`). `Phases/PHASES.md` records the default phase if unclear.

- Everything an agent may see during a build lives inside the **assigned shootout copy** of `Project/`.
- Agents must not read `Archive/`, `Core/`, `Ideas/`, or `Records/` during implementation.
- Steward promotes doc changes from build reports into `Phases/{id}/Project/.documents/`.

### Role of PROCESS.md

`PROCESS.md` is the **authoritative management and coordination document** for the entire Fortress project.

It governs how the project is operated — above `AGENTS.md`, which governs agent behavior *during a build*.

---

## The Standard Session Cycle

1. **Reasoning Disclosure** (when used in training sessions)
2. **Analysis & Decision**
3. **Build Attempt** — agent gets `Phases/{id}/Export/Project/` (or external copy)
4. **Post-Build Review** — build report, audit, `STATUS.md` update
5. **Documentation Maintenance** — steward promotes into `Phases/{id}/Project/`

---

## Key Rules

- **Reasoning Disclosure** before implementation in training sessions when the prompt requires it.
- **Rule 10 / Rule 11** — conflicts and gaps must be explicit, not silent.
- **Chat memory minimization** — capture state in `STATUS.md`, `Records/Logs/`, `Core/Current-Context.md`.

### Session logging (`Records/Logs/`)

- **Location:** `Fortress/Records/Logs/`
- **Naming:** `{Topic}-{YYYY-MM-DD}-{HHmm}.md`
- **When:** Significant work, key decisions, or end of a focused session.

See [`Records/Logs/README.md`](Records/Logs/README.md).

### Preflight reports

A **preflight** is a steward-written readiness check before handoff — phase package, export, experiment, etc.

**How to request:** *"preflight Phase 2.1"* or *"Let's get a preflight report for the 1.2A export"*.

**Steward flow:**

1. **Clarify (optional)** — short questions if subject unclear. Skippable with *"just run it"*.
2. **Check** — read files, grep stale paths, verify layout.
3. **Report** — write to `Records/Logs/Preflight-{Subject}-{YYYY-MM-DD}-{HHmm}.md` with verdict: `Ready` · `Ready with conditions` · `Not ready`.

**Common checks:** artifacts exist, decisions recorded, stale paths (`Projects/`, `Research/`, `adr/`, `006/`), export mirror, caps respected, git state (informational).

### Source of truth for build artifacts

**`Phases/{id}/Project/`** is the source of truth for that phase's agent package.

- Default shootout phase: **1.2A** unless the prompt names **2.1** or another id.
- Build reports land in `Project/Builds/` during the shootout; steward syncs learnings back to `fortress-design` after review.

---

## Preparing Export / Shootout Zips

### Core rule: full copy only

`Phases/{id}/Export/Project/` must be a **full, clean copy** of `Phases/{id}/Project/` at the time of export. Do not selectively copy files.

### Required export layout

```
Phases/{id}/Export/
├── Project/     ← full copy of Phases/{id}/Project/
├── Prompts/     ← build prompt, ReasoningDisclosure prompt if used
└── *.zip        ← optional versioned zip
```

### Zip naming

`Fortress-Phase{id}[-Descriptor]-YYYY-MM-DD.zip`

Examples: `Fortress-Phase1.2A-Updated-2026-06-20.zip`, `Fortress-Phase2.1-Shootout-2026-06-26.zip`

### Steps

1. Ensure `Phases/{id}/Project/` is in desired state.
2. Copy entire `Project/` tree to `Phases/{id}/Export/Project/`.
3. Refresh `Phases/{id}/Export/Prompts/`.
4. Create zip from `Export/` contents if needed.
5. Update `STATUS.md`.

---

## Maintenance (steward)

After any session that changes how we work:

1. Update the relevant section of this document.
2. Note the change in `STATUS.md` under Process Changes.
3. Date the change.

---

**Last Major Update:** 2026-06-26 (canonical five-folder structure, per-phase Export)  
**Maintained By:** Steward (Grok); Director (Mr. Bear) sets pace and priorities