namespace Integrated_Construction_Management_System_ICMS.Contracts.Requests
{
    public record BOQRequest
    (
        string Title,
        string Description,
        string Condetion,
        string Unit,
        string Section,
        string Quantity,
        string Type,
        DateOnly Date,
        byte[]? File,
        int ProjectId,
        string ApplicationUserId
        );
}
