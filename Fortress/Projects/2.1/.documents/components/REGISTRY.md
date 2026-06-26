# Component Registry — Connector Layer

**Role:** Inventory, load order, dependency map, and links to tensions and strategies.  
**Recipe and PLUGIN contract:** `.documents/COMPONENTS.md`

Consult this file after `COMPONENTS.md` and before reading individual plugins.

---

## Plugin load order (mandatory)

Read and implement plugins **in this order**. Matches bottom-up dependencies.

| Step | Plugin | Path | Builds |
|------|--------|------|--------|
| 1 | Data | `components/Data/PLUGIN.md` | `IItem`, item types |
| 2 | Infrastructure | `components/Infrastructure/PLUGIN.md` | Storage, console, input, config |
| 3 | Security | `components/Security/PLUGIN.md` | Encryption, session, storage bridge |
| 4 | Logging | `components/Logging/PLUGIN.md` | Log4Net |
| 5 | Actions | `components/Actions/PLUGIN.md` | Handlers, inventory, `ActionContext` |
| 6 | Bootstrapping | `components/Bootstrapping/PLUGIN.md` | Modules, composition root, main loop, DI matrix |

Then: tests (`.documents/quality/TEST-EXPECTATIONS.md`), report (`.documents/process/BUILD-DISCLOSURE.md`).

**Within each plugin:** follow internal section order (contracts → model → implementations → registration).

---

## Resolved tensions (migrated from Exp06 adr/)

| ID | Title | Status | Path |
|----|-------|--------|------|
| 0001 | Modules folder exception | Resolved | [0001-modules-folder-exception.md](../tensions/0001-modules-folder-exception.md) |
| 0002 | ExitHandler vs session guard | Resolved | [0002-exit-handler-vs-session-guard.md](../tensions/0002-exit-handler-vs-session-guard.md) |
| 0003 | Archive semantics (MVP) | Resolved | [0003-archive-semantics-mvp.md](../tensions/0003-archive-semantics-mvp.md) |
| 0004 | Storage save strategy | Resolved | [0004-storage-save-strategy.md](../tensions/0004-storage-save-strategy.md) |
| 0005 | Log4Net NU1902 | Resolved | [0005-log4net-nu1902.md](../tensions/0005-log4net-nu1902.md) |
| 0006 | Incomplete contract acceptance | Resolved | [0006-incomplete-contract-acceptance.md](../tensions/0006-incomplete-contract-acceptance.md) |

**Strategy link:** Save behavior also documented in [save-strategy.md](../strategies/save-strategy.md).

---

## Open tensions (prototype seeds)

| ID | Title | Status | Path |
|----|-------|--------|------|
| 0007 | Wrong-password / first-run UX | Open | [0007-wrong-password-ux.md](../tensions/0007-wrong-password-ux.md) |
| 0008 | Schema bootstrap paths | Open | [0008-schema-bootstrap.md](../tensions/0008-schema-bootstrap.md) |
| 0009 | Export-backup edges | Open | [0009-export-backup-edges.md](../tensions/0009-export-backup-edges.md) |

---

## Strategies

| Name | Status | Path |
|------|--------|------|
| Save strategy | Active | [save-strategy.md](../strategies/save-strategy.md) |
| Disclosure + maintenance | Active | [disclosure-maintenance.md](../strategies/disclosure-maintenance.md) |

---

## When to consult tensions

| Situation | Action |
|-----------|--------|
| Behavior fits one component plugin | Patch `components/<Name>/PLUGIN.md` — **prefer this** |
| Two rules conflict | Consult tension record + cite in build report |
| Cross-component bridge | Component bridge doc + tension if acceptance criteria needed |

**Seam types:** S1 cross-component contract · S2 handler behavior · S3 process exception

Era B cluster register: `Fortress/Research/BuildDisclosure/Build-Agent-Disclosure-Responses-2026-06-21.md` Appendix D.3.