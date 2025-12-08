

namespace Integrated_Construction_Management_System_ICMS.Models
{
    public class Material
    {

        //================INFO==========
        [Key]
        public int MaterialId { get; set; }
        [Required, MaxLength(100)]
        public string MaterialName { get; set; } = string.Empty;
        [Required]
        public string MaterialType { get; set; } = string.Empty;
        [Required]
        public int MaterialCount { get; set; }
        [Required, MaxLength(200)]
        public string MaterialDescription { get; set; } = string.Empty;
        [Required]
        public DateTime DateTime { get; set; }



        //============Relationships(M:1)===========
        [Required, ForeignKey("ProjectManagerID")]
        public int ProjectManagerID { get; set; }
        public ProjectManager? _ProjectManager { get; set; }


        [Required, ForeignKey("StoreId")]
        public int StoreId { get; set; }
        public Store? Store { get; set; }

    }
}
