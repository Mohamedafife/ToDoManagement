using System.ComponentModel.DataAnnotations;
using ToDoManagement.Dto.TodoItem;
using ToDoManagement.Enum;

namespace ToDoManagement.Models
{
    public class TodoItem
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
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

        public void Update(UpdateTodoItemDto updateTodoItemDto)
        {
            Title = updateTodoItemDto.Title ?? Title;
            IsCompleted = updateTodoItemDto.IsCompleted ?? IsCompleted;
            CreatedAt = updateTodoItemDto.CreatedAt ?? CreatedAt;
            Description = updateTodoItemDto.Description ?? Description;
            Status = updateTodoItemDto?.Status ?? Status;
            Priority = updateTodoItemDto?.Priority ?? Priority;
            DueDate = updateTodoItemDto?.DueDate ?? DueDate;
            LastModifiedDate = updateTodoItemDto?.LastModifiedDate ?? LastModifiedDate;
        }

    }
}
