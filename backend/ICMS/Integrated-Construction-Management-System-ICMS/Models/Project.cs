using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Integrated_Construction_Management_System_ICMS.Models
{
    public class Project
    {
        [Key]
        public int  ProjectID { get; set; }
        [Required,MaxLength(100)]
        public string  ProjectName { get; set; }=string.Empty; 
        [Required,MaxLength(200)]
        public string  ProjectLocation { get; set; }= string.Empty;
        [Required,MaxLength(500)]
        public string  ProjectDescritpion { get; set; }= string.Empty;


        [Required,ForeignKey("MainClientID")]
        public  int MainClientID { get; set; }
        public MainClient? _mainclinet { get; set; }



        [Required, ForeignKey("ProjectManagerID")]
        public int ProjectManagerID { get; set; }
        public ProjectManager? _ProjectManager { get; set; }



        [Required, ForeignKey("FormanID")]
        public int FormanID { get; set; }
        public Foreman? _foreman {  get; set; }
       
        public Store? _Store { get; set; }
        public ProjectContract? _PrjectContract {  get; set; }
        public ProjectContract? _ProjectContract { get; set; }
        public MainConsultant? _mainConsultant { get; set; }
        public ICollection<ProjectSubContractor>? ProjectSubContractors { get; set; }


    }
}
