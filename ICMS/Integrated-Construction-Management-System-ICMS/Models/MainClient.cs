using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Integrated_Construction_Management_System_ICMS.Models
{
    public class MainClient
    {
        [Key]
        public int MainClientId { get; set; }
        public string MainClientName { get; set; } 
        public int MainClientPhone { get; set; }
        public string MainClintEmail { get; set; } 
        public int MainClientNationalId { get; set; }
        
        public List<ProjectContract> ProjectContracts { get; set; }
        

    }
}
