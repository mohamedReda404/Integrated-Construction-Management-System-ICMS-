using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Integrated_Construction_Management_System_ICMS.Models
{
    public class ProjectSubContractor
    {
        [Key]
        public int ProjectSubContractorId { get; set; }


        [Required,ForeignKey("ProjectId")]
        public int ProjectId { get; set; }
        public Project? Project { get; set; }

        [Required, ForeignKey("SubContractorId")]
        public int SubContractorId { get; set; }
        public SubContractor? SubContractor { get; set; }
    }
}
