namespace Integrated_Construction_Management_System_ICMS.Contracts.Responces
{
    public record ProjectContractResponce
    (   int Id,
        int ProjectId,
        string Name,
        DateTime Duration,
        DateOnly Date,
        string RetentionPercentage,
        string AdvancePayment,
        long Value,
        byte[]? File
        );
}
