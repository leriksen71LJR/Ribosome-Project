# Authoring Guidance (Stewards)

**Audience:** Documentation stewards — **not** on default agent read path (`README.md`).

**Purpose:** Preserve Exp05 meta-knowledge about how specs fail and how to patch without re-splitting T0 content.

---

## Process vs requirements inversion

When agents rate process docs higher than requirements docs, **invest in component specs and tensions**, not new process strategy files. See `perspectives/Process-vs-Requirements-Inversion.md`.

---

## Deferred phrases (T2 anti-pattern)

Avoid outsourcing decisions to agents:

| Phrase | Risk | Fix |
|--------|------|-----|
| “archive/delete per storage design” | Convergent hard-delete invention | Explicit behavior in handler row + tension |
| “as appropriate” | Unbounded interpretation | Table or enumerated cases |
| “handle according to requirements” | Circular | Cross-link to component spec section |

Replace with **tables**, **acceptance criteria**, or **tension link** (`components/REGISTRY.md` + `tensions/`).

---

## Where to patch

| Change type | Location | Do not |
|-------------|----------|--------|
| Executable behavior | `components/<Name>/PLUGIN.md` | Split into separate “strategy” file on agent path |
| Rule collision | New or updated `tensions/NNNN-*.md` + REGISTRY row | Narrative-only seam essay |
| Process rule | `process/AGENTS.md` | Duplicate 20 strategy files |
| QC / disclosure | `quality/*` | Hide invention in perspectives only |

**Open/Closed:** Extend via new tensions and additive component sections — avoid thinning high-traffic mRNA into stubs.

---

## Versioning and deprecation

When changing a tension or handler inventory row:

1. Add **Status** and date in the tension record.
2. If superseding, note prior decision in the tension body.
3. Do not delete seam history — move superseded text to `archive/` if removed from active path.

---

## Seam registry discipline

Before adding tension 0007+:

- Confirm the seam is not closable by a **component spec patch** alone.
- Register in `components/REGISTRY.md` with risk level (S1/S2/S3).
- Link from the component doc that triggered the seam.