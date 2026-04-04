namespace Integrated_Construction_Management_System_ICMS.Models
{
    public class BOQPricing
    {
        public int Id {  get; set; }
        public int BOQId{  get; set; }
        public int ApplicationUserId {  get; set; }
        public string Title {  get; set; }=string.Empty;
        public string Description {  get; set; }=string.Empty;
        public string Status {  get; set; }=string.Empty;
        public string UnitRate {  get; set; }=string.Empty;
        public long TotalPrice {  get; set; }
        public DateOnly Date {  get; set; }
        public BOQ ?bOQ { get; set; }

    }
}
