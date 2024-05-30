namespace TaskManagement2.Models
{
    public class TaskRequest
    {

        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public bool IsCompleted { get; set; }
    }
}
