# CORE — Documentation Composition Root

**Experiment:** 06 — DI-pattern documentation  
**Audience:** Build agents (read after `process/AGENTS.md`)  
**Single responsibility:** How this doc system composes a build — not component-specific pseudocode.

---

## Documentation-as-mRNA

Fortress documentation is **executable pseudocode**. The build agent is the ribosome; **component plugins** (`components/<Name>/PLUGIN.md`) are the strategies for what to code.

| Role | Location |
|------|----------|
| Authority & process rules | `process/AGENTS.md` |
| **Composition orchestration** | **This file (`CORE.md`)** |
| Component plugin registry & pattern | `COMPONENTS.md` |
| Per-component build spec | `components/*/PLUGIN.md` |
| Cross-plugin seam decisions | `adr/` (on demand) |
| QC & tests | `quality/` |
| Build report output | `Builds/` |

---

## Build flow

1. Read `process/AGENTS.md` — rules and boundaries.
2. Read `COMPONENTS.md` — plugin order and plugin contract.
3. Read each **component plugin** in dependency order (see `COMPONENTS.md`).
4. Implement code under `src/Fortress.Console/Components/` mirroring plugin IDs.
5. Write tests per `quality/TEST-EXPECTATIONS.md`.
6. Write one combined report per `process/BUILD-DISCLOSURE.md`.

---

## Composition root (code)

`Program.cs` is the **only** runtime composition root. It discovers `IDependencyModule` implementations — **no direct service registration** in `Program.cs`.

Startup, DI matrix, main loop, and lifetimes: **`components/Bootstrapping/PLUGIN.md`** (last plugin).

---

## What is not in Core

- Handler tables, SQL schema, crypto parameters → **component plugins**
- Process Rule 10–12 detail → **`process/`**
- Seam resolutions → **`adr/`**
- Steward authoring meta → **`quality/AUTHORING-GUIDANCE.md`** (off-path)
- History → **`archive/`** (off-path; agents must not read)

---

## Open/Closed

- **Core** and **COMPONENTS.md** change rarely (new component = index update only).
- **Extend** by adding/patching `components/<Name>/PLUGIN.md` or adding `adr/NNNN-*.md`.
- **Do not** split plugin mRNA into external “strategy files” on the agent read path.

---

**Next:** `COMPONENTS.md`