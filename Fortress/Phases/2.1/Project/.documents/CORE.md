# CORE — Documentation Composition Root

**Phase:** 2.1 — DI-pattern + tensions/strategies  
**Audience:** Build agents (read after phase-root `AGENTS.md` and `.documents/process/AGENTS.md`)  
**Single responsibility:** How this doc system composes a build — not component-specific pseudocode.

---

## Documentation-as-mRNA

Fortress documentation is **executable pseudocode**. The build agent is the ribosome; **component plugins** (`.documents/components/<Name>/PLUGIN.md`) are the strategies for what to code.

| Role | Location |
|------|----------|
| Phase root rules | `AGENTS.md` (phase root) |
| Authority & process rules | `.documents/process/AGENTS.md` |
| **Composition orchestration** | **This file** |
| Recipe + PLUGIN contract | `.documents/COMPONENTS.md` |
| Connector (order, inventory, links) | `.documents/components/REGISTRY.md` |
| Per-component build spec | `.documents/components/*/PLUGIN.md` |
| Cross-cutting friction | `.documents/tensions/` |
| Chosen behaviors | `.documents/strategies/` |
| QC & tests | `.documents/quality/` |
| Build report output | `Builds/` |
| Agent proposals (non-authoritative) | `.codingAgent/` |

---

## Build flow

1. Read phase-root `AGENTS.md` — two-zone boundary and read order.
2. Read `.documents/COMPONENTS.md` — plugin pattern and contract.
3. Read `.documents/components/REGISTRY.md` — load order and tension/strategy links.
4. Read each **component plugin** in registry order.
5. Consult `.documents/tensions/` or `.documents/strategies/` when triggered.
6. Implement code under `src/Fortress.Console/Components/` mirroring plugin IDs.
7. Write tests per `.documents/quality/TEST-EXPECTATIONS.md`.
8. Write one combined report per `.documents/process/BUILD-DISCLOSURE.md`.

---

## Composition root (code)

`Program.cs` is the **only** runtime composition root. It discovers `IDependencyModule` implementations — **no direct service registration** in `Program.cs`.

Startup, DI matrix, main loop, and lifetimes: **`components/Bootstrapping/PLUGIN.md`** (last plugin).

---

## What is not in Core

- Handler tables, SQL schema, crypto parameters → **component plugins**
- Process Rule 10–12 detail → **`.documents/process/`**
- Seam resolutions → **`.documents/tensions/`**
- Steward authoring meta → **`.documents/quality/AUTHORING-GUIDANCE.md`** (off-path)

---

## Open/Closed

- **Core**, **COMPONENTS.md**, and plugin contracts change rarely.
- **Extend** by patching plugins, adding tension/strategy records (steward-promoted), or `.codingAgent/` proposals.
- **Do not** split plugin mRNA into external strategy files on the agent read path.

---

**Next:** `.documents/COMPONENTS.md`