# Phase 1.1 Requirements

**Status:** Mandatory for Phase 2.1 builds using this doc tree (implements Phase 1.2A application scope).

---

## 1. Async Handlers

```csharp
Task<bool> ExecuteAsync(ActionContext context, CancellationToken cancellationToken = default);
```

Synchronous `Execute` is a process violation. Contract: `components/Actions/PLUGIN.md` (IActionHandler section).

---

## 2. Combined Build Report

One file in `Builds/` per `process/BUILD-DISCLOSURE.md`.

---

## 3. Deviation Reporting

Every deviation from `process/AGENTS.md` or component specs → build report §4.

---

## 4. Documentation Layout (Phase 2.1)

Agents using this package read the **assigned shootout copy** of `Project/` (`.documents/` read-only, `Builds/` writable). Follow phase-root `AGENTS.md` read order.

---

## 5. Invention Summary

Include mandatory Invention Summary table in every build report (`process/BUILD-DISCLOSURE.md` §7). Silent functional invention on High seams (e.g. S1 encryption) is a QC failure.

---

## 6. Pre-Build Disclosure (Deprecated)

Standalone `REASONING-*.md` pre-build files are **not** required for standard Phase 2.1 builds. Rule 12 governs: one post-build `BUILD-REPORT-…` only (`process/AGENTS.md` Rule 11 — Post-Build Build Disclosure).