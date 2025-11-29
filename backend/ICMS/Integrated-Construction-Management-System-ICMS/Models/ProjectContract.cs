namespace Integrated_Construction_Management_System_ICMS.Models
{
    public class ProjectContract
    {
        public int ProjectContractId { get; set; }
        public DateTime ContractDate { get; set; }
        public string ContractDetails { get; set; } = string.Empty;
        public string EndContractIfs { get; set; } = string.Empty;
        public int ProjectId { get; set; }
         public Project? Project { get; set; }

        public string ProjectManagerName { get; set; } = string.Empty;
        public ProjectManager? ProjectManager { get; set; }

        public string MainClientName { get; set; } = string.Empty;
        public MainClient? MainClient { get; set; }

        public string ClientCondition { get; set; } = string.Empty;
        public string ClientSignature { get; set; } = string.Empty;
    

        public string ManagerSignature { get; set; } = string.Empty;
        public string ManagerCondition { get; set; } = string.Empty;
        


    }
}
