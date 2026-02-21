namespace Integrated_Construction_Management_System_ICMS.Contracts.Responces
{
    public class ForemanResponse
    {
        public int ForemanId { get; set; }
        public string Name { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int ProjectManagerId { get; set; }
    }
}
