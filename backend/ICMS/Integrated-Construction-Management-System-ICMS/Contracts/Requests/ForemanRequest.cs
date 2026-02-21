namespace Integrated_Construction_Management_System_ICMS.Contracts.Requests
{
    public class ForemanRequest
    {
        public string Name { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int ProjectManagerId { get; set; }
    }
}
