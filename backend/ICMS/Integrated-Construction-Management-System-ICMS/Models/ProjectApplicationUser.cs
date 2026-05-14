

namespace Integrated_Construction_Management_System_ICMS.Models
{
    public class ProjectApplicationUser
    {
        
        public int ProjectId { get; set; }
        public string ApplicationUserId { get; set; }=string.Empty;
        public Project? project { get; set; }
        public ApplicationUser? ApplicationUser { get; set; }

    }
}
