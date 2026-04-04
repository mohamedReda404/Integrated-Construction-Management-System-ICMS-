

namespace Integrated_Construction_Management_System_ICMS.Models
{
    public class ApplicationUser:IdentityUser
    {
        public List<ProjectApplicationUser>? projectApplicationUser { get; set; }
        public List<MaterialsRequest>? materialsRequest { get; set; }
        public List<BOQ>? bOQ { get; set; }
        public List<Drawing>? drawing { get; set; }
        public List<Invoice>? invoice { get; set; }
    }
}
