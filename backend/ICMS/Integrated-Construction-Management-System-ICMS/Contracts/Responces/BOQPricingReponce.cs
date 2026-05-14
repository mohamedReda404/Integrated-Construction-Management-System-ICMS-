namespace Integrated_Construction_Management_System_ICMS.Contracts.Responces
{
    public record BOQPricingReponce
    (
         int Id,
         int BOQId,
         string Title,
         string Description,
         string Status,
         string UnitRate,
         long TotalPrice,
         DateOnly Date
    );
}
