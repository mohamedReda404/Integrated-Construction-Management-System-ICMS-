

namespace Integrated_Construction_Management_System_ICMS.Models
{
    public class FormanTasks
    {
        //===================INFO===========
        [Key]
        public int TaskID { get; set; }
        [Required, MaxLength(100)]
        public string TaskName { get; set; } = string.Empty;
        [Required, MaxLength(300)]
        public string Description { get; set; } = string.Empty;
        [Required]
        public string Type { get; set; } = string.Empty;
        [Required]
        public DateTime DateStart { get; set; }
        [Required]
        public DateTime DateEnd { get; set; }




        //=========================Realtionships================

        [Required, ForeignKey("ProjectID")]
        public int ProjectID { get; set; }
        public Project? project { get; set; }



        [Required, ForeignKey("ForemanId")]
        public int ForemanId { get; set; }
        public Foreman? foreman { get; set; }





    }
}
