
namespace Integrated_Construction_Management_System_ICMS.Models
{
    public class ProjectManager
    {
        public int ProjectManagerId { get; set; }
        public string ProjectManagerName { get; set; } = string.Empty;
        public string ProjectManagerEmail { get; set; } = string.Empty;
        public string ProjectManagerPhone { get; set; } = string.Empty;
        public ICollection<Project>? Projects { get; set; }
    }
}
