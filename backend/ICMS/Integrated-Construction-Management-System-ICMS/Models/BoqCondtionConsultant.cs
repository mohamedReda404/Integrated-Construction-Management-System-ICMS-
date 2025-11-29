namespace Integrated_Construction_Management_System_ICMS.Models
{
    public class BoqCondtionConsultant
    {
        public int BoqCondtionConsultantId { get; set; }
        public int ConsultantBoqId { get; set; }
        public string CondetionDetails {  get; set; }=string.Empty;
    }
}
