# INFRASTRUCTURE-IMPLEMENTATION.md (Core)

**Purpose:** Define the Infrastructure Services Component implementation.

## Contracts
- `IStorageService`
- `IConsole`
- `IInputService`
- `IConfigurationService`

## Implementations
- `SqliteStorageService` (uses SQLCipher)
- `SystemConsole`
- `ConsoleInputService`
- `ConfigurationService`

## Notes
These services provide reusable infrastructure capabilities and follow the standard Component Pattern. Storage service is responsible for encrypted persistence of all item types.