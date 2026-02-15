namespace Integrated_Construction_Management_System_ICMS.Contracts.Requests
{
    public record ProjectContractRequest
    (
        DateTime ContractDate,
        string ContractDetails,
        string EndContractIfs,
        string ClientCondition,
        string ClientSignature,
        string ManagerSignature,
        string ManagerCondition
        );
}
