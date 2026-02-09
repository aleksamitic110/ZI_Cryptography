# SKILLS.md — C# WinForms UI/UX Improvement Skills

This repo contains a C# Windows Forms application. Your job is to improve the UI/UX and visual design of the **existing** WinForms screens while preserving all current functionality.

You MUST follow the rules below.

---

## 0) Core goals (what “good” means here)

Improve:
- Visual consistency (fonts, spacing, alignment, colors)
- Readability (hierarchy, labels, grouping, whitespace)
- Layout robustness (resizes correctly, no overlapping/clipping)
- Usability (tab order, keyboard shortcuts, clear validation feedback)
- Maintainability (small reusable helpers, minimal designer churn)

Do NOT:
- Break event handlers, data binding, or business logic
- Change existing feature behavior unless explicitly asked
- Replace WinForms with WPF/MAUI
- Introduce heavy external UI frameworks unless requested

---

## 1) Operating rules (WinForms-specific)

### 1.1 Prefer layout panels over absolute positioning
When improving a form, **reduce magic coordinates** and use:
- `TableLayoutPanel` for grid-like structure
- `FlowLayoutPanel` for dynamic rows of buttons/filters/tags
- `Panel` + `Dock` for header/body/footer sections

Use `Dock` and `Anchor` correctly:
- Primary content should `Dock = Fill`
- Bottom button bars `Dock = Bottom`
- Side navigation `Dock = Left` (fixed width)
- Inputs usually `Anchor = Top, Left, Right`
- Data grids/lists `Anchor = Top, Bottom, Left, Right`

### 1.2 Build a consistent spacing system
Use consistent spacing:
- Outer padding: 16
- Section spacing: 12
- Row spacing: 8
- Control-to-label spacing: 6
- Button spacing: 8
Prefer `Padding`/`Margin` over manual coordinates.

### 1.3 Standardize typography
Use a consistent font across the app:
- Default: `Segoe UI`, 9F (or 10F if it improves readability)
- Headers: same font, 11–12F, `FontStyle.Bold`
Do not mix many fonts.

### 1.4 Standardize button styles
Primary action (most important): one per form.
- Primary: slightly stronger emphasis (e.g. bold text, distinct background)
- Secondary: neutral
- Destructive: red accent (only when needed)
Buttons should have consistent height (e.g. 30–34).

### 1.5 Use clear grouping
Group related inputs using:
- `GroupBox` (simple)
- Or a “SectionPanel” pattern: titled panel + border + padding
Add meaningful section titles like “Details”, “Filters”, “Advanced”.

---

## 2) Visual style guidelines (modern WinForms without heavy frameworks)

### 2.1 Color palette (keep it simple)
Prefer neutral UI:
- Backgrounds: very light gray/white
- Text: dark gray/black
- Borders: subtle
- Accent: one consistent color used for selected states, links, primary action

Avoid bright saturated backgrounds everywhere.

### 2.2 Reduce visual noise
- Prefer flat, subtle borders
- Avoid too many GroupBoxes nested inside each other
- Use whitespace instead of lines whenever possible

### 2.3 Icons (optional)
If adding icons:
- Use built-in system icons or a small vetted icon set already in the repo
- Do not add new large icon dependencies unless asked
- Keep icon size consistent (16 or 20)

---

## 3) Accessibility & UX rules (must)

- Set `TabIndex` and `TabStop` properly (natural top-to-bottom, left-to-right)
- Set `AcceptButton` (e.g. Save/OK) and `CancelButton` (e.g. Close/Cancel)
- Provide keyboard access:
  - Use `&` in button/label text for accelerators (e.g. `&Save`)
- Ensure contrast is readable (don’t use light gray text on white)
- Provide validation feedback:
  - Use `ErrorProvider` for invalid fields
  - Keep messages specific and short

---

## 4) Safe refactoring boundaries

You MAY:
- Reorganize layout using panels
- Rename controls to meaningful names (carefully) if it doesn’t break handlers
- Extract small UI helper methods/classes (styling/theme)
- Convert repeated UI fragments into `UserControl` if it reduces duplication

You MUST NOT:
- Rewrite domain logic
- Change data models
- Change public APIs unless asked
- Move files massively unless needed

If you must rename a control referenced by code, update all references.

---

## 5) Implementation pattern: “UI Theme” helper (preferred)

Create a small internal styling helper, e.g.:

- `UiTheme.cs` with methods like:
  - `ApplyBaseFormStyle(Form form)`
  - `StylePrimaryButton(Button btn)`
  - `StyleSecondaryButton(Button btn)`
  - `StyleTextBox(TextBox tb)`
  - `StyleGrid(DataGridView grid)`

Rules for theme helper:
- No external dependencies
- Keep it idempotent (safe to call multiple times)
- Call from form constructors AFTER `InitializeComponent()`

Example intent (don’t blindly copy; adapt to repo):
- Set default fonts
- Set consistent backcolors
- Set grid header styles
- Set padding on panels

---

## 6) Step-by-step workflow you MUST follow per screen

1. Identify the target form(s) and take note of current layout issues:
   - misalignment, cramped spacing, inconsistent fonts, clipping on resize
2. Propose a layout plan:
   - Where to add `TableLayoutPanel` / `FlowLayoutPanel`
   - Where to dock header/footer
3. Implement layout changes carefully:
   - Prefer minimal diffs in `.Designer.cs`
   - Avoid deleting and recreating many controls unnecessarily
4. Apply theme:
   - Use the `UiTheme` helper for consistent styling
5. Verify behavior:
   - All buttons still work
   - Validation still works
   - Resizing doesn’t break layout
   - Tab order makes sense
6. Summarize what changed and why.

---

## 7) DataGridView guidelines (common in WinForms)

If the app uses `DataGridView`, apply:
- `AutoSizeColumnsMode = Fill` (or sensible sizing per column)
- `SelectionMode = FullRowSelect`
- `MultiSelect = false` (unless required)
- Hide row headers if not needed: `RowHeadersVisible = false`
- Consistent header font/bold
- Alternate row colors subtly (optional)

Do not break existing column bindings.

---

## 8) Output format (what to deliver)

For each form you improve, provide:
- A short before/after description (bullets)
- Files changed
- Any new helper class added
- Notes about layout decisions (Dock/Anchor choices)

---

## 9) Quality bar checklist (pass/fail)

PASS if:
- Layout scales on resize
- Spacing is consistent
- Typography consistent
- Primary action clear
- No broken handlers
- Tab order and keyboard actions work

FAIL if:
- Overlaps/clipping occur
- Random fonts/colors
- Huge designer churn for no reason
- Functionality breaks

---

## 10) If you are unsure

Default to:
- minimal safe changes
- better spacing + layout panels
- a small theme helper
Ask for the target form name if needed, but do not block—start from the most used/main form.

