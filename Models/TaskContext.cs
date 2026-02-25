using Microsoft.EntityFrameworkCore;

namespace Mission08_3_2.Models
{
    public class TaskContext : DbContext
    {
        public TaskContext(DbContextOptions<TaskContext> options)
            : base(options)
        {
        }

        public DbSet<TaskItem> Tasks { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Foreign key relationship between Tasks and Categories
            modelBuilder.Entity<TaskItem>()
                .HasOne(t => t.Category)
                .WithMany(c => c.Tasks)
                .HasForeignKey(t => t.CategoryId);

            // Seed Categories
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Home" },
                new Category { CategoryId = 2, Name = "School" },
                new Category { CategoryId = 3, Name = "Work" },
                new Category { CategoryId = 4, Name = "Church" }
            );

            // Seed some Tasks
            modelBuilder.Entity<TaskItem>().HasData(
                new TaskItem { TaskItemId = 1, TaskName = "Pay bills", Quadrant = 1, DueDate = new DateTime(2026, 3, 1), CategoryId = 1, Completed = false },
                new TaskItem { TaskItemId = 2, TaskName = "Study for exam", Quadrant = 1, DueDate = new DateTime(2026, 3, 2), CategoryId = 2, Completed = false },
                new TaskItem { TaskItemId = 3, TaskName = "Plan family vacation", Quadrant = 2, DueDate = null, CategoryId = 1, Completed = false },
                new TaskItem { TaskItemId = 4, TaskName = "Finish project proposal", Quadrant = 2, DueDate = new DateTime(2026, 3, 10), CategoryId = 3, Completed = false },
                new TaskItem { TaskItemId = 5, TaskName = "Reply to emails", Quadrant = 3, DueDate = new DateTime(2026, 3, 3), CategoryId = 3, Completed = false },
                new TaskItem { TaskItemId = 6, TaskName = "Browse social media", Quadrant = 4, DueDate = null, CategoryId = 1, Completed = false }
            );
        }
    }
}
