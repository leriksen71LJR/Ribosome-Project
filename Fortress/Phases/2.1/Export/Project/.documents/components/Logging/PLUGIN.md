# Logging Component - Build Plugin

**Plugin ID:** `components/Logging`
**Depends on:** Data
**Tension refs:** [0005](../../tensions/0005-log4net-nu1902.md)
**Status:** Phase 2.1 MVP

---


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

If restore flags vulnerability on required Log4Net version, follow `../../tensions/0005-log4net-nu1902.md` — document approved version or approved replacement in build report.

Logging is optional in handlers unless deviation reported.

---
