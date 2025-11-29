namespace Integrated_Construction_Management_System_ICMS.Models
{
    public class Material
    {
        public int MaterialId { get; set; }
        public string MaterialName { get; set; } = string.Empty;
        public string MaterialType { get; set; } = string.Empty;
        public int MaterialCount { get; set; }
        public string MaterialDescription { get; set; } = string.Empty;

        public DateTime DateTime { get; set; }

        public int StoreId { get; set; }
        public Store? Store { get; set; }

    }
}
