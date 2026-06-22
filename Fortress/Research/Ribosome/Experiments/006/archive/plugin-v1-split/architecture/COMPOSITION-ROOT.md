# Composition Root

`Program.cs` is the **only** composition root. It may discover and invoke `IDependencyModule` implementations — **no direct service registration** in `Program.cs`.

---

## Startup sequence

```csharp
// 1. SQLCipher native init — before any SqliteConnection
SQLitePCL.Batteries_V2.Init();

// 2. Build DI container via modules
var services = new ServiceCollection();
foreach (var module in modules)
    module.Register(services);

var serviceProvider = services.BuildServiceProvider();

// 3. Resolve bootstrapper / run main loop
var bootstrapper = serviceProvider.GetRequiredService<Bootstrapper>();
await bootstrapper.RunAsync(cancellationToken);
```

Module list and order: `components/Bootstrapping/MODULES.md`.

---

## Bootstrapper responsibilities

1. Initialize logging (Log4Net)
2. Prompt master password / first-time setup (see `components/Security/IMPLEMENTATION.md`)
3. Unlock session via `ISessionService`
4. Load items via `IStorageService.LoadAsync` (key applied per connection)
5. Create `ActionContext` with session + items
6. Run persistent menu loop

---

## Main loop pseudocode

```csharp
while (!cancellationToken.IsCancellationRequested)
{
    var handlers = serviceProvider.GetRequiredService<IEnumerable<IActionHandler>>();
    var visible = handlers.Where(h => h.IsVisible(context)).ToList();

    // Assign menu numbers 1..N at display time — never in handler Name
    for (var i = 0; i < visible.Count; i++)
        console.WriteLine($"{i + 1}. {visible[i].Name}");

    var selection = input.ReadLine();
    if (!int.TryParse(selection, out var index) || index < 1 || index > visible.Count)
        continue;

    var handler = visible[index - 1];
    await handler.ExecuteAsync(context, cancellationToken);

    // Display context.ExceptionErrors, refresh items if needed
}
```

**ExitHandler:** Always visible (`adr/0002-exit-handler-vs-session-guard.md`). May run when session is locked.

**Menu numbering:** `components/Actions/HANDLER-INVENTORY.md` → Menu Numbering section.