using ToDoManagement.Enum;

namespace ToDoManagement.Dto
{
    public class RequestModel
    {
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 20;
        public TodoStatus Status { get; set; }
    }
}
