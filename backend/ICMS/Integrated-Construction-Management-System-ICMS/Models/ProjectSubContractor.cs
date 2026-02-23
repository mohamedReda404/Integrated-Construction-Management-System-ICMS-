

namespace Integrated_Construction_Management_System_ICMS.Models
{
    public class ProjectSubContractor
    {
        //===============INFO==========
        [Key]
        public int ProjectSubContractorId { get; set; }



        //===================Relationships(M:1)===============
        [Required,ForeignKey("ProjectID")]
        public int ProjectID { get; set; }
        public Project? project { get; set; }


        [Required, ForeignKey("SubContractorId")]
        public int SubContractorId { get; set; }
        public SubContractor? subContractor { get; set; }
    }
}
