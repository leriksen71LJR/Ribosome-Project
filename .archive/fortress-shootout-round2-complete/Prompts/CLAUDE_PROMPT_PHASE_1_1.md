You are about to build the complete Fortress project from documentation only.

**Single Source of Truth:**  
The `.docs/` folder + the root `AGENTS.md` and `README.md` files are the ONLY authoritative source.

**Required Reading Order:**
1. `AGENTS.md`
2. `README.md`
3. `.docs/ARCHITECTURE.md`
4. `.docs/PROJECT_OVERVIEW.md`
5. `.docs/CODING_STANDARDS.md`
6. `.docs/CODING_DESIGN.md`
7. `.docs/CODING_WORKFLOWS.md`
8. `.docs/Phases/PHASE_1_1_IMPROVEMENTS.md`

**Before writing any code, do the following:**

1. Confirm you have read all files in the required order above.

2. Present your understanding organized into **logical grouped sections** (do not give one long flat list).  
   Suggested sections:
   - Architecture & Component Pattern
   - Action Handling & User Flow
   - Dependency Injection & Bootstrapping
   - Coding Standards & Quality Rules
   - Phase 1.1 Requirements (self-documentation + deviation reporting)

Only after I approve your grouped understanding, begin building.

**Mandatory Phase 1.1 Requirements:**
- At the end of your work, create `.docs/Builds/` if needed.
- Save your full session as `BUILD-YYYY-MM-DD-Claude.md` inside `.docs/Builds/`.
- Explicitly document any deviations from the rules in a section called **"Deviations from Documentation"**.
- Use `ExecuteAsync` on `IActionHandler`.

**Goal:** Produce a complete, working Fortress console app that closely follows the documentation. Be honest about any deviations.
