

namespace Integrated_Construction_Management_System_ICMS.Models
{
    public class BoqCondtionConsultant
    {
        //============INFO============
        [Key]
        public int BoqCondtionConsultantId { get; set; }
        [Required,MaxLength(200)]
        public string CondetionDetails { get; set; } = string.Empty;


        //=============Realtionships(1:1)===========
        [Required,ForeignKey("ConsultantBoqId")]
        public int ConsultantBoqId { get; set; }
        public ConsultantBoq? _consultantBoq { get; set; }


        
    }
}
