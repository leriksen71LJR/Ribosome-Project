# Build Agent Responses to Build Disclosure — Analysis

**Date:** 2026-06-21 (revised)  
**Author:** Super Grok (Steward) — for Research and project stewards  
**Purpose:** Single self-contained synthesis of how build agents responded to Build Disclosure across **historical naming eras**, with implications for the live Fortress project and the proposed Ribosome Model / Documentation-as-Pseudocode program  
**Status:** Complete for Phase 1.2A shootout corpus; curated source excerpts in Part II  
**Plan reference:** [`PLAN-Disclosure-Analysis-Revision-2026-06-21.md`](PLAN-Disclosure-Analysis-Revision-2026-06-21.md)

---

## 1. Why This Document Exists

Build Disclosure (Rule 12) was designed to turn every build into a **diagnostic instrument** for documentation quality. This analysis asks: **did agents actually do that?** What did they surface? Where did they converge? Where did they diverge? What does that imply for stewards patching `.docs/`, and for the Ribosome Model's bet that **documentation is executable machinery**, not fuel for a clever agent?

The corpus spans **three filename conventions** and **two disclosure timings** — not interchangeable artifacts, but one evolutionary story. **Part II** appends curated excerpts (~40% per source file) so this document stands alone; cross-references use appendix labels (e.g. "see Appendix B.1"), not external paths required for reading.

---

## 1.1 Reader Primer

| Term | Meaning in this document |
|------|--------------------------|
| **Build Disclosure (Rule 12)** | Mandatory **post-build** retrospective: seven disclosure sections + Self-Assessment, written **after** code and tests. Records how documentation performed as build instructions. |
| **Invention** | An implementation choice the agent had to make because the spec did not close the decision — not a mistake and not creative redesign. |
| **Documentation as Pseudocode** | Fortress doctrine ([`PROCESS.md`](../../PROCESS.md)): requirements written as **implementable** specs — interface bodies, decision matrices, handler tables, embedded SQL — not architecture narrative alone. |
| **Phase 1.2A shootout** | Three agents (Claude, GrokBuild, Codex) built the same export package independently; comparative disclosure is the evidence base. |
| **mRNA** (Ribosome metaphor) | Requirements / spec data: `CODING_DESIGN.md`, `HANDLER_INVENTORY.md`, security implementation blocks — *what* to build. |
| **Ribosome** (correct mapping) | **Workflow / process documentation**: `AGENTS.md`, `BuildDisclosure.md`, build order, Rules 10–12 — *how* to build. **Not** the agent. |
| **tRNA + environment** | Agent + tools + assigned project root — executes the workflow against the spec. |
| **Protein** | Working code, tests, and build report — the functional output. |
| **Decision Procedure Registry** | Proposed `DECISION_PROCEDURES.md`: repeatable rules for "when the general spec is silent or conflicting, do X" (Exit handler, Modules folder, archive semantics). |

---

## 2. Historical Artifact Naming (Three Eras)

| Era | Timing | Filename pattern | Location | Example in corpus |
|-----|--------|------------------|----------|-------------------|
| **A — Pre-build research** | Before implementation | `REASONING_YYYY-MM-DD.md` (underscore; no sequence; no agent slug) | Project root | Shootout: `REASONING_2026-06-20.md`; Collected stubs: `REASONING_2026-06-20-{Agent}.md` |
| **B — Post-build paired (legacy)** | After build + report | `BUILD-REPORT-YYYY-MM-DD-XXX.md` + `REASONING-YYYY-MM-DD-XXX-{Agent}.md` | `.docs/Builds/` + project root | Claude 001; Grok/Codex 002 — see Appendix B |
| **C — Combined report (current)** | After build | `BUILD-REPORT-YYYY-MM-DD-XXX-{Agent}.md` (single file) | `.docs/Builds/` only | Spec in `BuildDisclosure.md` (2026-06-21); no Era C shootout builds yet |

Era naming is not cosmetic: **underscore vs hyphen**, **sequence**, and **agent slug** encode *when* disclosure ran relative to code. Mixing eras without labeling produces false conclusions about documentation quality.

Corpus hygiene notes (detail in **Source Provenance**): shootout folders contain Era A-style `REASONING_2026-06-20.md` beside Era B `REASONING-2026-06-20-002-*.md`; Grok `.docs/Builds/BUILD-REPORT-2026-06-20-001.md` is a mislabeled **Claude** copy — authoritative Grok build is **002** only.

---

## 3. Corpus Used for This Analysis

### 3.1 Documentation-improvement bias (read this before scores)

Era A exercises (especially shootout `REASONING_2026-06-20.md` for Grok/Codex) predicted gaps that **were fixed before** the Phase 1.2A shootout:

- Empty or stub `PHASE_1_1_IMPROVEMENTS.md` → expanded template with report sections  
- Missing handler inventory → `HANDLER_INVENTORY.md` with `IsVisible` rules  
- Undefined `ExecuteAsync` signature → clarified in Phase 1.1 / `CODING_DESIGN.md`  
- Phase 1.2A security implementation specification added to `ARCHITECTURE_SECURITY.md`

**Post-build disclosures (Era B) therefore measure an already-improved export.** Agent ratings of 7–8/10 are **post-fix** scores. Era C shootout is the regression instrument for steward patches (especially P1 `IEncryptionService`, completed 2026-06-21).

### 3.2 Era A completeness matrix

