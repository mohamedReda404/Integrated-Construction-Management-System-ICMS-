namespace Integrated_Construction_Management_System_ICMS.Contracts.Responses
{
    public record InvoiceResponse
    (
        int Id,
        int ProjectId,
        string Title,
        string Type,
        string Status,
        DateOnly PeriodFrom,
        DateOnly PeriodTo,
        DateOnly InvoiceDate,
        long TotalAmount
    );
}