

namespace Integrated_Construction_Management_System_ICMS.Models
{
    public class MainClient
    {
        //==========Info==========
        [Key]
        public int MainClientID { get; set; }
        [Required, MaxLength(100)]
        public string MainClientName { get; set; } = string.Empty;
        [Required, MaxLength(11)]
        public int MainClientPhone { get; set; }
        [Required]
        public int MainClientNationalId { get; set; }


        //================Relationships(1:M)=========
        public ICollection<Project>? Projects { get; set; }




        //============Relationships(1:1)============
        public ProjectContract? prjectContract { get; set; }

        


    }
}
