using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Integrated_Construction_Management_System_ICMS.Models
{
    public class ProjectContract
    {
        [Key]
        public int ProjectContractId { get; set; }
        public DateTime ContractDate { get; set; }
        public string ContractDetails { get; set; } 
        public string EndContractIfs { get; set; }

        // project
        [ForeignKey("Project")]
        public int ProjectId { get; set; }

        // project manager
        public string ProjectManagerName { get; set; } 

        // main client
        public string MainClientName { get; set; } 

        // client
        public string ClientCondition { get; set; } 
        public string ClientSignature { get; set; }

        // manager
        public string ManagerSignature { get; set; } 
        public string ManagerCondition { get; set; } 


    }
}
