namespace Integrated_Construction_Management_System_ICMS.Models
{
    public class FormanTasks
    {

        public int TaskID { get; set; }
        public string TaskName { get; set; }=string.Empty;
        public string Description { get; set; }=string.Empty;
        public string Type { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public int ProjectID { get; set; }

     

    }
}
