

namespace Integrated_Construction_Management_System_ICMS.Models
{
    public class SubContractor
    {
        //===========INFO=============
        [Key]
        public int SubContractorId { get; set; }
        [Required,MaxLength(100)]
        public string SubContractorName { get; set; } = string.Empty;
        [Required]
        public string SubContractorEmail { get; set; } = string.Empty;
        [Required,MaxLength(11)]
        public string SubContractorPhone { get; set; } = string.Empty;
        [Required]
        public string SubContractorSpeciality { get; set; } = string.Empty;


        //===========Relationships(1:M)===========
        public ICollection<EngineerBoq>? engineerBoq { get; set; }
        public ICollection<Store>? stores { get; set; }
        public ICollection<ProjectSubContractor>? projectSubContractors { get; set; }
        public ICollection<SubConstractorInvoice>? subConstractorInvoice { get; set; }

    }
}
