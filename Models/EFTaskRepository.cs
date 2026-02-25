namespace Mission08_3_2.Models
{
    public class EFTaskRepository : ITaskRepository
    {
        private TaskContext _context;

        public EFTaskRepository(TaskContext temp)
        {
            _context = temp;
        }

        public IQueryable<TaskItem> Tasks => _context.Tasks;
        public IQueryable<Category> Categories => _context.Categories;

        public void AddTask(TaskItem task)
        {
            _context.Add(task);
            _context.SaveChanges();
        }

        public void UpdateTask(TaskItem task)
        {
            _context.Update(task);
            _context.SaveChanges();
        }

        public void DeleteTask(TaskItem task)
        {
            _context.Remove(task);
            _context.SaveChanges();
        }
    }
}
