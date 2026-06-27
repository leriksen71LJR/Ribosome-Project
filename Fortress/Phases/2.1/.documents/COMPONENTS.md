# COMPONENTS — Recipe & Plugin Contract

**Single responsibility:** Component pattern, architectural style, technology stack, and **PLUGIN.md contract**.  
**Load order and inventory:** `.documents/components/REGISTRY.md` (connector layer).  
**Consumer:** Build agent (read after `.documents/CORE.md`).

Each folder under `components/` is a **strategy plugin** — the full build spec for one code component. One agent entry file per plugin: **`PLUGIN.md`**.

---

## Component pattern (code)

All code under `src/Fortress.Console/Components/<Name>/`:

| Subfolder | Purpose |
|-----------|---------|
| `Contracts/` | Interfaces |
| `Implementations/` | Injectable services and handlers |
| `Model/` | Pure data (not injectable) |

**Exception:** `Bootstrapping/Modules/` for `IDependencyModule` — see tension [0001](../tensions/0001-modules-folder-exception.md).

`Program.cs` is the only code file outside `Components/`.

---

## Architectural style

1. **Strategy by List<T>** — `IEnumerable<IActionHandler>` for menu actions.
2. **IDependencyModule** — each component registers its services; see Bootstrapping plugin.
3. **Dynamic menu** — `IsVisible(context)`; bootstrapping assigns numbers at display time.

**Technology:** .NET 8+, MS DI, SQLCipher, Argon2id, Log4Net, xUnit + Moq.

---

## PLUGIN.md contract

Every plugin file must include:

```markdown
# {Name} Component — Build Plugin
**Plugin ID:** `components/{Name}`
**Depends on:** ...
**Tension refs:** ...
**Status:** Phase 2.1 MVP
```

Body: executable pseudocode — tables, interfaces, flows. **No** “see strategy file elsewhere” stubs.

When a tension triggers during build → cite tension in build report and consult `.documents/components/REGISTRY.md`.

---

## Adding a plugin (Phase 2+)

1. Add `components/NewName/PLUGIN.md`.
2. Add row to `.documents/components/REGISTRY.md`.
3. Register services in Bootstrapping plugin / new `*Module.cs`.
4. Propose new tension in `.codingAgent/` if a cross-cutting exception is required — steward promotes.

Do not add parallel Workflow/Seams top-level trees on the agent path.

---

**Next:** `.documents/components/REGISTRY.md`