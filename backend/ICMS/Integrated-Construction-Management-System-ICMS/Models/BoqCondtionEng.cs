

namespace Integrated_Construction_Management_System_ICMS.Models
{
    public class BoqCondtionEng
    {
        [Key]
        public int BoqCondtionEngId { get; set; }
        [Required]
        public string CondtionDetails { get; set; } = string.Empty;



        //===================Reltaionships(1:1)================
        [Required, ForeignKey("EngineerBoqID")]
        public int EngineerBoqID { get; set; }
        public EngineerBoq? engineerBoq { get; set; }

    }
}
