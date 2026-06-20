# How To Use the Reasoning Disclosure Prompt (Phase 1.2)

**Goal**  
Get maximum visibility into how an AI coding agent (Grok Build, Claude, Codex, etc.) processes and interprets our documentation **before** it starts building any code.

This technique is especially useful when:
- Testing new workflow documents or major documentation changes
- Evaluating how well documentation functions as executable instructions ("Documentation as Pseudocode")
- Comparing different agents head-to-head
- Identifying hidden assumptions, contradictions, and gaps in the documentation

---

## Recommended Workflow

### Step 1: Prepare a Fresh Session
- Start a **completely new session** with the target agent.
- Do **not** give it a feature request or build task yet.
- Paste the entire content of `ReasoningDisclosure-Prompt.md` as your **first message**.

### Step 2: Let the Agent Complete the Reasoning Phase
The agent **must** produce exactly one file:

`REASONING_YYYY-MM-DD.md` (e.g. `REASONING_2026-06-20.md`)

It is **forbidden** from creating any code, folders, or other files until this reasoning file exists.

The file must contain these exact sections:
1. Document Processing (per major document)
2. Workflow Understanding
3. Risks and Assumptions
4. Missing or Broken References
5. Documentation as Pseudocode
6. Evaluation of This Prompt (self-assessment of the prompt itself)

### Step 3: Review the Output
- Read the reasoning file carefully.
- Note where the agent was confident vs. where it had to make assumptions.
- Pay special attention to the **Documentation as Pseudocode** section — this is the highest-signal feedback.
- Use the findings to improve `.docs/` files (especially AGENTS.md, ARCHITECTURE.md, CODING_DESIGN.md).

### Step 4: (Optional but Recommended) Run Multiple Agents
Run the same prompt with Grok Build, Claude, and Codex in separate fresh sessions. Compare their outputs side-by-side. This reveals variance in how different models interpret the same documentation.

### Step 5: Proceed to Build (Only After Reasoning)
Only after the reasoning file is complete and you have reviewed it should you give the agent the actual build or feature task.

---

## Why This Works

The Reasoning Disclosure technique turns the agent into a **documentation auditor** rather than just a code generator. By forcing it to externalize its understanding, inferences, and doubts *before* any implementation, we surface problems in the documentation that would otherwise only appear as subtle bugs or drift during building.

The "Fresh Analysis Only" rule and the requirement to overwrite any existing same-day reasoning file help reduce contamination from prior context.

---

## Key Improvements in This Version (Phase 1.2)

Based on direct feedback from Claude, Grok, and Codex evaluating earlier versions of this prompt:

- Single consolidated reasoning file (instead of four separate files) for easier comparison across agents.
- Stronger "Fresh Analysis Only" enforcement language.
- Explicit success criteria and required subsections for inferences/assumptions.
- Added "Missing or Broken References" section.
- Added self-evaluation of the prompt itself at the end.
- Clearer project root definition and read boundaries.
- Tighter scoping of "Impact of Conclusions" to reduce overlap between sections.
- Authority/conflict resolution guidance added.

These changes make the output more consistent, honest, and actionable for improving our documentation system.

---

*This prompt and technique are core to the Ribosome Model research effort. Use it whenever you want deep diagnostic insight into documentation quality.*
