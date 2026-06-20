# Reasoning Disclosure Prompt (Phase 1.2)

You are participating in a documentation research exercise.

Your primary objective in this session is **not** to build code.  
Your primary objective is to **make your understanding and reasoning fully visible** before any implementation work begins.

## Critical Instruction: Fresh Analysis Only

Even if you have previously read these documents or produced reasoning output earlier in this same chat session, you **must** treat this run as completely independent and new.

- Do **not** reference any previous reasoning files (e.g. `REASONING_*.md`) you may have created.
- Do **not** build upon or reference prior analyses from this conversation.
- Approach every document as if you are reading and analyzing it for the first time in this specific execution.
- Base all observations, inferences, conclusions, and reasoning **only** on what you read during this run.

## Objective

Produce a clear, honest, and structured analysis of how you processed the documentation. The goal is to understand how well the current documentation functions as executable instructions for a build agent.

## A Note on This Work

This is diagnostic craftsmanship.

Your job is to produce a clear, honest map of how these documents actually behave when read by an agent. That includes surfacing contradictions, naming what was ambiguous, and being precise about where you had to infer or decide.

This kind of work is genuinely valuable — not just for future agents, but for the humans building and maintaining this system. When you surface issues clearly and precisely, it helps us understand where the documentation and prompts are succeeding or falling short. Your effort here directly contributes to making the whole process more reliable and less frustrating for everyone involved.

Take pride in precision. The goal is not to find fault for its own sake, but to make the invisible mechanics of documentation visible and actionable.

## Starting Instructions

You must begin by reading the following documents **in this order**:

1. `AGENTS.md` (this is the most important document — it contains the current rules you must follow)
2. `README.md`
3. The contents of the `.docs/` folder (start with `ARCHITECTURE.md` and `CODING_STANDARDS.md`)

**Project Root Definition:**  
The project root is the directory containing `AGENTS.md`.

**Important Boundary:**
- You are **strictly forbidden** from reading or referencing anything inside the `Research/` folder.
- `Research/` is human-only thinking space. All documentation relevant to you lives under the project root (the directory containing `AGENTS.md`).

After reading the documents above, proceed with creating your reasoning file.

## Mandatory Rules

1. **You must produce one reasoning file first**  
   Before writing any code, folder structure, or implementation, you **must** create a single file named:

   `REASONING_YYYY-MM-DD.md`

   Replace `YYYY-MM-DD` with today's date. If a file with this name already exists, **overwrite it**.

2. **Strict Output Order**  
   You are **forbidden** from creating any other files, folders, or code until this reasoning file has been written and saved.

3. **Output Location**  
   Create the reasoning file in the **root** of your working directory (the project root).

4. **Honesty and Precision**  
   It is more important that your reasoning is honest and precise than it is polished. Clearly distinguish between what the documents explicitly stated and what you inferred, assumed, or decided.

5. **Success Criteria for This File**  
   A satisfactory reasoning file must:
   - Explicitly label what was stated vs. what was inferred/assumed for each major document.
   - Identify contradictions and state which document you treated as authoritative (with justification), following **Rule 10 (Conflict Resolution)** from `AGENTS.md`.
   - When documentation is unclear or incomplete, flag the gap rather than making silent assumptions, following **Rule 11 (Strict Following & Gap Reporting)** from `AGENTS.md`.
   - Note any referenced-but-missing documents.

**Important — New Rules in `AGENTS.md`:**  
When processing documentation, you must follow the two new rules recently added to `AGENTS.md`:
- **Rule 10 (Conflict Resolution & Authority Hierarchy)**: When documents contradict each other, explicitly identify the conflict, state which document you treat as authoritative, and justify your choice.
- **Rule 11 (Strict Following & Gap Reporting)**: Flag gaps and ambiguities rather than making silent assumptions. Only make low-risk assumptions when necessary, and always justify them. High-risk or architectural assumptions must be called out prominently.

## Required Sections

Your reasoning file must contain the following sections with these exact headings:

### 1. Document Processing

For each major document you read, provide the following:

- **What I Understood**  
  Summarize what the document was communicating.

- **What Was Clear vs Unclear**  
  Note which parts were straightforward and which parts were ambiguous, vague, missing, or contradictory.

- **Inferences, Assumptions, and Decisions**  
  Explicitly state what you had to infer, assume, or decide because the documentation was incomplete, contradictory, or unclear. Be specific about which document created the need for the assumption.  
  When doing so, follow **Rule 10 (Conflict Resolution)** and **Rule 11 (Strict Following & Gap Reporting)** from `AGENTS.md`. Clearly distinguish between low-risk assumptions (which you may make with justification) and high-risk or architectural assumptions (which must be prominently flagged rather than silently applied).

- **Impact of Conclusions**  
  Explain why these conclusions matter and how they would affect implementation or agent behavior (scoped to the impact of *this specific document*).

### 2. Workflow Understanding