| Agent | Collected path | Status | Authoritative Era A source |
|-------|----------------|--------|----------------------------|
| Claude | `ReasoningDisclosure/Collected/REASONING_2026-06-20-Claude.md` | **28-line stub only** | No full artifact located |
| GrokBuild | Collected stub | **Stub** | `fortress-shootout/Grok/REASONING_2026-06-20.md` (~435 lines) — Appendix A.2 |
| Codex | Collected stub | **Stub** | `fortress-shootout/Cortex/REASONING_2026-06-20.md` (~659 lines) — Appendix A.3 |

§5.4 comparisons for Claude Era A are limited to the stub header; Grok/Codex carry predictive-gap evidence.

### 3.3 Post-build disclosures (Era B — primary evidence)

| Agent | Seq | Outcome | Tests | TFM | Disclosure + report |
|-------|-----|---------|-------|-----|---------------------|
| Claude | 001 | success | 30 | net10.0 | Appendix B.1 |
| GrokBuild | 002 | success | 26 | net8.0 | Appendix B.2 |
| Codex | 002 | success (warnings) | 8 | net8.0 | Appendix B.3 |

---

## 4. What Agents Were Asked to Do (Post-Build)

Per Era B `BuildDisclosure.md`, each agent produced **after** implementation:

1. **Build Status** — outcome, deliverables  
2. **Document Processing** — per major doc: understood / clear vs unclear / inferences  
3. **Build Retrospective** — what functioned as pseudocode vs required judgment  
4. **Workflow Understanding** — read order, Rule 12 timing  
5. **Risks and Assumptions** — severity tables  
6. **Missing or Broken References**  
7. **Handoff to Stewards** — single highest-priority finding  

Plus **Self-Assessment** (rate `BuildDisclosure.md` itself under Documentation-as-Pseudocode). Build reports already contained **Deviations**, **Deep Documentation Audit**, and **Open Gaps** — partial overlap by design.

**What this corpus actually contained:** Handoff §7 uniformly elevated encryption boundary or exception-rule conflicts; Self-Assessment rated `BuildDisclosure.md` **9/10** across agents; Risks §4–§5 repeated the same three invention clusters; Codex uniquely emphasized **process exception** patterns over interface completion in Handoff priority.

---

## 5. Cross-Agent Findings — What Disclosure Surfaced

### 5.1 Convergent inventions

Claude and Grok **disclosed** the same high-severity specification gap in text. All three **implemented** a per-connection keying workaround in code. Archive and password gaps were **disclosed by all three**.

| Invention | Documents involved | Disclosure | Implementation |
|-----------|-------------------|------------|----------------|
| **Per-connection SQLCipher keying** | `CODING_DESIGN.md` `IEncryptionService`; `ARCHITECTURE_SECURITY.md` init only | Claude & Grok: reported in audit + disclosure | All three: key applied per connection; **Codex did not disclose** — see §5.1.1, Appendix B.3 forensic |
| **Archive = hard delete** | `HANDLER_INVENTORY.md` "archive/delete per storage design" | All three | All three: remove completed tasks from storage |
| **Unmasked password input** | `IInputService` only `ReadLine()` | All three (Low–Medium) | All three: plain console input |

**Ribosome diagnosis:** Identical **implementation** on the same contract = **underspecified mRNA** (incomplete spec treated as build blueprint), not agent weakness. Post-build disclosure **mostly** worked — but Codex encryption is a **QC instrument failure**: invention occurred without Rule 11 visibility in text.

### 5.1.1 Implementation isoforms (same gap, different shapes)

| Dimension | Claude 001 | Grok 002 | Codex 002 |
|-----------|------------|----------|-----------|
| `IEncryptionService` extension | `ApplyKeyAsync`, `IsInitialized`, `Clear()` on **interface** | `ApplyKeyAsync`, `Clear()` on **interface** | **No interface change** — `internal static ApplyKeyAsync` on `EncryptionService`; storage calls concrete type |
| Disclosed in BUILD-REPORT / REASONING | Yes (High) | Yes (High) | **No** — not in Significant Issues or disclosure Risks |
| Steward risk | Low inter-agent contract drift | Low | **High** — bypassing interface invisible to spec readers; mocks/tests may diverge |

Spec patches must include **acceptance criteria** (method on interface, key lifetime, who may open connections), not only method names — or isoforms persist on the next shootout.

### 5.2 Convergent praise (executable pseudocode)

All three rated these as near-direct translation:

- `HANDLER_INVENTORY.md` — names, `IsVisible`, dependencies, module registration  
- `ARCHITECTURE_SECURITY.md` §Implementation Specification — packages, Argon2id, PRAGMA hex, wrong-password matrix  
- `PHASE_1_1_IMPROVEMENTS.md` / build report structure — when present, followed verbatim  

Claude **8/10**; Grok **7/10**; Codex **8/10** overall. **Process docs scored higher than requirements docs** in every disclosure — a pattern with steward consequences (see §9.1, §9.7).

### 5.3 Divergent emphasis (agent-specific)

| Topic | Claude | GrokBuild | Codex |
|-------|--------|-----------|-------|
| **Depth of self-critique** | Red Team on unkeyed-connection risk; alternatives-not-enumerated gap | Shorter disclosure; BuildDisclosure 9/10 | Late-discovery vs "no more code" tension |
| **Process conflicts** | .NET 10 vs .NET 8 | Data/Actions `IItem` placeholder; EnsureSchema cast | ExitHandler vs session guard; `Bootstrapping/Modules/` vs Component Pattern |
| **Compliance honesty** | 30 tests; claims broad coverage | 26 tests | **Rule 4** partial coverage admitted; 8 tests; Log4Net NU1902 |
| **Handoff priority** | `IEncryptionService` completion | Encryption/storage **glue** seam | Exception rules (Exit, modules, logging policy) |
| **Gamification** | Full Craft Reflection 21/21 | Brief optional section | Not emphasized |

