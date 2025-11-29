namespace Integrated_Construction_Management_System_ICMS.Models
{
    public class ProjectSubContractor
    {
        public int ProjectSubContractorId { get; set; }
        public int ProjectId { get; set; }
        public Project? Project { get; set; }
        public int SubContractorId { get; set; }
        public SubContractor? SubContractor { get; set; }
    }
}
