namespace Integrated_Construction_Management_System_ICMS.Contracts.Requests
{
    public record DrawingRequest
    (
        string Title,
        string Description,
        string Section,
        string Status,
        string Type,
        DateOnly Date,
        string Photo,
        int ProjectId,
        string ApplicationUserId
    );
}