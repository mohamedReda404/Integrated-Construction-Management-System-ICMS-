namespace Integrated_Construction_Management_System_ICMS.Contracts.Requests
{
    public record LoginMemberRequest
     (
        string Email,
        string PermissionNumber,
        string Section
        );
}
