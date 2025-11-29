namespace Integrated_Construction_Management_System_ICMS.Models
{
    public class SubConstractorInvoice
    {
        public int SubConstractorInvoiceId { get; set; }
        public int SubContractorId { get; set; }
        public int ProjectID { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Count { get; set; }
        public string Unite { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;

        public int Total { get; set; }

        public int OldCompletion{ get; set; }
        public int NewCompletion{ get; set; }
        public int TotalInvoiceCost { get; set; }

        public DateOnly Date { get; set; }
        public bool Approved { get; set; }

    }
}
