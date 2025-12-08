

namespace Integrated_Construction_Management_System_ICMS.Models
{
    public class EngineerBoq
    {

        //=============INFO=============
        [Key]
        public int EngineerBoqID { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        [Required, MaxLength(200)]
        public string Description { get; set; }=string.Empty;
        [Required]
        public string Unite { get; set; } = string.Empty;
        [Required]
        public int Count { get; set; }
        [Required]
        public DateOnly Date{get;set;}




        //===============Relationships(M:1)============
        [Required, ForeignKey("ProjectID")]
        public int ProjectID { get; set; }
        public Project? project { get; set; }



        [Required, ForeignKey("SiteEngineerId")]
        public int StieEngineerId { get; set; }
        public SiteEngineer? siteEngineer { get; set; }


        [Required, ForeignKey("SubContractorId")]
        public int SubContractorId { get; set; }
        public SubContractor? subContractor { get; set; }


        //==============Relationships(1:1)============
        public BoqCondtionEng? boqCondtionEng { get; set; }






    }
}
