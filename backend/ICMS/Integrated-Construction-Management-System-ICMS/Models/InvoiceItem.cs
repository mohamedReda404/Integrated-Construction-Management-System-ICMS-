
namespace Integrated_Construction_Management_System_ICMS.Models
{
    public class InvoiceItem
    {
        public int Id { get; set; }
        public int InvoiceId { get; set; }
        public int Previous_qty {  get; set; }
        public int Current_qty {  get; set; }
        public long Total_qty {  get; set; }
        public int Rate {  get; set; }
        public long Amount {  get; set; }
        public Invoice ? invoice { get; set; }
     

    }
}
