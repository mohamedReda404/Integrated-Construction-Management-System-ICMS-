namespace Integrated_Construction_Management_System_ICMS.Contracts.Requests
{
    public record InvoiceItemRequest
    (
        int InvoiceId,
        int Previous_qty,
        int Current_qty,
        long Total_qty,
        int Rate,
        long Amount
    );
}