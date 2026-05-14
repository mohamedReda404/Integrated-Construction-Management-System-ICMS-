using Integrated_Construction_Management_System_ICMS.Models;

namespace Integrated_Construction_Management_System_ICMS.Services.Classes
{
    public class RagService
    {
        private readonly ProjectDataService _data;
        private readonly QueryAnalyzer _analyzer;
        private readonly ContextBuilder _builder;
        private readonly IGroqService _groq;

        public RagService(
            ProjectDataService data,
            QueryAnalyzer analyzer,
            ContextBuilder builder,
            IGroqService groq)
        {
            _data = data;
            _analyzer = analyzer;
            _builder = builder;
            _groq = groq;
        }

        public async Task<string> Ask(string message)
        {
            int? projectId = _analyzer.ExtractProjectId(message);
            string? field = _analyzer.ExtractField(message);

            string context = "";

            // =========================================
            // 🧠 BOQ HANDLING
            // =========================================
            if (message.ToLower().Contains("boq") && projectId != null)
            {
                var boqList = await _data.GetProjectBOQ(projectId.Value);

                if (boqList != null && boqList.Count > 0)
                {
                    context = "BOQ DOCUMENT:\n\n" +
                        string.Join("\n\n", boqList.Select(b =>
$@"
Title: {b.Title}
Section: {b.Section}
Description: {b.Description}
Unit: {b.Unit}
Quantity: {b.Quantity}
Type: {b.Type}
Condition: {b.Condetion}
Date: {b.Date}
File: {b.File}
----------------------"));
                }
                else
                {
                    context = "No BOQ data found for this project.";
                }
            }

            // =========================================
            // 🧠 DRAWING HANDLING
            // =========================================
            else if (message.ToLower().Contains("drawing") && projectId != null)
            {
                var drawings = await _data.GetProjectDrawings(projectId.Value);

                if (drawings != null && drawings.Count > 0)
                {
                    context = "DRAWINGS DATA:\n\n" +
                        string.Join("\n\n", drawings.Select(d =>
$@"
Title: {d.Title}
Description: {d.Description}
Section: {d.Section}
Status: {d.Status}
Type: {d.Type}
Date: {d.Date}
Photo: {d.Photo}
----------------------"));
                }
                else
                {
                    context = "No drawing data found for this project.";
                }
            }

            // =========================================
            // 🧠 PROJECT HANDLING
            // =========================================
            else
            {
                if (projectId != null)
                {
                    var project = await _data.GetById(projectId.Value);

                    if (project == null)
                        return "Project not found in database.";

                    // لو user طالب field معين
                    if (!string.IsNullOrEmpty(field))
                    {
                        context = _data.GetField(project, field);
                    }
                    else
                    {
                        // رجّع بيانات المشروع كاملة
                        context = _builder.Build(new List<Project> { project });
                    }
                }

                // =========================================
                // 🧠 FALLBACK (ALL PROJECTS)
                // =========================================
                if (string.IsNullOrEmpty(context))
                {
                    var allProjects = await _data.GetAll();

                    if (allProjects.Count > 0)
                    {
                        context = _builder.Build(allProjects);
                    }
                    else
                    {
                        context = "No data available in database.";
                    }
                }
            }

            // =========================================
            // 🧠 AI PROMPT
            // =========================================
            var prompt = $@"
You are ICMS Construction AI Assistant.

You understand natural language construction queries.

RULES:
- 'project 3 category' = Category of Project ID 3
- BOQ = Bill of Quantities
- Drawing = engineering drawing / blueprint
- Projects can contain multiple BOQs and Drawings
- Return BOQ and Drawing data in structured readable format
- Use ONLY provided data
- Do NOT invent information
- If data exists, answer directly and naturally
- If data does not exist, say it clearly

DATA:
{context}

QUESTION:
{message}
";

            return await _groq.AskAsync(prompt);
        }
    }
}