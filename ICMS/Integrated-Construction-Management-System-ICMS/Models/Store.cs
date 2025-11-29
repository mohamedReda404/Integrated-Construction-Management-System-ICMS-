using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Integrated_Construction_Management_System_ICMS.Models
{
   
    public class Store
    {
        [Key]
        public int StoreId { get; set; }
        public string StoreName { get; set; } 
       public string StoreLocation { get; set; } 

        public List<Project> projects { get; set; }
        public List<Material>? Materials { get; set; }

        // project
        [ForeignKey("Project")]
        public int ProjectId { get; set; }

        // foreman
        [ForeignKey("Foreman")]
        public int ForemanId { get; set; }

        // site engineer
        [ForeignKey("SiteEngineer")]
        public int SiteEngineerId { get; set; }
        // sub contractor
        [ForeignKey("SubContractor")]
        public int SubContractorId { get; set; }

    }

}
