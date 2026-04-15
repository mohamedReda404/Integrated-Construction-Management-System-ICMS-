namespace Integrated_Construction_Management_System_ICMS.Contracts.Responces
{
    public record AuthResponse(
     string Id,
     string? Email,
     string FirstName,
     string LastName,
     string Token,
     int ExpiresIn,
     string RefreshToken,
     DateTime RefreshTokenExpiration
 );
}
