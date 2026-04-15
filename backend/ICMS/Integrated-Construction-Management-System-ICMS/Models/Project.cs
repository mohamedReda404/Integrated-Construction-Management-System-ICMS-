

namespace Integrated_Construction_Management_System_ICMS.Models
{
    public class Project
    {

        //========================ProjectINFO=========================
       
        public int  Id { get; set; }
        public string  Name { get; set; }=string.Empty; 
        public string  Location { get; set; }= string.Empty;
        public string Descritpion { get; set; }= string.Empty;
        public string  Category { get; set; }= string.Empty;
        public string  ClientName { get; set; }= string.Empty;
        public int  ContractValue { get; set; }
        public string Photourl { get; set; } = string.Empty;
        public DateOnly  StartDate { get; set; }
        public DateOnly EndDate { get; set; }

       public ProjectContract? projectContract { get; set; }
       public List<ProjectApplicationUser>? projectApplicationUser { get; set; }
       public List<BOQ>? bOQ { get; set; }
       public List<Drawing>? brawing { get; set; }
       public List<Invoice>? Invoice { get; set; }
       public List<MaterialsRequest>? materialsRequest { get; set; }
        

    }
}
