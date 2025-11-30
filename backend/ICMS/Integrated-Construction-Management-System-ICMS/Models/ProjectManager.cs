
using System.ComponentModel.DataAnnotations;

namespace Integrated_Construction_Management_System_ICMS.Models
{
    public class ProjectManager
    {
        [Key]
        public int ProjectManagerId { get; set; }
        [Required,MaxLength(50)]
        public string ProjectManagerName { get; set; } = string.Empty;
        [Required,MaxLength(50)]
        public string ProjectManagerEmail { get; set; } = string.Empty;
        [Required,MaxLength(11)]
        public string ProjectManagerPhone { get; set; } = string.Empty;
        public ICollection<Project>? Projects { get; set; }
        public ProjectContract? _projectContract {  get; set; }
    }
}
