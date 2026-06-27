# Fortress Phases — Agent Packages

**Audience:** Director (Mr. Bear), steward — not required reading for build agents.

Historical experiments live under `Fortress/Archive/Experiments/`. When one is ready for agent testing, promote it to `Phases/{id}/Project/`.

---

## Phases (living table)

| Phase | Project (source) | Export | Status | Notes |
|-------|------------------|--------|--------|-------|
| **1.2A** | `Phases/1.2A/Project/` | `Phases/1.2A/Export/` | Default export | Frozen legacy baseline (`.docs/` layout) |
| **2.1** | `Phases/2.1/Project/` | `Phases/2.1/Export/` | Scaffolded | `.documents/` + tensions + REGISTRY (Exp06 fork) |
| **2.2** | — | — | Exploration only | Idea files under `Phases/2.2/` — not a build package yet |

Update when adding phases or changing the default shootout. A log line or `STATUS.md` bump is enough.

---

## Shootout reminder

1. Name the phase in the prompt.
2. Copy `Phases/{id}/Export/Project/` to an external shootout root.
3. Agent project root = folder containing that phase's `AGENTS.md`.

See `Fortress/PROCESS.md` — Charter and export rules.

---

## Phase folder convention

```
Phases/{id}/
├── Project/     ← living agent package (all prep for the coding agent)
├── Export/      ← mirror + Prompts/ + zip when shooting out
└── *.md         ← optional steward meta at phase root (e.g. preflight)
```