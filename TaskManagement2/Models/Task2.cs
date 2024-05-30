using System.ComponentModel.DataAnnotations;

namespace TaskManagement2.Data
{
    public class Task2
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public bool isCompleted { get; set; }

    }
}
