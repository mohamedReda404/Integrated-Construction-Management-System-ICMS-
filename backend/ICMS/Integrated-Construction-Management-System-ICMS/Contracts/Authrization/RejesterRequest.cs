namespace Integrated_Construction_Management_System_ICMS.Contracts.Authrization
{
    public record RejesterRequest
    (
        string Email,
        string Password,
        string FullName
        );
}
