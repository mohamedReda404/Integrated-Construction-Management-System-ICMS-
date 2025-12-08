

namespace Integrated_Construction_Management_System_ICMS.Models
{
    public class SiteEngineer
    {
        //==============INFO==============
        [Key]
        public int SiteEngineerId { get; set; }
        [Required,MaxLength(100)]
        public string SiteEngineerName { get; set; } = string.Empty;
        [Required]
        public string SiteEngineerEmail { get; set; } = string.Empty;
        [Required,MaxLength(11)]
        public string SiteEngineerPhone { get; set; } = string.Empty;
        [Required]
        public string SiteEngineerSpeciality { get; set; } = string.Empty;



        //============Relationships(1:M)==============
        public ICollection<EngineerBoq>? engineerBoq { get; set; }
        public ICollection<Store>? stores { get; set; }
        public ICollection<ProjectSiteEngineer>? projectSiteEngineers { get; set; }
        public ICollection<SubConstractorInvoice>? subConstractorInvoice { get; set; }
        public ICollection<EngineerInvoice>? engineerInvoice { get; set; }
        public ICollection<ShopDrawing>? shopDrawing { get; set; }
        public ICollection<ConsultantBoq>? consultantBoq { get; set; }


        //============Relationships(M:1)===========
        [Required, ForeignKey("ProjectManagerID")]
        public int ProjectManagerID { get; set; }
        public ProjectManager? _ProjectManager { get; set; }

    }
}
