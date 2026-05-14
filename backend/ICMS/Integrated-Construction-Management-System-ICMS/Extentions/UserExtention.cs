using System.Security.Claims;

namespace Integrated_Construction_Management_System_ICMS.Extentions
{
    public static class UserExtention
    {
     public static string? GetUserId(this ClaimsPrincipal user) =>
    user.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}
