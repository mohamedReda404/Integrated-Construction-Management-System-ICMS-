namespace Integrated_Construction_Management_System_ICMS.Models
{
    public class WorkerTasks
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string AppliactionUserId { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Decription { get; set; } = string.Empty;
        public string Quantity { get; set; } = string.Empty;
        public string Unit { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
        public int TotalPrice { get; set; } 
        public DateTime StartDate { get; set; }
        public DateTime StartEnd { get; set; }

        public ApplicationUser? ApplicationUser { get; set; }
        public Project? project { get; set; }
    }
}
