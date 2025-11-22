namespace Integrated_Construction_Management_System_ICMS.Models
{
    public class SiteEngineer
    {
        public int SiteEngineerId { get; set; }
        public string SiteEngineerName { get; set; } = string.Empty;
        public string SiteEngineerEmail { get; set; } = string.Empty;
        public string SiteEngineerPhone { get; set; } = string.Empty;
        public string SiteEngineerSpeciality { get; set; } = string.Empty;
        public ICollection<Store>? Stores { get; set; }
        public ICollection<ProjectSiteEngineer> ProjectSiteEngineers { get; set; }


        // public ICollection<ProjectEngineer> ProjectEngineers { get; set; }

    }
}
