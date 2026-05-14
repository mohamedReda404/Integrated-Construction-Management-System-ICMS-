namespace Integrated_Construction_Management_System_ICMS.Contracts.Requests
{
    public record ProjectContractRequest
     (
        string Name,
        int ProjectId,
        DateTime Duration,
        DateOnly Date,
        string RetentionPercentage,
        string AdvancePayment,
        long Value,
        byte[]? File
        );
}
