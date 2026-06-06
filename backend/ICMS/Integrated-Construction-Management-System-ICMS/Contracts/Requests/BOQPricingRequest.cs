namespace Integrated_Construction_Management_System_ICMS.Contracts.Requests
{
    public record BOQPricingRequest
    (
         
         string Title,
         string Description,
         string Status,
         string UnitRate,
         long TotalPrice,
         DateOnly Date
    );
}
