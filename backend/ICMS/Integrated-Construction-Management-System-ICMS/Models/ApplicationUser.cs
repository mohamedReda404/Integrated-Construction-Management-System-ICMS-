

namespace Integrated_Construction_Management_System_ICMS.Models
{
    public sealed class ApplicationUser:IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int ProjectContractId {  get; set; }
        public List<ProjectApplicationUser>? projectApplicationUser { get; set; }
        public List<MaterialsRequest>? materialsRequest { get; set; }
        public List<BOQ>? bOQ { get; set; }
        public List<Drawing>? drawing { get; set; }
        public List<Invoice>? invoice { get; set; }
        public ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();
        //public ProjectContract? projectContract { get; set; }
    }
}
