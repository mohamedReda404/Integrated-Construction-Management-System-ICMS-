using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Integrated_Construction_Management_System_ICMS.Models
{
    public class MainConsultant
    {
        [Key]
        public int MainCosultantID { get; set; }
        public string MainCosultantName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
