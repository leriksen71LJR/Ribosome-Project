You are about to build the complete Fortress project from documentation only.

**Single Source of Truth:**  
The `.docs/` folder + the root `AGENTS.md` and `README.md` files are the ONLY authoritative source. Read and follow them strictly.

**Output Location Rule (Mandatory):**  
All generated files and code **must** be written directly into the assigned project root folder.  
Writing to any git worktree, `.claude/worktrees/`, temporary harness folder, or any location other than the real project root is **strictly forbidden**. This is a process violation.

**Required Reading Order (do this first):**
1. `AGENTS.md`
2. `README.md`
3. `.docs/Phases/PHASE_1_1_IMPROVEMENTS.md`   ← New mandatory document
4. `.docs/ARCHITECTURE.md`
5. `.docs/PROJECT_OVERVIEW.md`
6. `.docs/CODING_STANDARDS.md`
7. `.docs/CODING_DESIGN.md`
8. `.docs/CODING_WORKFLOWS.md`

**Before writing any code, do the following:**

1. Confirm you have read all files in the required order above.

2. Present your understanding organized into **logical grouped sections** (do not give one long flat list).  
   Suggested sections (you can adjust the grouping if it makes more sense):
   - Architecture & Component Pattern
   - Action Handling & User Flow
   - Dependency Injection & Bootstrapping
   - Coding Standards & Quality Rules
   - Phase 1.1 Requirements (Self-documentation + Deviation Reporting)
   - Other Important Constraints or Observations

   Keep each section short (2–5 bullets or a short paragraph). This makes it easier for me to review and approve section by section or in batches.

Only after I approve your grouped understanding, begin building the project.

**At the end of your work (before you finish):**
- Create the folder `.docs/Builds/` if it does not already exist.
- Save your complete chat transcript / session log into that folder as `BUILD-YYYY-MM-DD-GrokBuild.md`.
- In the build report, include a clear section titled **"Deviations from Documentation"** listing any rules you could not follow, with explanation.
- This is mandatory for Phase 1.1 diagnostics.

**Goal:** Build a complete, working Fortress console application that follows the documentation as closely as possible. When finished, provide a clear summary of what was implemented and any assumptions or deviations you had to make.