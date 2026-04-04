namespace Integrated_Construction_Management_System_ICMS.Contracts.Responces
{
    public record ProjectResponce
    (
        int  Id,
        string Name,
        string Location,
        string Descritpion,
        string Category,
        string ClientName,
        int ContractValue,
        byte[] Photo,
        DateOnly StartDate, 
        DateOnly EndDate 
        );
}
