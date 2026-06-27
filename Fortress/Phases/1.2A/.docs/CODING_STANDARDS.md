# Coding Standards

This document defines the coding style, quality expectations, and defensive programming practices used in the Fortress project.

**Important Note on Rules**  
All behavioral, process, and enforcement rules for the build agent are defined in `AGENTS.md`.  
This includes rules such as:
- Output Location Rule
- Violation / Deviation Reporting
- Deep Documentation Audit requirement
- Documentation Boundary Rule

This document (`CODING_STANDARDS.md`) focuses **only** on code-level standards and implementation practices.

---

## Core Principles

- Keep classes and methods small and focused.
- Prefer early returns and guard clauses over deep nesting.
- Write defensive code — validate inputs and handle error conditions explicitly.
- Each class should have one clear reason to change.
- Favor readability and maintainability over cleverness.
