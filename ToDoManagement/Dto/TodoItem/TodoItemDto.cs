using System.ComponentModel.DataAnnotations;
using ToDoManagement.Enum;

namespace ToDoManagement.Dto.TodoItem
{
    public class TodoItemDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public bool IsCompleted { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string? Description { get; set; }
        [Required]
        public TodoStatus Status { get; set; } = TodoStatus.Pending;
        [Required]
        public TodoPriority Priority { get; set; } = TodoPriority.Medium;
        public DateTime? DueDate { get; set; }
        public DateTime LastModifiedDate { get; set; } = DateTime.UtcNow;
    }
}
