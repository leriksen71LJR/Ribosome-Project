# Logging Component — Implementation

**Path:** `src/Fortress.Console/Components/Logging/`

## Contract

```csharp
public interface ILoggingService
{
    void LogInfo(string message);
    void LogWarning(string message);
    void LogError(string message, Exception? exception = null);
}
```

## Implementation

- `Log4NetLoggingService` : `ILoggingService`
- Configure via `log4net.config` at startup

## Log4Net NU1902

If restore flags vulnerability on required Log4Net version, follow `adr/0005-log4net-nu1902.md` — document approved version or approved replacement in build report.

Logging is optional in handlers unless deviation reported.