namespace Integrated_Construction_Management_System_ICMS.Authentication
{
    public interface IJwtProvider
    {
        (string token, int expiresIn) GenerateToken(ApplicationUser user);
        string? ValidateToken(string token);
    }
}
