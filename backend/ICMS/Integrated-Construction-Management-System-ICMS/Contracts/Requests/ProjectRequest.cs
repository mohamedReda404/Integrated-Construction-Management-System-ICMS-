namespace Integrated_Construction_Management_System_ICMS.Contracts.Requests
{
    public record ProjectRequest
    (
        string Name,
        string Location,
        string Descritpion, 
        string Category,
        string ClientName,
        int ContractValue,
        string Photo,
        DateOnly StartDate, 
        DateOnly EndDate 
        );
}


