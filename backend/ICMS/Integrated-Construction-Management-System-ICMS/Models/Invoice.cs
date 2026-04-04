

namespace Integrated_Construction_Management_System_ICMS.Models
{
    public class Invoice
    {
        public int Id { get; set; } 
        public string ApplicationUserId {  get; set; }=string.Empty;
        public int ProjectId {  get; set; }
        public string Title { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public byte[]? File {  get; set; }
        public DateOnly PeriodFrom {  get; set; }
        public DateOnly PeriodTo {  get; set; }
        public DateOnly InvoiceDate {  get; set; }
        public long TotalAmount {  get; set; }
        public ApplicationUser? ApplicationUser { get; set; }
        public Project? project { get; set; }
        public List<InvoiceItem>? invoiceItem { get; set; }
    }
}
