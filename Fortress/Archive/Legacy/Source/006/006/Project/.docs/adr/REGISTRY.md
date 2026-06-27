# ADR Registry

Decision records for documented seams (collapsed from Experiment 05 `Seams/`). Consult when build triggers a rule collision or ambiguous spec.

## When to use an ADR vs a component patch

| Situation | Action |
|-----------|--------|
| Behavior can be stated as table/pseudocode in one component | Patch `components/<Name>/PLUGIN.md` — **prefer this** |
| Two rules conflict (process vs inventory, pattern vs Modules path) | ADR + cite in build report |
| Cross-component bridge (S1) | Component bridge doc + ADR if acceptance criteria needed |

**Open/Closed:** Add new `adr/NNNN-*.md` and a registry row — do not rewrite existing component mRNA into stubs. Steward rules: `quality/AUTHORING-GUIDANCE.md`.

| ID | Title | Trigger | Risk |
|----|-------|---------|------|
| [0001](0001-modules-folder-exception.md) | Modules folder exception | Component three-folder rule vs `Bootstrapping/Modules/` | Medium |
| [0002](0002-exit-handler-vs-session-guard.md) | ExitHandler vs session guard | AGENTS Rule 3 vs inventory Exit row | Medium |
| [0003](0003-archive-semantics-mvp.md) | Archive semantics (MVP) | Archive handler behavior | Low |
| [0004](0004-storage-save-strategy.md) | Storage save strategy | `SaveAsync` unspecified | Medium |
| [0005](0005-log4net-nu1902.md) | Log4Net NU1902 | Required Log4Net + vulnerability advisory | Low |
| [0006](0006-incomplete-contract-acceptance.md) | Contract acceptance criteria | Incomplete interface bodies (T3) | **High** |

**Seam types:** S1 cross-component contract · S2 handler behavior · S3 process exception

Era B cluster register: `Fortress/Research/BuildDisclosure/Build-Agent-Disclosure-Responses-2026-06-21.md` Appendix D.3.