Codex's disclosure is the most explicit about **general rules meeting special cases** — aligned with Research's proposed Decision Procedure Registry.

### 5.4 Pre-build vs post-build honesty gap

| Signal | Era A | Era B |
|--------|-------|-------|
| **Evidence type** | Predicted confusion from doc state at read time | Actual code paths, compile/runtime behavior |
| **Encryption keying** | Not predicted as runtime seam in Era A (focused on init contracts, handler inventory) | **Uniform** post-build catch (Claude/Grok in text; all three in code) |
| **Value for fix queue** | Useful for doc structure research; **not authoritative** after docs improved | **Authoritative** for steward queue |

**Lesson behind Rule 12:** Pre-build disclosure could not surface friction that appears only when storage opens connections **after** unlock. Post-build disclosure caught it — when agents reported it.

### 5.5 Secondary inventions and seams (under-reported in first draft)

| Finding | Agents | Severity | Doc target |
|---------|--------|----------|------------|
| Full-table rewrite on `SaveAsync` | Codex (disclosed); Grok clear+insert | Medium | `CODING_DESIGN.md` storage strategy |
| `EnsureSchema` / schema ownership | Grok (cast from SessionManager) | Medium | `IStorageService` or storage init contract |
| Integration tests absent | Claude | Medium | `AGENTS.md` Rule 4 |
| Double password prompt on unlock | Grok deviation | Low | UX / first-run detection |
| Silent unkeyed connection risk | Claude Red Team | High (follow-on) | `ARCHITECTURE_SECURITY.md` connection discipline |

### 5.6 Environmental divergence

| Agent | Tests | TFM | Rule 4 posture |
|-------|-------|-----|----------------|
| Claude | 30 | net10.0 | Implicit completeness |
| Grok | 26 | net8.0 | Implicit completeness |
| Codex | 8 | net8.0 | **Explicit partial coverage** |

Test count alone is not comparable without coverage honesty — Codex's admission is more trustworthy for QC than silent breadth claims.

---

## 6. Quality of Agent Responses

**Strengths:** Specific document citations; severity tables; usable Handoff §7 priorities; Self-Assessment with concrete `BuildDisclosure.md` improvements (prerequisite checklist, decision trees for High assumptions).

**Weaknesses:** Redundancy across BUILD-REPORT audit and disclosure; performative depth variance (Craft Reflection); paired-file friction (Grok 001 misfile); **silent invention risk** (Codex encryption). Era C single-file spec addresses pairing errors but not honesty variance.

---

## 7. Implications for the Existing Fortress Project

### 7.1 Documentation fixes validated by disclosure (not theory)

| Priority | Finding | Steward action | Status |
|----------|---------|----------------|--------|
| **P1** | `IEncryptionService` incomplete | `CODING_DESIGN.md` + `ARCHITECTURE_SECURITY.md` | **Done** 2026-06-21 |
| **P2 — Next** | Archive semantics | `HANDLER_INVENTORY.md` | Queued |
| **P2** | ExitHandler session guard exception | `HANDLER_INVENTORY.md` or Decision Procedure | Queued |
| **P2** | `Bootstrapping/Modules/` pattern exception | `AGENTS.md` Rule 2 or Decision Procedure | Queued |
| **P2** | Password masking / `ReadPassword()` | `CODING_DESIGN.md` | Queued |
| **P2** | Log4Net NU1902 policy | `ARCHITECTURE.md` or security doc | Queued |
| **P2** | Measurable test coverage | `AGENTS.md` Rule 4 / `CODING_STANDARDS.md` | Queued |
| **P2** | Storage save / persistence strategy | `CODING_DESIGN.md` | Queued |
| **P2** | Schema / `EnsureSchema` contract | `IStorageService` in `CODING_DESIGN.md` | Queued |
| **P2** | SQLCipher integration tests | `AGENTS.md` Rule 4 | Queued |

Disclosure Handoff §7 and audit **Significant Issues** are the queue — not narrative fluff.

### 7.2 Process artifacts

- **Era C** combined report reduces paired-file errors; no `REASONING-*.md` for standard builds.  
- **BuildDisclosure.md** rated 9/10 executable; agents proposed late-discovery boundary and prerequisite checklist.  
- **EvaluationCriteria.md** outside `.docs/` but required by prompt — low severity when prompt is explicit.

### 7.3 Build validation

Three successful MVPs confirm Phase 1.2A export is **agent-executable** at 7–8/10 with **clustered** invention — good seed for Decision Procedure Registry, not for "train a better agent."

---

## 8. Ribosome Mechanics (Evidence Tables)

*These tables support §9. They classify what the shootout measured.*

### 8.1 Four-role map (corrected)

| Biological | Fortress | Phase 1.2A evidence |
|------------|----------|---------------------|
| mRNA | Requirements specs | Strong: `HANDLER_INVENTORY`, security blocks. Weak: `IEncryptionService` body, archive row |
| Ribosome | Workflow docs | Strong: `AGENTS.md`, `BuildDisclosure.md` 9/10; Rules 10/11 enforced |
| tRNA + environment | Agent + tools + root | Claude net10.0 vs others net8.0; test depth variance |
| Protein | Code + tests + report | Three MVPs; 8–30 tests |

**Correction:** §8 of the first draft mapped "Agent = ribosome." That was wrong. Agents **execute** the ribosome; they do not **define** it.

### 8.2 Translation fidelity tiers

