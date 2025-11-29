namespace Integrated_Construction_Management_System_ICMS.Models
{
    public class EngineerInvoice
    {
        public int EngineerInvoiceId { get; set; }
        public string Name { get; set; }=string.Empty;
        public int SiteEngineerId { get; set; }
        public int ProjectID { get; set; }

        public int Count { get; set; }

        public int Unite { get; set; }
        public int Total { get; set; }

        public string Type { get; set; } = string.Empty;
        public int OldCompletion { get; set; }
        public int NewCompletion { get; set; }
        public int TotalInvoiceCost { get; set; }

        public DateOnly Date {  get; set; }

        public bool Approved { get; set; }




    }
}
