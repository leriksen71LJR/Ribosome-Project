# HANDLER-INVENTORY.md (Core)

**Purpose:** Define the complete list of required `IActionHandler` implementations for the current phase.

This file focuses solely on the inventory of handlers. Visibility rules, registration strategy, and dependencies have been moved to separate strategy files.

## Required Handlers (Phase 1.2A)

- AddTaskHandler
- AddNoteHandler
- AddCredentialHandler
- AddGoalHandler
- ListItemsHandler
- CompleteTaskHandler
- ArchiveCompletedHandler
- SearchItemsHandler
- ExportBackupHandler
- LockSessionHandler
- ExitHandler

## Notes
- All handlers must implement `IActionHandler`.
- Specific visibility logic and registration details are defined in strategy files under `Workflow/` and `Seams/`.

*This file is intentionally narrow in scope to support Single Responsibility.*