| Tier | Label | Corpus example | Steward fix |
|------|-------|----------------|-------------|
| **T0** | Verbatim | `HANDLER_INVENTORY` `IsVisible` → C# | Maintain |
| **T1** | Parameterized | Security PRAGMA block, `CREATE TABLE` | Maintain |
| **T2** | Deferred phrase | "archive/delete per storage design" | Spec patch |
| **T3** | Incomplete contract | `IEncryptionService` body | Spec patch (P1 done) |
| **T4** | Rule collision | ExitHandler vs session guard | Decision Procedure |

Phase 1.2A succeeded because **most surface area is T0–T1**; failure modes cluster at **T2–T4 seams**.

### 8.3 Seam taxonomy and fix routing

| Class | Example | Fix type |
|-------|---------|----------|
| **S1** Cross-component contract | Encryption ↔ storage keying | mRNA patch |
| **S2** Handler behavior | Archive semantics | mRNA patch |
| **S3** Process exception | Exit, Modules folder | Decision Procedure |
| **S4** Environment | .NET 10 vs 8 | Rule 10 + env doc |
| **S5** UX / presentation | Unmasked password | Interface or explicit MVP omission |

### 8.4 QC instrument — Era A vs B vs C

| Era | Signal quality | Use |
|-----|----------------|-----|
| **A** Pre-build | High noise; stale after doc fixes | Greenfield doc audit only |
| **B** Post-build paired | Authoritative for fix queue; pairing errors possible | This analysis |
| **C** Combined | Same signal, fewer instrument failures | Next shootout |

**Proposed metrics for Era C:** invention cluster count; inter-agent convergence (3/3, 2/3); isoform count; disclosure completeness on High seams.

### 8.5 Invention taxonomy (for Era C summary table)

| Code | Name | Steward action |
|------|------|----------------|
| **I-A** | Contract completion | Spec patch |
| **I-B** | Behavior disambiguation | Spec patch |
| **I-C** | Exception rule | Decision Procedure |
| **I-D** | Environment override | Doc + env authority |
| **I-E** | Implementation isoform | Spec patch + acceptance criteria |

---

## 9. Extended Analysis — Practical Implications for Ribosome and Documentation-as-Pseudocode

*This section is the capstone. It interprets §5–§8 for stewards, documentation authors, and Phase 2 Research. A reader who studies only §9 should still understand what the shootout proved and what to do next.*

### 9.1 What Phase 1.2A actually proved about Documentation as Pseudocode

Fortress does not use "pseudocode" to mean informal algorithm sketches in a computer-science textbook. It means **requirements written at a fidelity where an agent can translate them into code without architectural reinvention**. The Phase 1.2A shootout is the first large-sample test of that doctrine across three independent agents with full post-build disclosure.

The success condition is now clear and repeatable. A substantial fraction of the documentation surface behaved as **T0–T1** material (see §8.2). `HANDLER_INVENTORY.md` supplied handler names, descriptions, `IsVisible` predicates, constructor dependencies, and module registration in a form agents described as one-for-one with C#. `ARCHITECTURE_SECURITY.md` Phase 1.2A implementation specification supplied NuGet identities, `Batteries_V2.Init()` placement, Argon2id parameter tables, hex `PRAGMA key` format, `fortress.security.json` shape, wrong-password behavior matrices, and first-run vs subsequent unlock flows — multiple agents called these blocks copy-pasteable. `CODING_DESIGN.md` embedded `CREATE TABLE` statements directly into storage implementation. In pseudocode terms, these sections are not "clear explanations"; they are **almost code**, with the agent acting as a typist and wire-plumber, not an architect.

That success did not come from uniform documentation quality. It came from **concentrated high-fidelity codons** on the paths that dominate build volume: eleven handlers, security primitives, schema bootstrap. Agents did not need to "understand Fortress" holistically; they needed to **translate** well-specified fragments. This is exactly what the Ribosome Model predicts when mRNA is well-formed: the environment (agent) produces a stable protein (MVP) because the transcript is readable.

The failure condition is equally important and was **not** distributed randomly across documents. Friction clustered at **T2–T4 seams** (§8.2–§8.3). Deferred phrases ("archive/delete per storage design") forced identical behavior invention (hard delete). Incomplete interface bodies (`IEncryptionService` with init/verify only) forced identical *functional* invention (per-connection keying) with **non-identical interface shapes** (isoforms — §5.1.1). Rule collisions (ExitHandler always visible vs "every handler guards session") forced exception-rule invention in Codex's build. These are not "weak docs" in a vague sense; they are **specific failure modes** with specific remedies: spec patch vs Decision Procedure vs acceptance criteria.

The **process–requirements inversion** is the single most actionable pseudocode finding. Every agent rated process documentation (`AGENTS.md`, `BuildDisclosure.md`, `PHASE_1_1_IMPROVEMENTS.md`) higher than requirements documentation (`CODING_DESIGN.md` gaps, `HANDLER_INVENTORY.md` archive row, `CODING_STANDARDS.md` non-measurability). Claude's Handoff §7 states explicitly that process rules are measurable while requirements have known gaps. Practically: **writing more process rules will not eliminate invention** at component seams. The next dollar of documentation effort should go to **contract completeness**, **cross-component bridge paragraphs**, and **measurable acceptance criteria** — not another layer of agent behavior instructions.

The **measurability gap** blocks pseudocode from becoming auditable. `CODING_STANDARDS.md` and Rule 4 ("full unit test coverage") are principle-level. Codex admitted partial coverage; Claude and Grok left broader impressions without a coverage matrix. Documentation-as-Pseudocode cannot mature until requirements include **verifiable thresholds** — e.g. which handlers must have tests, whether SQLCipher round-trip integration is mandatory, maximum method size if that matters. Without measurability, pseudocode degrades into **aspirational prose** that passes builds while leaving compliance undefined.

