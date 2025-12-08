

namespace Integrated_Construction_Management_System_ICMS.Models
{
    public class ConsultantBoq
    {
        //==============INFO==============
        [Key]
        public int ConsultantBoqId { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }=string.Empty;
        [Required, MaxLength(200)]
        public string Description { get; set; } = string.Empty;
        [Required]
        public int Unite { get; set; }
        [Required]
        public int Count { get; set; }
        [Required]
        public DateOnly Date { get; set; }





        //===============Relationships(M:1)=============

        [Required, ForeignKey("ProjectID")]
        public int ProjectID { get; set; }
        public Project? project { get; set; }


        [Required, ForeignKey("SubConsultantID")]
        public int SubConsultantID { get; set; }
        public SubConsultant? subConsultant { get; set; }


        [Required, ForeignKey("SiteEngineerId")]
        public int SiteEngineerId { get; set; }
        public SiteEngineer? siteEngineer { get; set; }



        //============Relationships(1:1)============
        public BoqCondtionConsultant? boqCondtionConsultant { get; set; }

    }
}
