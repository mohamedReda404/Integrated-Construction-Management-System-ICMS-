

namespace Integrated_Construction_Management_System_ICMS.Models
{
    public class ProjectContract
    {
        //===============INFO================
        [Key]
        public int ProjectContractId { get; set; }
        [Required]
        public DateTime ContractDate { get; set; }
        [Required,MaxLength(1000)]
        public string ContractDetails { get; set; } = string.Empty;
        [Required, MaxLength(200)]
        public string EndContractIfs { get; set; } = string.Empty;

        [Required]
        public string ClientCondition { get; set; } = string.Empty;
        [Required]
        public string ClientSignature { get; set; } = string.Empty;

        [Required]
        public string ManagerSignature { get; set; } = string.Empty;
        [Required]
        public string ManagerCondition { get; set; } = string.Empty;




        //=========Relationships(1:1)===========

        [Required, ForeignKey("ProjectManagerId")]
        public int ProjectManagerId { get; set; }
        public ProjectManager? projectManager { get; set; }


        [Required, ForeignKey("ProjectID")]
        public int ProjectID { get; set; }
        public Project? project { get; set; }



        [Required, ForeignKey("MainClientId")]
        public int MainClientId { get; set; }
        public MainClient? mainClient { get; set; }

    }
}
