using System.ComponentModel.DataAnnotations;

namespace Integrated_Construction_Management_System_ICMS.Models
{
    public class Foreman
    {
        [Key]
        public int ForemanId { get; set; }
        [Required,MaxLength(50)]
        public string Name { get; set; }= string.Empty;
        [Required, MaxLength(11)]
        public string Phone { get; set; }=string.Empty;
        [Required, MaxLength(50)]
        public string Email { get; set; }=string.Empty;

        public ICollection<Project>? projects { get; set; }
        public ICollection<FormanTasks>? formanTasks { get; set; }
    }
}
