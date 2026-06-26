# Fortress

**Fortress** is a documentation-first training system for building reliable AI coding agents.

Its purpose is to develop a repeatable process where AI agents can take a set of high-quality documents and produce correct, maintainable code with minimal human intervention — while making their reasoning, assumptions, and deviations **visible** before they write any code.

This project is **not** primarily about building the Fortress application itself.  
It is about **building the documentation and process discipline** that makes trustworthy agentic development possible.

---

## Folder Structure

| Folder          | Purpose                                                                 | Who Should Read It          | Notes |
|-----------------|-------------------------------------------------------------------------|-----------------------------|-------|
| `Projects/`     | Agent product container — one folder per phase (`1.2A/`, `2.1/`, …). Zipped for shootouts. | AI agents + humans         | See `Projects/PHASES.md` |
| `Research/`     | Human-only thinking space. Contains ideas, analysis, backlogs, and long-term vision. | Humans only                | Agents are **forbidden** from reading this |
| `Export/`       | Clean, versioned shootout zips ready to give to agents                 | Humans                     | Each phase has its own subfolder |
| `Handoff/`      | Meta-discussion and collaboration notes between human and Grok         | Humans                     | Reduces reliance on chat history |
| `Logs/`         | Daily work summaries, decision records, process notes (dated filenames) | Humans                     | Session narrative; see `Logs/README.md` |
| `README.md`     | This file — orientation and maintenance instructions                   | Everyone                   | Start here |
| `PROCESS.md`    | The full operating model and workflow                                  | Everyone                   | How we actually work |
| `STATUS.md`     | Living snapshot of current state, open issues, and recent changes      | Everyone                   | Must be kept current |

**Critical Rule:**  
Agents must **never** read anything inside `Research/`. Agent-facing content lives under `Projects/{phase}/`.

---

## Quick Start

### For AI Agents
1. Read `AGENTS.md` first (highest authority document).
2. Follow the exact reading order and rules defined in the attached `ReasoningDisclosure-Prompt.md`.
3. Produce a `REASONING_YYYY-MM-DD.md` file **before** writing any code.
4. Never silently assume or work around gaps — flag them using Rules 10 and 11.

### For Humans
- Use `STATUS.md` to see where we currently are.
- Use `PROCESS.md` to understand how sessions should run.
- After any significant session (Reasoning Disclosure, build attempt, or major change), update the relevant files so future sessions do not require chat memory.
- Add a dated entry to `Logs/` when work is significant or a focused session ends (see `Logs/README.md`).

---

## Maintenance Instructions for Grok

**You (Grok) are responsible for keeping the following files current:**

- After every Reasoning Disclosure round or build attempt, update `STATUS.md` with:
  - New high-severity gaps discovered
  - Resolutions or workarounds applied
  - Current biggest blocker
  - Date of last meaningful change

- After creating or updating any export zip, update the version and summary in `STATUS.md`.

- If the overall process model changes meaningfully, update `PROCESS.md` and note the change in `STATUS.md`.

- Do **not** let these files become stale. Treat them as active project state, not historical records.

- When in doubt, prefer making small, frequent updates over letting documentation drift.

This project only reduces chat memory dependence if these files are actively maintained.

---

**Last Updated:** 2026-06-26  
**Maintained By:** Grok (with human oversight)