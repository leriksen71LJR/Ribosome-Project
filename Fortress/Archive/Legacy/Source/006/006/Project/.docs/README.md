# `.docs` — Experiment 06

**Status:** Research experiment — **not** live `Fortress/Project/` export.  
**Model:** `CORE.md` + `COMPONENTS.md` + six **component strategy plugins** (`components/*/PLUGIN.md`).  
**Hypothesis:** DI-aligned plugins with full T0 mRNA reduce seam invention vs Exp05 composite stubs.

---

## Mandatory read order (build agents)

1. `process/AGENTS.md` — authority and rules
2. `CORE.md` — how the doc system composes a build
3. `COMPONENTS.md` — plugin registry, pattern, load order
4. `components/Data/PLUGIN.md`
5. `components/Infrastructure/PLUGIN.md`
6. `components/Security/PLUGIN.md`
7. `components/Logging/PLUGIN.md`
8. `components/Actions/PLUGIN.md`
9. `components/Bootstrapping/PLUGIN.md`
10. `quality/TEST-EXPECTATIONS.md` — before writing tests
11. `process/BUILD-DISCLOSURE.md` + `process/PHASE_1_1.md`
12. `adr/REGISTRY.md` — only when a seam is triggered

**Off-path:** `perspectives/`, `quality/AUTHORING-GUIDANCE.md`, `archive/`, `architecture/` (retired)

**Steward:** Prefer patching plugins + ADRs over new process files (`perspectives/Process-vs-Requirements-Inversion.md`).

---

## Layout

| Area | Purpose |
|------|---------|
| `CORE.md` | Composition root (doc system) |
| `COMPONENTS.md` | Plugin registry & component pattern |
| `components/*/PLUGIN.md` | Strategy plugin per code component |
| `process/` | Ribosome rules and disclosure |
| `quality/` | Tests bar, audit, invention disclosure |
| `adr/` | Cross-plugin seam decisions |
| `Builds/` | Agent write target for reports |
| `archive/` | Exp05 composite, plugin-v1-split, maps |

---

## Evaluation

Era B benchmark: `Fortress/Research/BuildDisclosure/Build-Agent-Disclosure-Responses-2026-06-21.md` (§9.5, Appendix D).

**Last updated:** 2026-06-21 (final — core + plugins)