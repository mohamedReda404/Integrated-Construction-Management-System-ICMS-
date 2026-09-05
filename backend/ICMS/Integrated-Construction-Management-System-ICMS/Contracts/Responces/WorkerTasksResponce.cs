namespace Integrated_Construction_Management_System_ICMS.Contracts.Responces
{
    public record WorkerTasksResponce
    (
        int Id,
        int ProjectId,
        string AppliactionUserId,
        string Title,
        string Decription,
        string Quantity,
        string Notes,
        DateTime Date
        );
}
