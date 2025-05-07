using System.ComponentModel.DataAnnotations;
using ToDoManagement.Dto.TodoItem;

namespace ToDoManagement.Models
{
    public class TodoItem
    {
            public int Id { get; set; }
            [Required]
            [MaxLength(100)]
            public string? Title { get; set; }
            public bool IsCompleted { get; set; } = false;
            public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public void Update(UpdateTodoItemDto updateTodoItemDto)
        {
            Title = updateTodoItemDto.Title ?? Title;
            IsCompleted = updateTodoItemDto.IsCompleted ?? IsCompleted;
            CreatedAt = updateTodoItemDto.CreatedAt ?? CreatedAt;
        }
        
    }
}
