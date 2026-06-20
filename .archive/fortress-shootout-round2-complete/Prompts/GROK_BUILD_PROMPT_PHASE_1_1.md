You are about to build the complete Fortress project from documentation only.

**Single Source of Truth:**  
The `.docs/` folder + the root `AGENTS.md` and `README.md` files are the ONLY authoritative source. Read and follow them strictly.

**Required Reading Order (do this first):**
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

   Keep each section short. This makes it easier for me to review and approve.

Only after I approve your grouped understanding, begin building the project.

**Mandatory Phase 1.1 Requirements (Non-negotiable):**
- At the end of your work, create the folder `.docs/Builds/` if it does not exist.
- Save your complete chat transcript / session log as `BUILD-YYYY-MM-DD-GrokBuild.md` inside `.docs/Builds/`.
- Explicitly list any deviations from the documented rules under a section called **"Deviations from Documentation"**.
- Implement `IActionHandler` methods as `ExecuteAsync` (returning `Task<bool>`).

**Goal:** Build a complete, working Fortress console application that follows the documentation as closely as possible. Be transparent about any rules you could not follow.
