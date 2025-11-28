namespace Integrated_Construction_Management_System_ICMS.Models
{
    public class Project
    {
        public int  ProjectID { get; set; }     
        public string  ProjectName { get; set; }     
        public string  ProjectLocation { get; set; }     
        public string  ProjectDescritpion { get; set; }
        public  int MainClientID { get; set; }
        public int ProjectManagerID { get; set; }
        public int FormanID { get; set; }
        public int StoreId { get; set; }


    }
}
