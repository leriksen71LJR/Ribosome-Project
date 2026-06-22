# EXIT-HANDLER-EXCEPTION.md

**Purpose:** Document the known exception to the general session guard rule for the ExitHandler.

## Rule
When the general session guard rule conflicts with `HANDLER_INVENTORY.md` visibility rules for `ExitHandler`, the inventory specificity takes precedence.

`ExitHandler` may run even when the session is locked in certain contexts.

## Notes
This exception is registered in `Seams/DECISION-PROCEDURES.md` (DP-01). It is treated as a deliberate, documented seam rather than an ambiguity.