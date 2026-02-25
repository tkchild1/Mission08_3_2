using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Mission08_3_2.Models
{
    public class TaskItem
    {
        [Key]
        public int TaskItemId { get; set; }

        [Required(ErrorMessage = "Task name is required")]
        public string TaskName { get; set; } = string.Empty;

        public DateTime? DueDate { get; set; }

        [Required(ErrorMessage = "Quadrant is required")]
        public int Quadrant { get; set; }

        [Required(ErrorMessage = "Category is required")]
        public int CategoryId { get; set; }

        public bool Completed { get; set; } = false;

        [ValidateNever]
        public Category? Category { get; set; }
    }
}
