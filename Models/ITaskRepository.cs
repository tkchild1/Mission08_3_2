namespace Mission08_3_2.Models
{
    public interface ITaskRepository
    {
        IQueryable<TaskItem> Tasks { get; }
        IQueryable<Category> Categories { get; }
        void AddTask(TaskItem task);
        void UpdateTask(TaskItem task);
        void DeleteTask(TaskItem task);
    }
}
