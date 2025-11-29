namespace Integrated_Construction_Management_System_ICMS.Models
{
    public class ShopDrawing
    {
        public int ShopDrawingId { get; set; }
        public string Description { get; set; }=string.Empty;
        public int SiteEngineerId { get; set; }
        public int ProjectID { get; set; }
        public DateOnly Date { get; set; }

        public bool Approved { get; set; }

    }
}
