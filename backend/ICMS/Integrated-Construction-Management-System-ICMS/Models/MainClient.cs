namespace Integrated_Construction_Management_System_ICMS.Models
{
    public class MainClient
    {
        public int MainClientId { get; set; }
        public string MainClientName { get; set; } = string.Empty;
        public int MainClientPhone { get; set; }
        public string MainClintEmail { get; set; } = string.Empty;
        public int MainClientNationalId { get; set; }
        
        public ICollection<ProjectContract> ProjectContracts { get; set; }
        

    }
}
