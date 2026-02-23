

namespace Integrated_Construction_Management_System_ICMS.Models
{
    public class ProjectSiteEngineer
    {
        //============INFO============
        [Key]
        public int ProjectSiteEngineerID { get; set; }


        //============Relationships(M:1)============
        [Required, ForeignKey("ProjectID")]
        public int ProjectID { get; set; }
        public Project? Project { get; set; }



        [Required, ForeignKey("SiteEngineerId")]
        public int SiteEngineerId { get; set; }
        public SiteEngineer? SiteEngineer { get; set; }
    }
}
