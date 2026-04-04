namespace Integrated_Construction_Management_System_ICMS.Contracts.Responces
{
    public record BOQResponce
    (
        int Id,
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
