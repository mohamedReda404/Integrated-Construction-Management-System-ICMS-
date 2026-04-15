
namespace Integrated_Construction_Management_System_ICMS.Models
{
    public class ProjectContract
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string Name { get; set; }=string.Empty;
        public DateTime Duration { get; set; }
        public DateOnly Date { get; set; }
        public string RetentionPercentage { get; set; }=string.Empty;
        public string AdvancePayment { get; set; }=string.Empty;
        public long Value { get; set; }
        public byte[] ?File { get; set; }
        public Project? project { get; set; }
        //public List<ApplicationUser>?ApplicationUsers { get; set; }

    }
}
