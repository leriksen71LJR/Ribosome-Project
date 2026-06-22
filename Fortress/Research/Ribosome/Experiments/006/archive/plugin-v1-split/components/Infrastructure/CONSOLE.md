# Infrastructure — Console & Input

**Path:** `src/Fortress.Console/Components/Infrastructure/`

## Contracts

```csharp
public interface IConsole
{
    void WriteLine(string message);
    void Write(string message);
}

public interface IInputService
{
    string? ReadLine();
}

public interface IConfigurationService
{
    string GetDatabasePath();
    string GetBackupDirectory();
    TimeSpan GetSessionTimeout();
}
```

## Implementations

- `SystemConsole` : `IConsole`
- `ConsoleInputService` : `IInputService`
- `ConfigurationService` : `IConfigurationService`

Handlers use `IConsole` / `IInputService` for all user I/O — no direct `Console.ReadLine` in handlers.