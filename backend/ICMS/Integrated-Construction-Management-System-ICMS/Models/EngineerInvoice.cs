

namespace Integrated_Construction_Management_System_ICMS.Models
{
    public class EngineerInvoice
    {
        //===============INFO============
        [Key]
        public int EngineerInvoiceId { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }=string.Empty;
        [Required]
        public int Count { get; set; }
        [Required]
        public int Unite { get; set; }
        [Required]
        public int Total { get; set; }
        [Required]
        public string Type { get; set; } = string.Empty;
        [Required]
        public int OldCompletion { get; set; }
        [Required]
        public int NewCompletion { get; set; }
        [Required]
        public int TotalInvoiceCost { get; set; }
        [Required]
        public DateOnly Date {  get; set; }
        [Required]
        public bool Approved { get; set; }


        //===============Realtipnships(M:1)============

        [Required, ForeignKey("ProjectID")]
        public int ProjectID { get; set; }
        public Project? project { get; set; }


        [Required, ForeignKey("SiteEngineerId")]
        public int SiteEngineerId { get; set; }
        public SiteEngineer? siteEngineer { get; set; }



        [Required, ForeignKey("SubCosultantID")]
        public int SubCosultantID { get; set; }
        public SubConsultant? subConsultant { get; set; }

    }
}
