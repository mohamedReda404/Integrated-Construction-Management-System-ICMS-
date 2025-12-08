

namespace Integrated_Construction_Management_System_ICMS.Models
{
    public class ProjectManager
    {
        //============INFO==========
        [Key]
        public int ProjectManagerId { get; set; }

        [Required,MaxLength(100)]
        public string ProjectManagerName { get; set; } = string.Empty;
        [Required]
        public string ProjectManagerEmail { get; set; } = string.Empty;
        [Required,MaxLength(11)]
        public string ProjectManagerPhone { get; set; } = string.Empty;



        //===============Relationships(1:M)==============
        public ICollection<Project>? projects { get; set; }
        public ICollection<Material>? material { get; set; }
        public ICollection<SubConsultant>? subConsultant { get; set; }
        public ICollection<SiteEngineer>? siteEngineer { get; set; }




        //=============Relationships(1:1)===========
        public ProjectContract? projectContract {  get; set; }
        public Foreman? foreman { get; set; }
        public MainConsultant? mainConsultant { get; set; }
    }
}
