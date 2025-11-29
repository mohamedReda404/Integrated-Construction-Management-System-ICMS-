using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Integrated_Construction_Management_System_ICMS.Models
{
    public class Material
    {
        [Key]
        public int MaterialId { get; set; }
        public string MaterialName { get; set; }
        public string MaterialType { get; set; }
        public int MaterialCount { get; set; }
        public string MaterialDescription { get; set; } 

        public DateTime DateTime { get; set; }

        // store
        [ForeignKey("Store")]
        public int StoreId { get; set; }

    }
}
