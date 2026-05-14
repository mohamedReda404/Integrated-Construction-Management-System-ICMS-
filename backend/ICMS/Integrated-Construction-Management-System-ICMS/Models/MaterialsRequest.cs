
namespace Integrated_Construction_Management_System_ICMS.Models
{
    public class MaterialsRequest
    {
        public int Id { get; set; }
        public int ProjectId {  get; set; }
        public string ApplicationUserId { get; set; } = string.Empty;
        public string Title {  get; set; }=string.Empty;
        public string Description {  get; set; }=string.Empty;
        public string Status {  get; set; }=string.Empty;
        public string Notes {  get; set; }=string.Empty;
        public DateOnly RequestDate { get; set; }
        public DateOnly RequiredDate { get; set; }
        public ApplicationUser? ApplicationUser { get; set; }
        public Project? project { get; set; }
    }
}
