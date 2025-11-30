using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Integrated_Construction_Management_System_ICMS.Models
{
    public class MainConsultant
    {
        [Key]
        public int MainCosultantID { get; set; }
        [Required,MaxLength(50)]
        public string MainCosultantName { get; set; } = string.Empty;
        [Required,MaxLength(11)]
        public string Phone { get; set; } = string.Empty;
        [Required,MaxLength(50)]
        public string Email { get; set; } = string.Empty;


        [Required, ForeignKey("ProjectID")]
        public int ProjectID { get; set; }
        public ICollection<Project>? projects { get; set; }
    }
}
