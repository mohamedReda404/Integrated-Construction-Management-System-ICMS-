using Microsoft.AspNetCore.Identity;

namespace Integrated_Construction_Management_System_ICMS.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string Jobtitle {  get; set; }=string.Empty;
    }
}
