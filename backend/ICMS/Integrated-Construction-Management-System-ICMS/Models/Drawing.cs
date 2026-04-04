
namespace Integrated_Construction_Management_System_ICMS.Models
{
    public class Drawing
    {
        public int Id { get; set; } 
        public string ApplicationUserId { get; set; } =string.Empty;
        public int ProjectId { get; set; } 
        public string Title {  get; set; }=string.Empty;
        public string Description {  get; set; }=string.Empty;
        public string Section {  get; set; }=string.Empty;
        public string Status {  get; set; }=string.Empty;
        public string Type {  get; set; }=string.Empty;
        public DateOnly Date {  get; set; }
        public byte[] ?Photo {  get; set; }

        public ApplicationUser? ApplicationUser { get; set; }
        public Project? project { get; set; }
    }
}
