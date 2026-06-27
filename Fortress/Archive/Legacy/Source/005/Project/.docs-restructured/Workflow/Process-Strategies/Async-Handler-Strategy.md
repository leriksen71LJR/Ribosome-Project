# Async-Handler-Strategy.md

**Type:** Process Strategy

**Purpose:** Enforce the requirement that all `IActionHandler` implementations must use async execution.

## Requirements
- All handlers must implement `Task<bool> ExecuteAsync(...)` instead of a synchronous `Execute` method.
- Every `ExecuteAsync` must begin with guard clauses.

## Rationale
Async execution supports I/O-bound work (storage, encryption, etc.) without blocking the console application. It is a Phase 1.1 mandatory requirement.

## Notes
This strategy is considered non-negotiable for Phase 1.2A and beyond. Deviations require explicit reporting.