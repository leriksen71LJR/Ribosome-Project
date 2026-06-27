# MODULES-FOLDER-EXCEPTION.md

**Purpose:** Document the known exception to the standard three-folder component pattern for the `Bootstrapping/Modules/` path.

## Rule
The `Bootstrapping/Modules/` path is an explicit, registered exception to the standard component folder structure when the architecture and prompts require `IDependencyModule` registration files to live there.

## Notes
This exception is captured in `Seams/DECISION-PROCEDURES.md` (DP-02). It allows the bootstrapping mechanism to function without violating the overall Component Pattern.