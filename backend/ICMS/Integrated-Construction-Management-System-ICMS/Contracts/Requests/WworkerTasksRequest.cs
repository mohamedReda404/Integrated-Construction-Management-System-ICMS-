namespace Integrated_Construction_Management_System_ICMS.Contracts.Requests
{
    public record WworkerTasksRequest
   (
        int ProjectId,
        string AppliactionUserId,
        string Title,
        string Decription,
        string Quantity,
        string Notes,
        DateTime Date
        );
}
