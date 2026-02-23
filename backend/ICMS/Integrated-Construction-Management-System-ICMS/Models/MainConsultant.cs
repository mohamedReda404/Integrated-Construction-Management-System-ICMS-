

namespace Integrated_Construction_Management_System_ICMS.Models
{
    public class MainConsultant
    {
        //================INFO============
        [Key]
        public int MaincosultantID { get; set; }
        [Required,MaxLength(100)]
        public string MainCosultantName { get; set; } = string.Empty;
        [Required,MaxLength(11)]
        public string Phone { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } = string.Empty;


       //====================Relationships(1:M)===========
        public ICollection<Project>? projects { get; set; }
        public ICollection<SubConsultant>? subConsultant { get; set; }


        //==============Reationships(1:1)==============
        [Required, ForeignKey("ProjectManagerId")]
        public int ProjectManagerId {  get; set; }
        public ProjectManager? projectManager { get; set; }



    }
}
