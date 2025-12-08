
namespace Integrated_Construction_Management_System_ICMS.Models
{
    public class SubConsultant
    {
        //==========INFO=============
        [Key]
        public int SubCosultantID { get; set; }
        [Required, MaxLength(100)]
        public string SubCosultantName { get; set; }=string.Empty;
        [Required, MaxLength(11)]
        public string Phone { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Speciality { get; set; } = string.Empty;




        //==============Realtionships(1:M)=============
        public List<EngineerInvoice>? engineerInvoice { get; set; }
        public ICollection<ShopDrawing>? shopDrawing { get; set; }
        public List<GeneralDrowing>? generalDrowing { get; set; }
        public List<ProjectSubConsultant>? projectSubConsultant { get; set; }
        public List<ConsultantBoq>? consultantBoq { get; set; }


        //============Relationships(M:1)===========
        [Required, ForeignKey("ProjectManagerID")]
        public int ProjectManagerID { get; set; }
        public ProjectManager? _ProjectManager { get; set; }



        [Required, ForeignKey("MainCosultantID")]
        public int MainCosultantID { get; set; }
        public MainConsultant? mainConsultant { get; set; }

    }
}
