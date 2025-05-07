using System.ComponentModel.DataAnnotations;

namespace ToDoManagement.Dto.TodoItem
{
    public class AddTodoItemDto
    {
        public string? Title { get; set; }
        public bool IsCompleted { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
