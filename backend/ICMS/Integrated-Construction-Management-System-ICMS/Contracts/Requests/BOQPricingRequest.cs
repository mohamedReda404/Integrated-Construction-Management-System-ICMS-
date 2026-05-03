namespace Integrated_Construction_Management_System_ICMS.Contracts.Requests
{
    public record BOQPricingRequest
    (
         int BOQId,
         string Title,
         string Description,
         string Status,
         string UnitRate,
         long TotalPrice,
         DateOnly Date
    );
}
