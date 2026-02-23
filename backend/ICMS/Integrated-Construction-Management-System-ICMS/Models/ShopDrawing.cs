

namespace Integrated_Construction_Management_System_ICMS.Models
{
    public class ShopDrawing
    {

        //===================INFO
        [Key]
        public int ShopDrawingId { get; set; }
        [Required, MaxLength(200)]
        public string Description { get; set; }=string.Empty;
        [Required]
        public DateOnly Date { get; set; }
        [Required]
        public bool Approved { get; set; }




        //============RelationShips(M:1)=============

        [Required, ForeignKey("ProjectID")]
        public int ProjectID { get; set; }
        public Project? project { get; set; }


        [Required, ForeignKey("SiteEngineerId")]
        public int SiteEngineerId { get; set; }
        public SiteEngineer? siteEngineer { get; set; }



        [Required, ForeignKey("SubCosultantID")]
        public int SubCosultantID { get; set; }
        public SubConsultant? subConsultant { get; set; }




    }
}
