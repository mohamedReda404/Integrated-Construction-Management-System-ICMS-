namespace Integrated_Construction_Management_System_ICMS.Contracts.Requests
{
    public record AddMembersRequest
    (
    string Email,
    string PermissionNumber,
    string FirstName,
    string LastName,
    string Section,
    string Role
    );
}
