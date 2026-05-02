namespace Integrated_Construction_Management_System_ICMS.Contracts.Requests
{
    public record InvoiceRequest
    (
        int ProjectId,
        string ApplicationUserId,
        string Title,
        string Type,
        string Status,
        DateOnly PeriodFrom,
        DateOnly PeriodTo,
        DateOnly InvoiceDate,
        long TotalAmount,
        string File
    );
}