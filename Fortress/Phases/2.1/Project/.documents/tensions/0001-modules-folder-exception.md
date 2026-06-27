# ADR-0001: Bootstrapping/Modules/ Folder Exception

**Status:** Resolved  
**Seam:** S3 — process exception

## Context

`process/AGENTS.md` Rule 2 requires `Contracts/`, `Implementations/`, `Model/` per component. Architecture and build prompts require `IDependencyModule` classes under `Components/Bootstrapping/Modules/`.

## Decision

`Components/Bootstrapping/Modules/` is a **registered exception**. Module registration files live there; bootstrapper implementations remain under `Bootstrapping/Implementations/`.

## Consequences

- Agents may create `*Module.cs` under `Modules/` without reporting a component-pattern violation.
- All other components must use the three-folder pattern.

**Evidence:** Codex Era B disclosure — Modules folder invention cluster.