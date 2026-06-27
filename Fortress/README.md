# Fortress

**Fortress** is a documentation-first training system for building reliable AI coding agents.

Its purpose is to develop a repeatable process where AI agents can take a set of high-quality documents and produce correct, maintainable code with minimal human intervention — while making their reasoning, assumptions, and deviations **visible** before they write any code.

This project is **not** primarily about building the Fortress application itself.  
It is about **building the documentation and process discipline** that makes trustworthy agentic development possible.

---

## Folder Structure

| Folder | Purpose | Who reads it |
|--------|---------|--------------|
| `Archive/` | Historical experiments, drafts, investigations, superseded material | Humans |
| `Core/` | Timeless essentials — charter, structure, context, memory capsules, handoff | Humans |
| `Ideas/` | Ongoing ideas, templates, operational tooling | Humans |
| `Phases/` | Phase-specific work — agent packages (`Project/`), exports (`Export/`), phase meta | Director, steward; agents see **shootout copy only** |
| `Records/` | Operational records — logs, backlog, handoff exports, backups, phase history | Humans |
| `PROCESS.md` | Operating model and workflow | Everyone |
| `STATUS.md` | Living project snapshot | Everyone |
| `README.md` | This file | Everyone |

**Agent rule:** Build agents receive a **shootout copy** of `Phases/{id}/Project/` (from `Phases/{id}/Export/`). They must not read `Archive/`, `Core/`, `Ideas/`, or `Records/` during implementation.

**Phase layout:**

```
Phases/{id}/
├── Project/     ← living agent package (AGENTS.md is project root)
├── Export/      ← mirror + prompts + zip for shootouts
└── …            ← optional phase-root meta (e.g. preflight notes)
```

See `Phases/PHASES.md` for the phase index.

---

## Quick Start

### For build agents (shootout)

1. Read `AGENTS.md` at the root of your assigned package (highest authority).
2. Follow the mandatory read order in that file.
3. Write one combined build report to `Builds/` per `BUILD-DISCLOSURE.md`.
4. Never silently assume or work around gaps — report them explicitly.

### For humans (Director / steward)

- `STATUS.md` — where we are now
- `PROCESS.md` — how sessions run
- `Records/Logs/` — session narrative and preflight reports
- `Core/Current-Context.md` — research/context snapshot

After significant work, update living docs so future sessions do not depend on chat memory.

---

## Maintenance (steward)

Keep `STATUS.md` and `PROCESS.md` current after meaningful sessions. Prefer small, frequent updates over drift.

**Last Updated:** 2026-06-26  
**Maintained By:** Steward (Grok), with Director oversight