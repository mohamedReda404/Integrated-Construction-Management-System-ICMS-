

namespace Integrated_Construction_Management_System_ICMS.Models
{
    public class SubConstractorInvoice
    {
        //===============INFO===============
        [Key]
        public int SubConstractorInvoiceId { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        [Required]
        public int Count { get; set; }
        [Required]
        public string Unite { get; set; } = string.Empty;
        [Required]
        public string Type { get; set; } = string.Empty;
        [Required]
        public int Total { get; set; }
        [Required]
        public int OldCompletion{ get; set; }
        [Required]
        public int NewCompletion{ get; set; }
        [Required]
        public int TotalInvoiceCost { get; set; }
        [Required]
        public DateOnly Date { get; set; }
        [Required]
        public bool Approved { get; set; }



       
        //================Relationships(M:1)=============

        [Required, ForeignKey("ProjectID")]
        public int ProjectID { get; set; }
        public Project? project { get; set; }



        [Required, ForeignKey("SiteEngineerId")]
        public int SiteEngineerId { get; set; }
        public SiteEngineer? siteEngineer { get; set; }


        [Required, ForeignKey("SubContractorId")]
        public int SubContractorId { get; set; }
        public SubContractor? SubContractor { get; set; }





    }
}
