# Archive

**Experiment 06** replaces Experiment 05 composite areas (`Core/`, `Workflow/`, `Seams/` as top-level concerns) with `CORE.md` + `COMPONENTS.md` + `components/*/PLUGIN.md` + `adr/` + collapsed `process/`.

## Exp05 composite snapshot

Read-only copy: `archive/exp05-composite/` (from Experiment 05 zip extract).

## Exp05 → DI-pattern content map

| Exp05 area | DI-pattern home |
|------------|-----------------|
| `Core/HANDLER-INVENTORY` (stub) | `components/Actions/PLUGIN.md` handler inventory (full T0) |
| `Core/SECURITY-IMPLEMENTATION` (stub) | `components/Security/PLUGIN.md` |
| `Core/*` contracts/models | `components/Actions/PLUGIN.md`, `components/Data/PLUGIN.md` |
| `Core/BOOTSTRAPPING-MODULES` | `components/Bootstrapping/PLUGIN.md` |
| `Workflow/AGENTS-Core-Rules` + Process-Strategies | `process/AGENTS.md`, `process/BUILD-DISCLOSURE.md` |
| `Workflow/BuildDisclosure-Core-Protocol` | `process/BUILD-DISCLOSURE.md` (Era C `BUILD-REPORT` naming) |
| `Seams/DECISION-PROCEDURES` DP-01–05 | `adr/0001`–`0005`, `adr/REGISTRY.md` |
| `Seams/*` (remaining) | `adr/0006`, `quality/INVENTION-DISCLOSURE.md`, plugin patches |
| `Seams/UX`, `DOUBLE-PASSWORD` | `components/Security/PLUGIN.md` UX section |
| `Seams/INTEGRATION-TESTS`, `TEST-COVERAGE-*` | `quality/TEST-EXPECTATIONS.md` |
| `Seams/DEFERRED-PHRASE` | `quality/AUTHORING-GUIDANCE.md` |
| `Quality/*` | `quality/EvaluationCriteria.md`, `quality/INVENTION-DISCLOSURE.md` |
| `Perspectives/*` | `perspectives/*` (identical copy) |
| `Archive/Original-*` | Provenance pointers only — live originals in export `.docs/` |
| Pre-plugin split files | `archive/plugin-v1-split/` (not on agent read path) |

**Live export:** `Fortress/Project/` unchanged.