namespace Integrated_Construction_Management_System_ICMS.Contracts.Authrization
{
    public record Authresponce
    (
        string Id,
        string Email,
        string Token,
        int ExpiresIn
        );
}
