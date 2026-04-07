namespace Integrated_Construction_Management_System_ICMS.Contracts.Responses
{
    public record DrawingResponse
    (
        int Id,
        string Title,
        string Description,
        string Section,
        string Status,
        string Type,
        DateOnly Date,
        byte[]? Photo,
        int ProjectId,
        string ApplicationUserId
    );
}