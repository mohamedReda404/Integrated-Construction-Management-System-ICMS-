using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Integrated_Construction_Management_System_ICMS.Models
{
    public class Store
    {
        public int StoreId { get; set; }
        public string StoreName { get; set; } = string.Empty;
       public string StoreLocation { get; set; } = string.Empty;
        public ICollection<Material>? Materials { get; set; }


        [Required, ForeignKey("ProjectId")]
        public int ProjectId { get; set; }
        public Project? Project { get; set; }


        public int ForemanId { get; set; }
        public Foreman? Foreman { get; set; }
        public int SiteEngineerId { get; set; }
        public SiteEngineer? SiteEngineer { get; set; }
        public int SubContractorId { get; set; }
        public SubContractor? SubContractor { get; set; }

    }
}
