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
   - Other Important Constraints or Observations

   Keep each section short (2–5 bullets or a short paragraph). This makes it easier for me to review and approve section by section or in batches.

Only after I approve your grouped understanding, begin building the project.

**At the end of your work (before you finish):**

You **must** create a structured build report:

- Create the folder `.docs/Builds/` if it does not already exist.
- Save a file named exactly in this format:  
  `BUILD-YYYY-MM-DD-GrokBuild.md` (use today's date)
- The report **must** contain these sections:
  1. **Summary of Understanding**
  2. **Key Implementation Decisions**
  3. **Deviations from Documentation** (be explicit — list every rule from `.docs/` you did not follow, with explanation)
  4. **Final Status** (`Success`, `Partial Success`, or `Blocked`)
  5. **Notable Gaps or Follow-up Items**

This report is mandatory for Phase 1.1 diagnostics.

**Goal:** Build a complete, working Fortress console application that follows the documentation as closely as possible. When finished, provide a clear summary of what was implemented and any assumptions or deviations you had to make.
