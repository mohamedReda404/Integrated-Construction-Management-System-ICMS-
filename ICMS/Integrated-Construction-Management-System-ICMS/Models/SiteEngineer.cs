using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Integrated_Construction_Management_System_ICMS.Models
{
    public class SiteEngineer
    {
        [Key]
        public int SiteEngineerId { get; set; }
        public string SiteEngineerName { get; set; } 
        public string SiteEngineerEmail { get; set; } 
        public string SiteEngineerPhone { get; set; } 
        public string SiteEngineerSpeciality { get; set; } 

        public List<Store>? Stores { get; set; }
        public List<ProjectSiteEngineer> ProjectSiteEngineers { get; set; }



    }
}
