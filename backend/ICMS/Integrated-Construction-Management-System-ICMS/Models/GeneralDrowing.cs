namespace Integrated_Construction_Management_System_ICMS.Models
{
    public class GeneralDrowing
    {
        public int GeneralDrowingId { get; set; }
        public string Dscription { get; set; }=string.Empty;
        public int SubCosultantID { get; set; }
        public int ProjectID { get; set; }
        public DateOnly Date { get; set; }
    }
}
