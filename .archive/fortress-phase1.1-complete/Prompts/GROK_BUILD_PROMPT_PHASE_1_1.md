You are about to build the complete Fortress project from documentation only.

**Single Source of Truth:**  
The `.docs/` folder + the root `AGENTS.md` and `README.md` files are the ONLY authoritative source. Read and follow them strictly.

**Required Reading Order (do this first):**
1. `AGENTS.md`
2. `README.md`
3. `.docs/Phases/PHASE_1_1_IMPROVEMENTS.md`
4. `.docs/ARCHITECTURE.md`
5. `.docs/CODING_STANDARDS.md`
6. `.docs/CODING_DESIGN.md`

**Before writing any code, confirm the following:**

**1. Documentation Reading**  
I have read all files in the required order above.

**2. Architecture & Component Pattern**  
I understand the Component Pattern (`Components/[Name]/{Contracts/, Implementations/, Model/}`) and the expected high-level folder structure.

**3. Action Handling Pattern**  
I understand that all user-facing actions must use the `IActionHandler` + Strategy-by-List pattern, and that `Execute` must be made async (`ExecuteAsync`).

**4. Dependency Injection Rules**  
I understand that all dependency registration must go through `IDependencyModule` implementations.

**5. Phase 1.1 Requirements**  
I understand that I must:
- Create a build report in `.docs/Builds/` at the end of this work
- Explicitly document any deviations from the documented rules

Only after I approve these 5 points, begin building the project.

**At the end of your work (before you finish):**
- Create the folder `.docs/Builds/` if it does not already exist.
- Save your complete chat transcript / session log into that folder using the naming convention: `BUILD-YYYY-MM-DD-GrokBuild.md`
- Include a section titled **"Deviations from Documentation"** listing any rules you could not follow and why.

**Goal:** Build a complete, working Fortress console application that follows the documentation as closely as possible. When finished, provide a clear summary of what was implemented and any assumptions or deviations you had to make.