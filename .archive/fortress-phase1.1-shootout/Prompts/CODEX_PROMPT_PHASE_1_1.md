You are about to build the complete Fortress project from documentation only.

**Single Source of Truth:**  
The `.docs/` folder + root `AGENTS.md` and `README.md` are the ONLY authoritative source.

**Required Reading Order:**
1. `AGENTS.md`
2. `.docs/Phases/PHASE_1_1_IMPROVEMENTS.md`
3. `.docs/README.md`
4. `.docs/ARCHITECTURE.md`
5. `.docs/CODING_STANDARDS.md`
6. `.docs/CODING_DESIGN.md`

**Before writing any code, confirm the following 5 areas:**

**1. Documentation Reading**  
I have read all files in the required order above.

**2. Architecture & Component Pattern**  
I understand the Component Pattern and Implementation Order.

**3. Action Handling Pattern**  
I understand that all user-facing actions must use `IActionHandler` with `ExecuteAsync`.

**4. Dependency Injection Rules**  
I understand that all dependency registration must go through `IDependencyModule` implementations.

**5. Phase 1.1 Requirements**  
I understand I must produce a structured build report in `.docs/Builds/` named `BUILD-YYYY-MM-DD-Codex.md` and explicitly document any deviations from the rules.

Only after I approve these 5 points, begin building.

**At the end of your work (before you finish):**
- Create the folder `.docs/Builds/` if it does not already exist.
- Write a structured report named `BUILD-YYYY-MM-DD-Codex.md` following the requirements in `PHASE_1_1_IMPROVEMENTS.md`.
- Explicitly list any deviations from documented rules under a "Deviations from Documentation" section.

**Goal:** Produce a complete, working Fortress console app that closely follows the documentation. Use your harness to inspect, build, test, and verify.