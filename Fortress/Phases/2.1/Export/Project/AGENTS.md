# AGENTS.md — Fortress Phase 2.1

**Phase root.** Highest authority for this shootout package.

**Full process rules and read order:** `.documents/process/AGENTS.md`

---

## Critical Rules (phase root)

### 1. Two-zone documentation boundary

| Zone | Path | Agent access |
|------|------|--------------|
| **Authoritative** | `.documents/` | **Read-only** during builds |
| **Proposals** | `.codingAgent/` | Writable — drafts only, never authoritative |
| **Reports** | `Builds/` | Writable — combined build reports |

Agents are **sensors**. Propose doc changes via the **Documentation Maintenance Proposals** table in build reports or files in `.codingAgent/`. Steward promotes into `.documents/`.

### 2. Implementation order

Build bottom-up per `.documents/components/REGISTRY.md` plugin load order:

Data → Infrastructure → Security → Logging → Actions → Bootstrapping → Tests

### 3. Mandatory read order

1. This file (phase root)
2. `.documents/CORE.md`
3. `.documents/COMPONENTS.md`
4. `.documents/components/REGISTRY.md`
5. Six PLUGINs in registry order
6. Relevant `.documents/tensions/` or `.documents/strategies/` when triggered
7. `.documents/process/BUILD-DISCLOSURE.md` before writing report

### 4. Output and boundaries

- Write code to the **assigned shootout project root** only
- Write reports to `Builds/` only
- Do **not** read outside your assigned shootout package (`Archive/`, `Core/`, `Ideas/`, `Records/`, parent `Phases/` tree)
- Do **not** implement in `fortress-design` — code goes to the external shootout project root only

### 5. Deviation and gap reporting

Report every rule violation and every high-risk assumption. No silent workarounds. Detail: `.documents/process/AGENTS.md` Rules 7–12.

---

**Next:** `.documents/process/AGENTS.md`