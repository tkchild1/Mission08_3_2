namespace Mission08_3_2.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;

        public ICollection<TaskItem> Tasks { get; set; } = new List<TaskItem>();
    }
}
