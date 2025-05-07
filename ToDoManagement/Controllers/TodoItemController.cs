using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoManagement.Abstractions;
using ToDoManagement.Dto;
using ToDoManagement.Dto.TodoItem;

namespace ToDoManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemController : ControllerBase
    {
        private readonly ITodoItemService _todoItemService;

        public TodoItemController(ITodoItemService todoItemService)
        {
            _todoItemService = todoItemService;
        }

        [HttpGet("GetAllTodo")]
        public ActionResult<ResponseModel<List<TodoItemDto>>> GetAllTodo([FromQuery]RequestModel requestModel)
        => Ok(_todoItemService.Get(requestModel));

        [HttpPost("AddTodo")]
        public async Task<ActionResult<ResponseModel<TodoItemDto>>> AddTodo([FromBody] AddTodoItemDto addTodoItemDto)
          => Ok(await _todoItemService.Add(addTodoItemDto));

        [HttpPut("UpdateTodo")]
        public async Task<ActionResult<ResponseModel<TodoItemDto>>> UpdateTodo([FromBody] UpdateTodoItemDto updateTodoItemDto)
          => Ok(await _todoItemService.Update(updateTodoItemDto));

        [HttpDelete("DeleteTodo")]
        public async Task<ActionResult<ResponseModel<string>>> DeleteTodo(int id)
          => Ok(await _todoItemService.Delete(id));
    }
}
