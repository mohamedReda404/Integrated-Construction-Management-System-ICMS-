namespace Integrated_Construction_Management_System_ICMS.Models
{
    public class EngineerBoq
    {
        public int EngineerBoqId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int SiteEngineerId { get; set; }
        public string Description { get; set; }=string.Empty;

        public string Unite { get; set; } = string.Empty;
        public int Count { get; set; }

        public DateOnly Date{get;set;}



    }
}
