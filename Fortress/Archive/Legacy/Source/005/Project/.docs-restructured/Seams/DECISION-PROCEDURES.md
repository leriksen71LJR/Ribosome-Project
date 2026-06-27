# DECISION-PROCEDURES.md

**Purpose:** Registry of decision procedures for situations where general rules conflict or specifications are ambiguous.

Each procedure should be kept small and focused. New procedures can be added without modifying this file's structure.

## Current Procedures

### DP-01: ExitHandler vs Session Guard
When `AGENTS.md` general session guard rule conflicts with `HANDLER_INVENTORY.md` visibility rules for ExitHandler, the inventory specificity takes precedence.

### DP-02: Modules Folder Exception
The `Bootstrapping/Modules/` path is an explicit exception to the standard three-folder component pattern when architecture and prompts require `IDependencyModule` registration files there.

### DP-03: Archive Semantics (MVP)
For Phase 1.2A MVP, "archive" means hard delete from active storage. Future versions may introduce soft-delete columns.

### DP-04: Storage Save Strategy (MVP)
Full-table rewrite is acceptable for MVP. Incremental updates and migrations are deferred to later phases.

### DP-05: Log4Net NU1902 Policy
When architecture requires Log4Net but the version has known vulnerabilities, document the approved version or approved replacement policy.

---

*New decision procedures should be added following the same lightweight format. This file is designed to be extended through addition rather than modification of existing content.*