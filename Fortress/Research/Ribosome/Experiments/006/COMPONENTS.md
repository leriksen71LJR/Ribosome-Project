# COMPONENTS — Strategy Plugin Registry

**Single responsibility:** Component pattern, plugin load order, and plugin file contract.  
**Consumer:** Build agent (read after `CORE.md`).

Each folder under `components/` is a **strategy plugin** — the full build spec for one code component. One agent entry file per plugin: **`PLUGIN.md`**.

---

## Component pattern (code)

All code under `src/Fortress.Console/Components/<Name>/`:

| Subfolder | Purpose |
|-----------|---------|
| `Contracts/` | Interfaces |
| `Implementations/` | Injectable services and handlers |
| `Model/` | Pure data (not injectable) |

**Exception:** `Bootstrapping/Modules/` for `IDependencyModule` — `adr/0001-modules-folder-exception.md`.

`Program.cs` is the only code file outside `Components/`.

---

## Architectural style

1. **Strategy by List<T>** — `IEnumerable<IActionHandler>` for menu actions.
2. **IDependencyModule** — each component registers its services; see Bootstrapping plugin.
3. **Dynamic menu** — `IsVisible(context)`; bootstrapping assigns numbers at display time.

**Technology:** .NET 8+, MS DI, SQLCipher, Argon2id, Log4Net, xUnit + Moq.

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

Then: tests (`quality/TEST-EXPECTATIONS.md`), report (`process/BUILD-DISCLOSURE.md`).

**Within each plugin:** follow internal section order (contracts → model → implementations → registration).

---

## PLUGIN.md contract

Every plugin file must include:

```markdown
# {Name} Component — Build Plugin
**Plugin ID:** `components/{Name}`
**Depends on:** ...
**ADR refs:** ...
**Status:** Phase 1.2A MVP
```

Body: executable pseudocode — tables, interfaces, flows. **No** “see strategy file elsewhere” stubs.

When a seam triggers during build → `adr/REGISTRY.md` + cite ADR in build report.

---

## Adding a plugin (Phase 2+)

1. Add `components/NewName/PLUGIN.md`.
2. Add row to the table above in this file.
3. Register services in Bootstrapping plugin / new `*Module.cs`.
4. Add ADR if a cross-cutting exception is required.

Do not add parallel Workflow/Seams top-level trees on the agent path.

---

## Split-file archive

Pre-plugin split sources: `archive/plugin-v1-split/` (not on read path).