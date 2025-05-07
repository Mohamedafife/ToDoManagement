using System.ComponentModel.DataAnnotations;

namespace ToDoManagement.Dto.TodoItem
{
    public class UpdateTodoItemDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public bool? IsCompleted { get; set; } = false;
        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
