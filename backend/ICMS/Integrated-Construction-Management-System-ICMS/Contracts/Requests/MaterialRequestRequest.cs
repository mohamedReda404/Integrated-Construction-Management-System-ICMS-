namespace Integrated_Construction_Management_System_ICMS.Contracts.Requests
{
    public record MaterialRequestRequest
    ( 
         int ProjectId, 
         string ApplicationUserId,
         string Title,
         string Description,
         string Status,
         string Notes,
         DateOnly RequestDate,    
         DateOnly RequiredDate
    );
}
