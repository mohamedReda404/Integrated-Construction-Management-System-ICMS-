namespace Integrated_Construction_Management_System_ICMS.Models
{
    public class SubContractor
    {
        public int SubContractorId { get; set; }
        public string SubContractorName { get; set; } = string.Empty;
        public string SubContractorEmail { get; set; } = string.Empty;
        public string SubContractorPhone { get; set; } = string.Empty;
        public string SubContractorSpeciality { get; set; } = string.Empty;
        public ICollection<Store>? Stores { get; set; }

        public ICollection<ProjectSubContractor> ProjectSubContractors { get; set; }

    }
}
