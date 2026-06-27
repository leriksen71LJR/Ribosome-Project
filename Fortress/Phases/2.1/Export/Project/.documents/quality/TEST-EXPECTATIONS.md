# Test Expectations (Phase 2.1)

**Authority:** `process/AGENTS.md` Rule 4  
**Purpose:** Make test requirements verifiable — addresses Era B test-count variance and coverage measurability gap.

---

## Required test categories

| Category | Minimum | Notes |
|----------|---------|-------|
| Handler unit tests | One test class per handler (or justified grouping) | Mock `IConsole`, `IInputService`, `IStorageService` as injected |
| `EncryptionService` / key derivation | At least one test | Wrong key fails; correct key succeeds |
| `SqliteStorageService` | At least one test | Load/save with mocked or in-memory DB if SQLCipher test harness is impractical — **report deviation** |
| **SQLCipher round-trip** | **At least one integration-style test** | Unlock → write item → save → reload proves keyed connection path; see below |
| Session / lock | At least one test | `LockAsync` clears session; storage guarded when locked |

---

## SQLCipher round-trip (mandatory unless deviated)

Era B gap: encryption + persistence correctness could drift without detection.

**Minimum acceptable proof (pick one):**

1. Integration test: real SQLCipher DB file, unlock, insert row, new connection with `ApplyKeyAsync`, read row back; or
2. Unit tests with mocked `IEncryptionService` verifying `ApplyKeyAsync` called on every `OpenAsync` in storage — **plus** deviation note that full crypto round-trip was not exercised.

If neither is feasible, report under **Deviations** with impact **Medium** or **High**.

---

## Coverage checklist (audit in build report)

State **Yes / Partial / No** for each:

- [ ] All 11 handlers have at least one meaningful test
- [ ] Security key derivation or verify path tested
- [ ] Storage save/load path tested
- [ ] SQLCipher round-trip or documented deviation
- [ ] `ExitHandler` exception (no session guard) behavior conscious in tests or report

Optional: report line/branch % if tooling available — not required for MVP.

---

## Measurability

“Full unit test coverage” means **this checklist is complete or honestly deviated** — not a vague aspiration. Stewards use the checklist in build report §5 (Deep Documentation Audit).