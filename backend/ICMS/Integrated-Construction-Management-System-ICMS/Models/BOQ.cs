
namespace Integrated_Construction_Management_System_ICMS.Models
{
    public class BOQ
    {
        public int Id { get; set; }
        public int ProjectId {  get; set; }
        public string ApplicationUserId {  get; set; }=string.Empty;
        public string Title {  get; set; }=string.Empty;
        public string Description {  get; set; }=string.Empty;
        public string Condetion {  get; set; }=string.Empty;
        public string Unit {  get; set; }=string.Empty;
        public string Section {  get; set; }=string.Empty;
        public string Quantity {  get; set; }=string.Empty;
        public string Type {  get; set; }=string.Empty; //Engineer or Consultant
        public DateOnly Date { get; set; }
        public byte[] ?File { get; set; } //Photo or bdf File
        public ApplicationUser? ApplicationUser { get; set; }
        public BOQPricing? bOQPricing { get; set; }
        public Project? project { get; set; }
        //public List<InvoiceItem>? invoiceItem { get; set; }
    }
}
