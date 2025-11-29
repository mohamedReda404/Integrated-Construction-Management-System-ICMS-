namespace Integrated_Construction_Management_System_ICMS.Models
{
    public class BoqCondtionEng
    {
        public int BoqCondtionEngId { get; set; }
        public int EngineerBoqId { get; set; }
        public string CondtionDetails { get; set; } = string.Empty;
    }
}
