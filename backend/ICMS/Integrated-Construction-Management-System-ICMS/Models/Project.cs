

namespace Integrated_Construction_Management_System_ICMS.Models
{
    public class Project
    {

        //========================ProjectINFO=========================
        [Key]
        public int  ProjectID { get; set; }
        [Required,MaxLength(100)]
        public string  ProjectName { get; set; }=string.Empty; 
        [Required,MaxLength(200)]
        public string  ProjectLocation { get; set; }= string.Empty;
        [Required,MaxLength(500)]
        public string  ProjectDescritpion { get; set; }= string.Empty;



        //======================ProjectRelations(M:1)===========================
        [Required,ForeignKey("MainClientID")]
        public  int MainClientID { get; set; }
        public MainClient? _mainclinet { get; set; }


     
        [Required, ForeignKey("ProjectManagerID")]
        public int ProjectManagerID { get; set; }
        public ProjectManager? _ProjectManager { get; set; }



        [Required, ForeignKey("FormanID")]
        public int FormanID { get; set; }
        public Foreman? _foreman {  get; set; }



        [Required, ForeignKey("MainCosultantID")]
        public int MainCosultantID { get; set; }
        public MainConsultant? _mainConsultant { get; set; }

        
        //===========================ProjectRelationships(1:M)====================
        public List<FormanTasks>? formanTasks {  get; set; }
        public List<ProjectSubContractor>? projectSubContractors { get; set; }
        public List<ProjectSiteEngineer>? projectsiteEngineer { get; set; }
        public List<EngineerBoq>? engineerBoq { get; set; }
        public List<SubConstractorInvoice>? subConstractorInvoice { get; set; }
        public List<EngineerInvoice>? engineerInvoice { get; set; }
        public List<ShopDrawing>? shopDrawing { get; set; }
        public List<ProjectSubConsultant>? projectSubConsultant { get; set; }
        public List<GeneralDrowing>? generalDrowing { get; set; }
        public List<ConsultantBoq>? consultantBoq { get; set; }



        //======================================ProjectRealtinship (1:1)=============
        public ProjectContract? prjectContract { get; set; }
        public Store? store { get; set; }
       
       
       


    }
}
