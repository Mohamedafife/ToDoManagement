using System.ComponentModel.DataAnnotations;
using ToDoManagement.Enum;

namespace ToDoManagement.Dto.TodoItem
{
    public class AddTodoItemDto
    {
        public string? Title { get; set; }
        public bool IsCompleted { get; set; } = false;
        public string? Description { get; set; }
        [Required]
        public TodoStatus Status { get; set; } = TodoStatus.Pending;
        [Required]
        public TodoPriority Priority { get; set; } = TodoPriority.Medium;
        public DateTime? DueDate { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime LastModifiedDate { get; set; } = DateTime.UtcNow;
    }
}
