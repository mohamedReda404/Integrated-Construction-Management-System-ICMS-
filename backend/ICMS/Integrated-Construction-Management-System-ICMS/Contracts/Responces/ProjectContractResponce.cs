namespace Integrated_Construction_Management_System_ICMS.Contracts.Responces
{
    public record ProjectContractResponce
    (
        int ProjectContractId,
        DateTime ContractDate,
        string ContractDetails,
        string EndContractIfs,
        string ClientCondition,
        string ClientSignature,
        string ManagerSignature,
        string ManagerCondition
        );
}
