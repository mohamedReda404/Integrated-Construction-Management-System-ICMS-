namespace Integrated_Construction_Management_System_ICMS.Models
{
    public class ConsultantBoq
    {
        public int ConsultantBoqId { get; set; }
        public string Name { get; set; }=string.Empty;
        public int ProjectID { get; set; }
        public string Description { get; set; } = string.Empty;
        public int Unite { get; set; }
        public int Count { get; set; }
        public DateOnly Date { get; set; }
        public int SubCosultantID { get; set; }

    }
}
