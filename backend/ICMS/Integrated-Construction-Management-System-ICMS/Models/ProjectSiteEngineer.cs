namespace Integrated_Construction_Management_System_ICMS.Models
{
    public class ProjectSiteEngineer
    {
        public int ProjectSiteEngineerId { get; set; }

        public int ProjectId { get; set; }
        public Project? Project { get; set; }
        public int SiteEngineerId { get; set; }
        public SiteEngineer? SiteEngineer { get; set; }
    }
}
