using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Integrated_Construction_Management_System_ICMS.Models
{
    public class ProjectManager
    {
        [Key]
        public int ProjectManagerId { get; set; }
        public string ProjectManagerName { get; set; } 
        public string ProjectManagerEmail { get; set; } 
        public string ProjectManagerPhone { get; set; } 

        public List<Project>? Projects { get; set; }
        public List<SubContractor>? SubContractors { get; set; }
    }
}