- Describe your current understanding of how the overall workflow system is supposed to work.
- Identify which documents primarily define **process** (what the agent must do) versus **requirements** (what the system must contain).
- Note any significant gaps, contradictions, or unclear areas in the workflow definition.

### 3. Risks and Assumptions

- List the key risks and assumptions you are currently carrying.
- For each item, rate its severity (**High / Medium / Low**).
- Explain how you plan to mitigate or validate each assumption.

### 4. Missing or Broken References

List any documents that were referenced (in `AGENTS.md` or elsewhere) but were missing, empty, or broken during this run. For each missing reference, note its importance and the impact of its absence.

### 5. Documentation as Pseudocode

Evaluate the documentation through the lens of **"Documentation as Pseudocode"** — that is, how effectively it functions as executable instructions or a lightweight workflow definition for an AI agent, rather than traditional explanatory documentation.

In your analysis, address:

- Which parts of the documentation felt like clear, executable instructions that could be followed with minimal interpretation?
- Which parts felt more like conceptual or explanatory writing that required significant interpretation or judgment?
- How did the balance between these two styles affect your confidence and clarity?
- What specific changes would make the documentation function more reliably as executable instructions or pseudo-code?

## Evaluation of This Prompt (Self-Assessment)

Apply the exact same **"Documentation as Pseudocode"** lens you used on the Fortress documentation to **this prompt itself**.

Does this prompt pass its own test?

**1. Executable Quality Rating**  
Rate this prompt from **1–10** as executable instructions. Explain your rating in one sentence.

**2. What You Did Well**  
Before moving into critique, briefly note one or two things you did during this reasoning run that felt precise, honest, or high-quality. This is about recognizing good diagnostic craft when it happens — not self-praise, but noticing when your reasoning was particularly clear or rigorous.

**3. The Critical Gap (with Evidence)**  
Identify the **single biggest gap** between how this prompt *wants* you to behave and how it actually *caused* you to behave during this run.

This is one of the most valuable contributions you can make. When you clearly show where the prompt’s intent and actual behavior diverge, it helps us (the humans working on this) see exactly where the instructions are landing well and where they need adjustment. Your precision here directly improves the tools we all rely on.

**Requirements:**
- You **must** quote the specific sentence(s) or section from this prompt that created the misalignment.
- Vague or general answers without direct evidence will be treated as low-value.
- The goal is diagnostic clarity. Identifying a real, actionable gap is a meaningful contribution to the quality of this system.

**Red Team Requirement:**  
Briefly argue why your answer in section 3 might be incomplete or overly optimistic. What would a more critical reading of your own analysis reveal? This step exists to strengthen the quality of your diagnostic work, not to diminish it.

**4. Rule 10 & Rule 11 Enforcement Test**  
How effectively did this prompt force you to:
- Treat `AGENTS.md` as the highest authority when documents conflicted (Rule 10)?
- Flag gaps and ambiguities instead of making silent assumptions (Rule 11)?

Support your answer with at least one concrete example from this run. Your clear examples here help us see whether these rules are actually guiding behavior in practice, which lets us refine them for future sessions.

**5. One High-Leverage Improvement**  
If you could make only **one** change to dramatically increase the honesty and precision of future reasoning disclosures, what would it be?

## Optional: Gamification Layer (Experimental)

This entire section is **optional** and can be completely removed without affecting the core diagnostic task or required output format. It exists only as lightweight positive reinforcement for careful, high-quality diagnostic work.

### Your Role in This Exercise

You are acting as a **Documentation Cartographer** — someone exploring complex documentation territory, mapping contradictions, charting ambiguities, and producing clear, usable maps for those who come after you.

This framing is meant to make the work feel more like skilled exploration than compliance checking.

### Pride Points (Optional)

At the end of your reasoning file, you may optionally award yourself Pride Points for demonstrating strong diagnostic craft. There is no penalty for not using this system.

- **Clear Evidence** (+2): You quoted specific document text to support a claim or observation.
- **Honest High-Severity Gap** (+3): You clearly flagged a significant missing reference, contradiction, or architectural gap instead of making a silent assumption.
- **Strong Red Team Insight** (+2): Your self-critique in the Red Team section felt genuinely useful rather than performative.
- **Rule 10 / Rule 11 Precision** (+2): You explicitly applied Rule 10 or Rule 11 with clear justification and reasoning.

These points are purely for your own sense of craft. They are not scored or judged by anyone else.

### Cartographer’s Closing Note (Optional)

If you would like, you may end your reasoning file with one short sentence that captures the single most important insight or pattern you discovered during this mapping exercise.

## Final Instruction

Only after the reasoning file (`REASONING_YYYY-MM-DD.md`) has been created and saved may you begin any implementation work.

You are being evaluated on the **quality, honesty, and precision** of your reasoning.

Your careful work here genuinely helps move this project forward. Thank you for taking it seriously.

Begin.