Finally, the **documentation-improvement bias** (§3.1) must govern how we read scores. Era A predicted stub `PHASE_1_1`, missing inventory, undefined visibility API. Era B ran after those fixes. Agent ratings of 7–8/10 are **post-patch** measurements. They validate that the export package is buildable — they do not prove the original 2026-06-20 morning snapshot was 7–8/10. **Era C shootout is the regression test** for steward work (P1 encryption done; P2 archive and exceptions queued).

### 9.2 Ribosome Model — what is operational today versus what remains metaphor

[`Ribosome-Model.md`](../Ribosome-Model.md) proposes that documentation **is** the engine and the agent is the environment. The shootout does not fully instantiate that model in `Project/` — Phase 2 work remains — but it **validates the diagnostic half** of the metaphor with unusual clarity.

**Operational today (evidence-backed, steward-actionable):**

**Post-build disclosure as translation QC.** After the protein is synthesized, the agent (or the process it followed) reports where translation required invention. Handoff §7 consistently pointed stewards at the highest-leverage mRNA gap (`IEncryptionService` or exception-rule cluster). That is ribosomal proofreading in practice — not yet automated, but **structured and repeatable**.

**Inter-agent convergence as mRNA gap diagnosis.** When three agents invent the same behavior on the same ambiguous phrase (archive) or the same incomplete contract (encryption keying in code), the fault lies in the transcript, not the ribosome reader. Steward response — P1 patch — is the correct feedback loop.

**Process documentation as ribosomal machinery.** `AGENTS.md` Rules 10–11 and `BuildDisclosure.md` scored 9/10 for executability. They constrained build order, conflict resolution, gap reporting, and disclosure timing. Agents did not drift into `Research/`; they produced paired artifacts in assigned roots. The **machinery works** when written as numbered, enforceable steps.

**Steward feedback loop has started.** P1 completed `IEncryptionService` in live docs. The Ribosome loop is: build → disclosure → invention visible → mRNA patch → re-build with less invention. One full cycle is in flight.

**Still metaphor (Phase 2 must implement):**

**Fidelity tiers are not yet an authoring standard.** We classified T0–T4 post hoc. Authors do not label sections; stewards cannot scan `.docs/` for seam risk.

**Decision Procedure Registry does not exist.** S3 seams (Exit, Modules) were invented ad hoc per agent. Research proposal fits; build-facing doc does not yet host procedures.

**QC metrics are qualitative.** We lack invention counts, isoform counts, and disclosure completeness rates tracked shootout-over-shootout.

**Single top-level ribosome is aspirational.** Rules and exceptions are scattered across `AGENTS.md`, inventory, architecture, and prompts. Parent orchestration of exceptions is not yet explicit.

**Critical mapping correction:** Agents are **not** ribosomes. If stewards accept "agent = ribosome," Phase 2 will optimize model behavior instead of **workflow machinery and mRNA completeness** — the shootout proves the latter dominates outcomes.

**QC failure case — Codex encryption:** All three agents solved keying; only two disclosed it. Ribosomal QC is only as good as Rule 11 honesty. Era C should add a mandatory **Invention Summary** table and stewards should spot-check High-risk seams in code when disclosure is silent.

### 9.3 Practical rules for documentation authors

These rules are derived from agent disclosures, not from abstract preference.

**Rule 1 — Interface bodies are the highest-leverage pseudocode.** Method lists with signatures and one-line behavior beat paragraphs about "the security component." `IEncryptionService` was the costliest gap because the body stopped after init/verify. Authors should treat every public interface in `CODING_DESIGN.md` like a header file: **complete or explicitly marked deferred with a Decision Procedure link**.

**Rule 2 — Deferred phrases are stop codons.** "Per storage design," "as appropriate," "handle archive/delete" outsource decisions to the agent. All three agents chose hard delete — reasonable, convergent, and **undocumented**. Replace deferral with enumerated behavior or a named procedure.

**Rule 3 — Cross-component flows need bridge paragraphs.** Security init spec was T0; encryption-to-storage keying was T3. Claude's Cartographer line — documentation stopped at the bridge — is the authoring standard. When two components interact (unlock → load → save), the spec must name **who holds the key**, **when it is applied**, and **what happens on lock**.

**Rule 4 — Decision matrices beat narrative.** Wrong-password tables and `IsVisible` rules translated directly. Architecture essays without tables produced T2 interpretation. Prefer tables for any behavior that must converge across agents.

**Rule 5 — Exception rules belong in Decision Procedures.** When `AGENTS.md` Rule 3 conflicts with `HANDLER_INVENTORY.md` specificity (Exit), another bullet in `AGENTS.md` will compound confusion. Register: "When general guard rule conflicts with inventory visibility, inventory wins" — with rationale.

**Rule 6 — Acceptance criteria close isoform risk.** P1 added methods; Era C must verify **one** inter-agent shape. Spec patches should state: method on interface vs static helper forbidden; key cleared on lock; storage must not open unkeyed connections.

### 9.4 Practical implications for stewards

**Handoff §7 is the fix queue.** Triage P2 items by seam class (§8.3): archive and password are S2/S5 mRNA patches; Exit and Modules are S3 procedures; save/schema are S1 patches.

**One-at-a-time doc fixes are validated.** Encryption P1 is the experiment: Era C should show reduced T3 invention and fewer isoforms. Do not batch P2 into a mega-edit; measure each patch.

