using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Integrated_Construction_Management_System_ICMS.Models
{
    public class SubContractor
    {
        [Key]
        public int SubContractorId { get; set; }
        public string SubContractorName { get; set; } 
        public string SubContractorEmail { get; set; } 
        public string SubContractorPhone { get; set; } 
        public string SubContractorSpeciality { get; set; } 

        public List<Store>? Stores { get; set; }
        public List<ProjectSubContractor> ProjectSubContractors { get; set; }

       // public List<SubContractorInvoice>SubContractorInvoices { get; set; }


    }
}
