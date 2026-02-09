namespace Integrated_Construction_Management_System_ICMS.Contracts.Responces
{
    public record ProjectResponce
    (
         string ProjectName,
        string ProjectLocation,
        string ProjectDescritpion,
         int MainClientID,
         int ProjectManagerId,
         int ForemanId
        );
}
