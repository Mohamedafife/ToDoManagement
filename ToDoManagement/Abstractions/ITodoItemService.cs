using ToDoManagement.Dto;
using ToDoManagement.Dto.TodoItem;

namespace ToDoManagement.Abstractions
{
    public interface ITodoItemService
    {
        ResponseModel<List<TodoItemDto>> Get(RequestModel requestModel);
        Task<ResponseModel<string>> Delete(int id);
        Task<ResponseModel<TodoItemDto>> Add(AddTodoItemDto addCityDto);
        Task<ResponseModel<TodoItemDto>> Update(UpdateTodoItemDto updateCityDto);
        public Task<ResponseModel<string>> MarkAsComplete(int id);
    }
}