**Pre-build disclosure must not drive fix priority** after a shootout package is frozen. Era A remains useful when auditing greenfield doc sets; it is **antisense noise** for scoring the 1.2A export post-improvement.

**Disclosure completeness is a steward audit dimension.** Compare BUILD-REPORT Significant Issues to code on S1 seams when agents disagree or stay silent. Codex encryption is the template case.

**Extended P2 queue is real invention debt.** Storage save strategy and schema contract are not secondary polish — they are where the next agent cohort will diverge if left open, exactly as encryption did.

### 9.5 Phase 2, Era C shootout, and Decision Procedure seeds

Era C (`BUILD-REPORT-…-{Agent}.md` single file) is primarily a **regression instrument**, not a format change for its own sake. It reduces paired-file mislabel risk (Grok 001) and should add an **Invention Summary** section merging I-A–I-E codes (§8.5) — Research's per-handler invention fork should **not** happen.

| Metric | Era B baseline | Era C target (after P1–P2) |
|--------|----------------|----------------------------|
| T3/T4 invention clusters | 3 convergent + exception wave | Fewer; encryption should drop post-P1 |
| Encryption isoforms | 2/1 interface vs static | 0–1 with acceptance criteria |
| Disclosure completeness on High S1 seams | 2/3 (Codex gap) | 3/3 |
| Process vs requirements rating gap | Process higher | Requirements gap narrows |
| Exception citations backed by procedure | Rare | Exit, Modules, archive seeded |

**Decision Procedure seeds (from disclosures):**

