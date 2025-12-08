

namespace Integrated_Construction_Management_System_ICMS.Models
{
    public class ProjectSubConsultant
    {
        [Key]
        public int ProjectSubConsultantId { get; set; }


        // =================Relationships(M:1)=============

        [Required, ForeignKey("ProjectID")]
        public int ProjectID { get; set; }
        public Project? project { get; set; }


        [Required, ForeignKey("SubCosultantID")]
        public int SubCosultantID { get; set; }
        public SubConsultant? subConsultant { get; set; }
    }
}
