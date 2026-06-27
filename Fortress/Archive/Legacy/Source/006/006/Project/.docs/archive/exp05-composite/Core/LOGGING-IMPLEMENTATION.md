# LOGGING-IMPLEMENTATION.md (Core)

**Purpose:** Define the Logging Component implementation for Phase 1.2A.

## Contract
- `ILoggingService`

## Implementation
- `Log4NetLoggingService` — wrapper around Log4Net

## Configuration
Log4Net is configured via XML (`log4net.config`) and initialized at application startup in the Bootstrapping Component.

## Notes
This component provides structured logging throughout the application. It follows the standard Component Pattern (Contracts → Implementations).