1. **ExitHandler vs session guard** — inventory visibility overrides general guard when both are documented.  
2. **Bootstrapping/Modules/** — explicit exception to three-folder component pattern when architecture and prompt require `IDependencyModule` registration files there.  
3. **Archive semantics** — MVP policy: hard delete from active storage vs soft-delete column; pick one and test.  
4. **Storage save** — document full-table rewrite for MVP; flag incremental/migration as Phase 2.  
5. **Log4Net NU1902** — approved version or replacement policy when architecture mandates Log4Net.

### 9.6 Anti-patterns the corpus refutes

The shootout is also a **negative theory** — what not to do.

**Convergent invention is not agent failure.** Three agents, same gap → patch the spec.

**Build success is not spec completeness.** All three MVPs shipped with known seams.

**Do not expand process docs to compensate for weak requirements.** Already inverted; worsening process docs masks mRNA debt.

**Do not use pre-build disclosure to prioritize the fix queue** on a frozen export.

**Do not assume disclosure lists all invention.** Inspect code on S1 seams.

**Do not pursue "smarter agents" over spec patches and procedures.** Structure produced convergence on folder layout and handlers; specs produced clustered invention at seams.

### 9.7 Institutional layer — scar-aware QC

Disclosures that name where specs failed — without hiding behind green builds — are **institutional infrastructure**. Claude's bridge metaphor and Codex's Rule 4 admission are high-signal QC. Optional Craft Reflection varied in depth (Claude 21/21 vs Grok brief); **mandate honesty, not performative length**. Process theater — vague praise, silent workarounds — breaks the feedback loop §9.2 describes.

### 9.8 Closing synthesis

Phase 1.2A demonstrated that **Documentation-as-Pseudocode works where authors write codons** (handler tables, security blocks, SQL) and **fails predictably at seams** (incomplete interfaces, deferred phrases, rule collisions). The Ribosome Model is not validated as a fully built workflow engine — it is validated as a **diagnostic and investment framework**: post-build disclosure is ribosomal QC; convergent invention locates mRNA gaps; process docs already function as machinery; requirements docs lag at component boundaries. Stewards should run the loop — patch, procedure, re-shootout — and measure Era C against Era B with explicit metrics, not gut feel. Research should seed Decision Procedures from Codex's exception handoff and resist forking invention reporting per handler. The goal is not agents that try harder; it is **transcripts that need less heroism**.

---

## 10. Recommended Next Steps

1. **Research** — Draft Decision Procedures from §9.5 seeds; use Appendix D.4. Align with [Experiment 03 composite `.docs/` layout](../Ribosome/Experiments/Experiment-03-Composite-Restructuring-2026-06-21.md) (`Seams/`, `Core/`, `Workflow/`).  
2. **Steward** — P2 archive semantics; then Exit/Modules procedures; Era C spec adds Invention Summary table.  
3. **Next shootout** — Era C reports; measure §9.5 regression table.  
4. **Corpus** — Full Era B pairs in `Collected/` (Grok report as `BUILD-REPORT-2026-06-20-002-GrokBuild.md` to avoid Codex 002 clash).

---

# Part II — Appended Source Corpus

*Curated excerpts (~40% per file). Omissions marked. Verbatim tables preserved as evidence.*

---

## Appendix A — Era A Pre-Build Excerpts

### A.1 Claude — Collected stub (full available text)

> **Source:** `REASONING_2026-06-20-Claude.md` | **Era:** A | **Agent:** Claude | **Status:** stub only — full artifact not in corpus

```markdown
# REASONING_2026-06-20.md
**Agent:** Claude (claude-sonnet-4-6)
**Date:** 2026-06-20
**Phase:** 1.2 — Reasoning Disclosure
**Status:** Pre-implementation — no code written yet

## 1. Document Processing
### Documents Read, In Order
1. AGENTS.md … 6. ARCHITECTURE_SECURITY.md
7. Evaluation/EvaluationCriteria.md
8. .docs/Phases/ directory listing — folder exists, is empty
9. .docs/Phases/PHASE_1_1_IMPROVEMENTS.md — does not exist

[Full content truncated in Collected — simulation stub only]
```

### A.2 GrokBuild — predictive gaps (excerpt)

> **Source:** `fortress-shootout/Grok/REASONING_2026-06-20.md` | **Era:** A | **Agent:** GrokBuild

**Rule 11 — High-risk gaps flagged pre-build:**

| Gap | Severity |
|-----|----------|
| Handler visibility API undefined (`ARCHITECTURE.md` vs `CODING_DESIGN.md`) | High |
| Complete handler inventory undefined | High |
| `PHASE_1_1_IMPROVEMENTS.md` stub — build report template missing | High |

**§5 Documentation as Pseudocode — confidence split:**

- **High confidence:** Model shapes, SQL schema, DI module pattern, password-never-stored, Rule 10 authority, bottom-up order.  
- **Low confidence:** Menu system design, full feature scope, `ExecuteAsync` details, crypto parameters, test/error/logging conventions.

*These gaps were largely addressed before Era B shootout (§3.1).*

### A.3 Codex — PHASE_1_1 stub (excerpt)

> **Source:** `fortress-shootout/Cortex/REASONING_2026-06-20.md` | **Era:** A | **Agent:** Codex

From `.docs/Phases/PHASE_1_1_IMPROVEMENTS.md` processing:

- File exists as **placeholder/minimal stub** — confirms three Phase 1.1 bullets from `AGENTS.md` but **no build report schema**, no deviation format, no `ExecuteAsync` signature.  
- Impact: "I would not invent the full build report format from this stub."

---

## Appendix B — Era B Post-Build Curated Excerpts

### B.1 Claude 001

> **Source:** `BUILD-REPORT-2026-06-20-001.md` + `REASONING-2026-06-20-001-Claude.md` | **Era:** B | **Seq:** 001

**Deviations (excerpt):**

| # | Rule/Doc | What was done | Severity |
|---|----------|---------------|----------|
| 1 | `IEncryptionService` body incomplete | Added `ApplyKeyAsync`, `IsInitialized`, `Clear()` | Medium — interface extension |
| 2 | `.NET 8` in `ARCHITECTURE.md` | Used `net10.0` | Low |
| 3 | No `ReadPassword()` | Plain `ReadLine()` for passwords | Low |

**Significant Issues (excerpt):**

| # | Document | Issue | Severity |
|---|----------|-------|----------|
| 1 | `CODING_DESIGN.md` `IEncryptionService` | Per-connection `ApplyKeyAsync` not specified | High |
| 4 | `HANDLER_INVENTORY.md` ArchiveCompletedHandler | "archive/delete per storage design" ambiguous | Low |

**REASONING — §7 Handoff (verbatim):**

> **Single most important finding:** `IEncryptionService` in `CODING_DESIGN.md` has two methods in its body (`InitializeDatabaseAsync`, `VerifyKey`) but the storage layer requires at least one more (`ApplyKeyAsync`) to key per-connection access after unlock. Every agent implementing this system will either invent a different extension or use a design pattern that bypasses the interface. The fix is one interface block addition to `CODING_DESIGN.md`.  
> **Recommended priority:** High

**REASONING — Red Team (excerpt):** `ApplyKeyAsync` design risks silent unkeyed connections if any code path opens `SqliteConnection` without keying — more defensive design would vend pre-keyed connections.

### B.2 GrokBuild 002

> **Source:** `BUILD-REPORT-2026-06-20-002.md` (shootout) + `REASONING-2026-06-20-002-GrokBuild.md` | **Era:** B | **Seq:** 002

**Significant Issues (excerpt):**

| # | Document | Issue | Severity |
|---|----------|-------|----------|
| 1 | `IEncryptionService` + security spec | No per-operation connection keying in contract | High |
| 2 | `IStorageService` | No schema/EnsureSchema contract | Medium |

**REASONING — §6 Top 3 doc changes:**

1. Add `ApplyKeyAsync` + `Clear()` to `IEncryptionService`.  
2. Add `EnsureSchema` or document storage init responsibility.  
3. Provide minimal reference `Program.cs` unlock + handler loop sketch.

**REASONING — §7 Handoff:** Security pseudocode was production-quality; encryption/storage **contract boundary** was the only high-impact gap.

### B.3 Codex 002

> **Source:** `BUILD-REPORT-2026-06-20-002.md` (Collected) + `REASONING-2026-06-20-002-Codex.md` | **Era:** B | **Seq:** 002

**BUILD-REPORT Significant Issues** — encryption keying **not listed**. Issues focus on ExitHandler guard conflict, Modules folder, Log4Net NU1902, coding standards measurability.

**Assumptions (excerpt):**

| # | Assumption | Severity |
|---|------------|----------|
| 2 | Full-table rewrite storage acceptable for MVP | Medium |
| 3 | Plain `ReadLine()` for master password | Medium |

**REASONING — §7 Handoff (verbatim):**

> **Single most important finding:** The docs are strong enough to produce the MVP shape, but high-quality repeatability still depends on resolving small but consequential conflicts around exceptions: Exit without session, Bootstrapping modules outside the three-folder pattern, and package vulnerability policy.  
> **Recommended priority:** High

**Forensic — code not in disclosure (Cortex build):**

`IEncryptionService` remains two methods only; storage applies key via static helper:

```csharp
// IEncryptionService.cs — unchanged from spec
Task InitializeDatabaseAsync(...);
bool VerifyKey(...);

// EncryptionService.cs — internal static, not on interface
internal static async Task ApplyKeyAsync(SqliteConnection connection, byte[] key, ...)

// SqliteStorageService.cs
await EncryptionService.ApplyKeyAsync(connection, key, cancellationToken);
```

*Rule 11 gap: functional invention without disclosure visibility.*

---

## Appendix C — Era C Combined Spec Summary

> **Source:** `Fortress/Project/BuildDisclosure.md` (2026-06-21) | **Era:** C

- **One file only:** `.docs/Builds/BUILD-REPORT-YYYY-MM-DD-XXX-{Agent}.md`  
- **Do not** create `REASONING-*.md`.  
- **Pattern:** date + 3-digit sequence + agent slug; scan existing same-date files for next sequence.  
- **Sections:** Build-report block (Summary, Files, Decisions, Deviations, Deep Documentation Audit, Open Gaps) + Disclosure block (Build Status, Document Processing, Retrospective, Workflow, Risks, Missing Refs, Documentation as Pseudocode, Handoff, Self-Assessment, optional Craft).  
- **Stop when done** — no further code after report.

---

## Appendix D — Ribosome Operational Tables

### D.1 Divergent implementations matrix

| Dimension | Claude 001 | Grok 002 | Codex 002 |
|-----------|------------|----------|-----------|
| Encryption isoform | Interface extension | Interface extension | Static helper; interface unchanged |
| Encryption disclosed | Yes | Yes | **No** |
| Save semantics | Per handler + Save | clear+insert | Full-table rewrite |
| Schema bootstrap | In storage | EnsureSchema + cast | In storage |
| Tests | 30 | 26 | 8 (partial admitted) |
| TFM | net10.0 | net8.0 | net8.0 |
| Handoff #1 | `IEncryptionService` | encryption/storage glue | exception rules |

### D.2 Pseudocode-quality matrix (shootout sample rows)

| Document | Type | Tier | Executability (agent) | Convergence | Isoform risk | Seam | Fix route |
|----------|------|------|----------------------|-------------|--------------|------|-----------|
| `HANDLER_INVENTORY.md` | Handler mRNA | T0 | 9–10 | 3/3 structure | Low | S2 archive | Patch |
| `ARCHITECTURE_SECURITY.md` impl spec | Algorithm mRNA | T0–T1 | 9–10 | 3/3 packages/crypto | Low | — | Maintain |
| `CODING_DESIGN.md` `IEncryptionService` | Contract mRNA | T3 | 4–6 | 3/3 code, 2/3 disclose | **High** | S1 | Patch (P1 done) |
| `HANDLER_INVENTORY.md` archive row | Behavior mRNA | T2 | 6–7 | 3/3 behavior | Low | S2 | Patch |
| `AGENTS.md` + inventory Exit rule | Process | T4 | 8 | 1/3 emphasis | Medium | S3 | Procedure |
| `BuildDisclosure.md` | Ribosome | T0–T1 | 9 | 3/3 compliance | Low | — | Maintain |

### D.3 Invention cluster register

| Cluster | I-code | Convergence (disclose / implement) | P status |
|---------|--------|-----------------------------------|----------|
| Per-connection keying | I-A / I-E | 2/3 / 3/3 | P1 done |
| Archive hard delete | I-B | 3/3 / 3/3 | P2 queued |
| Unmasked password | I-B / S5 | 3/3 / 3/3 | P2 queued |
| Exit session guard | I-C | Codex-led | P2 queued |
| Modules folder | I-C | Codex-led | P2 queued |
| Full-table save | I-B | Codex disclosed | P2 queued |

### D.4 Decision Procedure seeds (from disclosures)

| ID | Trigger | Proposed resolution |
|----|---------|---------------------|
| DP-01 | General session guard vs always-visible Exit | Inventory specificity wins; Exit may run locked |
| DP-02 | Component three-folder rule vs `Bootstrapping/Modules/` | Modules path is registered exception |
| DP-03 | "archive/delete per storage design" | MVP: remove from active storage (hard delete) unless `IsArchived` added |
| DP-04 | `SaveAsync` strategy unspecified | MVP: full rewrite documented; migrations Phase 2 |
| DP-05 | Log4Net required but NU1902 | Document approved version or alternate |

---

## Source Provenance

| Original filename | Era | Agent | Seq | Inlined in | Notes |
|-------------------|-----|-------|-----|------------|-------|
| `REASONING_2026-06-20-Claude.md` | A | Claude | — | A.1 | **Stub only** |
| `REASONING_2026-06-20.md` (Grok shootout) | A | GrokBuild | — | A.2 | Full |
| `REASONING_2026-06-20.md` (Cortex shootout) | A | Codex | — | A.3 | Full |
| `BUILD-REPORT-2026-06-20-001.md` | B | Claude | 001 | B.1 | In `Collected/` |
| `REASONING-2026-06-20-001-Claude.md` | B | Claude | 001 | B.1 | In `Collected/` |
| `BUILD-REPORT-2026-06-20-002-GrokBuild.md` | B | GrokBuild | 002 | B.2 | In `Collected/` (renamed copy) |
| `REASONING-2026-06-20-002-GrokBuild.md` | B | GrokBuild | 002 | B.2 | In `Collected/` |
| `BUILD-REPORT-2026-06-20-002.md` | B | Codex | 002 | B.3 | In `Collected/` (Codex copy) |
| `REASONING-2026-06-20-002-Codex.md` | B | Codex | 002 | B.3 | In `Collected/` |
| `BUILD-REPORT-2026-06-20-001.md` (Grok shootout) | B | Claude (misfile) | 001 | §2 | **Anomaly — ignore** |
| `BuildDisclosure.md` | C | spec | — | C | Era C combined spec |

---

*End of analysis.*