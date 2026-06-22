# Bootstrapping — Bootstrapper

**Path:** `src/Fortress.Console/Components/Bootstrapping/Implementations/`

## Responsibilities

1. Register modules (or receive built `IServiceProvider`)
2. Initialize Log4Net
3. Master password prompt / first-time setup
4. Build initial `ActionContext` (session + loaded items)
5. Run main menu loop — see `architecture/COMPOSITION-ROOT.md`

## Main loop ownership

Bootstrapping owns:

- Resolving `IEnumerable<IActionHandler>`
- Filtering by `IsVisible`
- Assigning ephemeral menu numbers
- Dispatching `ExecuteAsync`

Handlers own visibility predicates and business logic only.