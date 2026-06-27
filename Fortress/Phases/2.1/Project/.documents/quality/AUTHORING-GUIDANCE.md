# Authoring Guidance (Stewards)

**Audience:** Documentation stewards — **not** on default agent read path (`README.md`).

**Purpose:** Preserve Exp05 meta-knowledge about how specs fail and how to patch without re-splitting T0 content.

---

## Process vs requirements inversion

When agents rate process docs higher than requirements docs, **invest in component specs and ADRs**, not new process strategy files. See `perspectives/Process-vs-Requirements-Inversion.md`.

---

## Deferred phrases (T2 anti-pattern)

Avoid outsourcing decisions to agents:

| Phrase | Risk | Fix |
|--------|------|-----|
| “archive/delete per storage design” | Convergent hard-delete invention | Explicit behavior in handler row + ADR |
| “as appropriate” | Unbounded interpretation | Table or enumerated cases |
| “handle according to requirements” | Circular | Cross-link to component spec section |

Replace with **tables**, **acceptance criteria**, or **ADR link** (`adr/REGISTRY.md`).

---

## Where to patch

| Change type | Location | Do not |
|-------------|----------|--------|
| Executable behavior | `components/<Name>/PLUGIN.md` | Split into separate “strategy” file on agent path |
| Rule collision | New or updated `adr/NNNN-*.md` + registry row | Narrative-only seam essay |
| Process rule | `process/AGENTS.md` | Duplicate 20 strategy files |
| QC / disclosure | `quality/*` | Hide invention in perspectives only |

**Open/Closed:** Extend via new ADRs and additive component sections — avoid thinning high-traffic mRNA into stubs.

---

## Versioning and deprecation

When changing an ADR or handler inventory row:

1. Add **Status** and date in ADR header.
2. If superseding, note prior decision in ADR body.
3. Do not delete seam history — move superseded text to `archive/` if removed from active path.

---

## Seam registry discipline

Before adding ADR-0007+:

- Confirm the seam is not closable by a **component spec patch** alone.
- Register in `adr/REGISTRY.md` with risk level (S1/S2/S3).
- Link from the component doc that triggered the seam.