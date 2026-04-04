namespace Integrated_Construction_Management_System_ICMS.Contracts.Requests
{
    public record MaterialRequestRequest
    {
        public int Id;  
        public int ProjectId;   
        public string ApplicationUserId;
        public string Title;
        public string Description;
        public string Status;
        public string Notes;
        public DateOnly RequestDate;    
        public DateOnly RequiredDate;
        public ApplicationUser? ApplicationUser;
        public Project? project;
    }
}
