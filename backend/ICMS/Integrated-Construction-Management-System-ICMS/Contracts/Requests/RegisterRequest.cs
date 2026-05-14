namespace Integrated_Construction_Management_System_ICMS.Contracts.Requests
{
    public record RegisterRequest(
     string Email,
     string Password,
     string FirstName,
     string LastName
 );
}
