namespace Integrated_Construction_Management_System_ICMS.Contracts.Requests
{
    public record ProjectRequest
    (
        string ProjectName,
        string ProjectLocation,
        string ProjectDescritpion,
         int MainClientID,
         int ProjectManagerId,
         int ForemanId
        );
}
