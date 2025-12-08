
namespace Integrated_Construction_Management_System_ICMS.Models
{
    public class Store
    {
        //========INFO==========
        [Key]
        public int StoreID { get; set; }
        [Required, MaxLength(100)]
        public string StoreName { get; set; } = string.Empty;




        //====Realtionships(1:1)=========

        [Required, ForeignKey("ProjectID")]
        public int ProjectID { get; set; }
        public Project? Project { get; set; }




        //================Relationships(M:1)===========
        [Required, ForeignKey("ForemanId")]
        public int ForemanId { get; set; }
        public Foreman? foreman { get; set; }


        [Required, ForeignKey("SiteEngineerId")]
        public int SiteEngineerId { get; set; }
        public SiteEngineer? siteEngineer { get; set; }


        [Required, ForeignKey("SubContractorId")]
        public int SubContractorId { get; set; }
        public SubContractor? subContractor { get; set; }



        //==========Relationships(1:M)=========
        public ICollection<Material>? Materials { get; set; }

    }
}
