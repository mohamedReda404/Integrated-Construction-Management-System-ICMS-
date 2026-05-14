using System.Text.RegularExpressions;

namespace Integrated_Construction_Management_System_ICMS.Services.Classes
{
    public class QueryRouter
    {
        public bool IsProjectQuery(string message)
        {
            return message.ToLower().Contains("project");
        }

        public int? ExtractProjectId(string message)
        {
            var match = Regex.Match(message, @"\d+");
            return match.Success ? int.Parse(match.Value) : null;
        }
    }
}
