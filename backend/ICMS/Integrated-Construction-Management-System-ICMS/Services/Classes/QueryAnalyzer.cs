namespace Integrated_Construction_Management_System_ICMS.Services.Classes
{
    public class QueryAnalyzer
    {
        public int? ExtractProjectId(string message)
        {
            var match = System.Text.RegularExpressions.Regex.Match(message, @"\d+");
            return match.Success ? int.Parse(match.Value) : null;
        }

        public string? ExtractField(string message)
        {
            message = message.ToLower();

            if (message.Contains("category")) return "Category";
            if (message.Contains("location")) return "Location";
            if (message.Contains("client")) return "ClientName";
            if (message.Contains("description")) return "Description";

            return null;
        }
    }
    }
