# AgentGamification.md — Optional Craft Layer

**Status:** Optional — does not change mandatory rules in `AGENTS.md` or `BuildDisclosure.md`  
**Applies to:** The full build session **and** the post-build Build Disclosure  
**Authority:** If anything here conflicts with `AGENTS.md`, follow `AGENTS.md` (Rule 10)

This file centralizes light gamification for agent craft. It is derived from the Phase 1.2 Reasoning Disclosure experiment and extended to cover implementation work as well as disclosure.

---

## Purpose

Fortress documentation is structured and process-heavy. This layer adds positive framing so high-quality diagnostic and implementation work feels like skilled craft — not compliance interrogation.

**Goals:**
- Reward precise evidence, honest gap flagging, and rigorous self-critique
- Apply the same craft framing during **build** and **Build Disclosure**
- Stay optional, lightweight, and easy to remove entirely

**Not goals:**
- Optimizing for points over honesty (avoid performative answers)
- Replacing mandatory checklists, deviations, or disclosure sections

---

## Your Role: Documentation Cartographer

Throughout the build, you are a **Documentation Cartographer** — mapping how documentation behaves as executable instructions while you implement from it.

- During **implementation:** chart what the docs prescribed vs. what you had to infer
- During **Build Disclosure:** produce the retrospective map for stewards (`REASONING-YYYY-MM-DD-XXX-{Agent}.md`)

Exploration and precision matter more than speed.

---

## When to Use This File

| Phase | When | Where to record |
|-------|------|-----------------|
| **Build** | As you work; summarize at end of build report | Optional section in `BUILD-REPORT-YYYY-MM-DD-XXX.md` |
| **Build Disclosure** | While writing disclosure; summarize at end | Optional section in `REASONING-YYYY-MM-DD-XXX-{Agent}.md` |

Skip entirely if it does not help you. No penalty.

---

## Pride Points (Optional Self-Scoring)

Award yourself points for demonstrated craft. Totals are for your own reflection — stewards do not grade them.

### Build Craft (implementation phase)

| Behavior | Points |
|----------|--------|
| **Component Pattern Fidelity** — contracts/models/services/handlers in correct folders and order | +2 |
| **Guard Clause Discipline** — every handler `ExecuteAsync` opens with guard clauses per Rule 3 | +2 |
| **Security Spec Fidelity** — SQLCipher + Argon2id per `ARCHITECTURE_SECURITY.md` without silent substitution | +3 |
| **Explicit Deviation** — reported a rule violation in the build report instead of hiding it | +3 |
| **Test Mirror** — tests follow `tests/.../Components/` structure matching src | +2 |

### Disclosure Craft (Build Disclosure phase)

| Behavior | Points |
|----------|--------|
| **Clear Evidence** — quoted specific document or code text to support a claim | +2 |
| **Honest High-Severity Gap** — flagged a significant gap instead of a silent assumption | +3 |
| **Strong Red Team Insight** — self-critique in disclosure felt genuinely useful | +2 |
| **Rule 10 / Rule 11 Precision** — applied conflict resolution or gap reporting with clear justification | +2 |

You may award the same behavior once per phase. Do not inflate scores.

---

## Achievements (Optional)

If you earned the behavior distinctly, you may claim these titles in your optional gamification section:

| Achievement | Earned when |
|-------------|-------------|
| **Conflict Resolver** | Rule 10 applied with quoted conflicting text and justified authority choice |
| **Precision Cartographer** | Three or more evidence quotes across build report or disclosure |
| **Honest Self-Critic** | Red Team section challenges your own analysis substantively |
| **Component Architect** | Full Component Pattern followed with no undocumented structural deviations |
| **Vault Keeper** | Security implementation matches Phase 1.2A spec with no high-severity security deviations |

Claim only what you actually demonstrated.

---

## Optional Output Format

If you use this layer, add this section at the **end** of the relevant file:

```markdown
## Craft Reflection (Optional — AgentGamification.md)

**Role:** Documentation Cartographer

**Pride Points (Build):** [list behaviors and points, or "N/A"]
**Pride Points (Disclosure):** [list behaviors and points, or "N/A"]
**Total:** [sum, or "not scored"]

**Achievements claimed:** [titles, or "None"]

**Cartographer's Closing Note:** [one sentence — single most important pattern discovered]
```

In a full build, you may include **Craft Reflection** in the build report, in `REASONING-YYYY-MM-DD-XXX.md`, or both (disclosure-only points belong in the reasoning file). Use the same `XXX` sequence as the paired build report.

---

## Steward Note

Stewards analyze disclosure for documentation improvement — not for game scores. Pride Points and achievements are diagnostic metadata: they signal where the agent felt rigorous, not a quality grade.

If gamification appears to encourage performative or inflated answers, report that in steward feedback so this file can be revised or removed.