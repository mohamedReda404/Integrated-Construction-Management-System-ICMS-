namespace Integrated_Construction_Management_System_ICMS.Authentication
{
    public interface IJwtProvider
    {
        (string token, int expirsIn) GenerateToken(ApplicationUser user);
    }
}
