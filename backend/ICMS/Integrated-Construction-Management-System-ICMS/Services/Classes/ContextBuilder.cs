using System.Text;

namespace Integrated_Construction_Management_System_ICMS.Services.Classes
{
    public class ContextBuilder
    {
        public string Build(List<Project> projects)
        {
            var sb = new StringBuilder();

            sb.AppendLine("=== ICMS PROJECTS DATA ===");
            sb.AppendLine("Use ONLY this data to answer questions.");
            sb.AppendLine("Do NOT assume or invent missing information.");
            sb.AppendLine("=====================================");
            sb.AppendLine();

            foreach (var p in projects)
            {
                sb.AppendLine($"[PROJECT #{p.Id}]");
                sb.AppendLine($"Name        : {p.Name}");
                sb.AppendLine($"Location    : {p.Location}");
                sb.AppendLine($"Category    : {p.Category}");
                sb.AppendLine($"Client      : {p.ClientName}");
                sb.AppendLine($"Contract    : {p.ContractValue}");
                sb.AppendLine($"Description : {p.Descritpion}");
                sb.AppendLine($"Start Date  : {p.StartDate}");
                sb.AppendLine($"End Date    : {p.EndDate}");
                sb.AppendLine("-------------------------------------");
            }

            if (projects == null || projects.Count == 0)
            {
                sb.AppendLine("NO PROJECT DATA AVAILABLE.");
            }

            return sb.ToString();
        }
    }
}