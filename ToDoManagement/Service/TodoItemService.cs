using MapsterMapper;
using Microsoft.Extensions.Caching.Memory;
using ToDoManagement.Abstractions;
using ToDoManagement.Dto;
using ToDoManagement.Dto.TodoItem;
using ToDoManagement.Models;

namespace ToDoManagement.Service
{
    public class TodoItemService : ITodoItemService
    {
        private readonly IGenericRepository<TodoItem> _todoItemRepo;
        private readonly ILogger<TodoItem> _logger;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memoryCache;

        public TodoItemService(IGenericRepository<TodoItem> todoItemRepo , ILogger<TodoItem> logger , IMapper mapper , IMemoryCache memoryCache)
        {
            _todoItemRepo = todoItemRepo;
            _logger = logger;
            _mapper = mapper;
            _memoryCache = memoryCache;
        }

        public async Task<ResponseModel<TodoItemDto>> Add(AddTodoItemDto addCityDto)
        {
            try
            {
                var mapp = _mapper.Map<TodoItem>(addCityDto);

                await _todoItemRepo.Add(mapp);

                await _todoItemRepo.Save();

                return ResponseModel<TodoItemDto>.Success(_mapper.Map<TodoItemDto>(mapp));
            }
            catch (Exception ex) { _logger.Log(LogLevel.Error, ex.ToString()); }

            return ResponseModel<TodoItemDto>.Error();
        }

        public async Task<ResponseModel<string>> Delete(int id)
        {
            try
            {
                var todo = await _todoItemRepo.GetById(id);

                if (todo == null)
                    return ResponseModel<string>.Error("Not Found");

                _todoItemRepo.Delete(todo);

                await _todoItemRepo.Save();

                return ResponseModel<string>.Success();
            }
            catch (Exception ex) { _logger.Log(LogLevel.Error, ex.ToString()); }

            return ResponseModel<string>.Error();
        }

        public ResponseModel<List<TodoItemDto>> Get(RequestModel requestModel)
        {
            try
            {
               
                    string cacheKey = $"TodoList_Page_{requestModel.PageIndex}_Size_{requestModel.PageSize}";

                    if (_memoryCache.TryGetValue(cacheKey, out List<TodoItemDto> cachedList))
                    {
                        return ResponseModel<List<TodoItemDto>>.Success(cachedList);
                    }

                    var todolist = _todoItemRepo.Get().AsQueryable();

                    var paginatedList = todolist
                        .Skip((requestModel.PageIndex - 1) * requestModel.PageSize)
                        .Take(requestModel.PageSize)
                        .ToList();

                    var mapped = _mapper.Map<List<TodoItemDto>>(paginatedList);

                    _memoryCache.Set(cacheKey, mapped, TimeSpan.FromMinutes(5));

                    _todoItemRepo.Save();
            }
            catch (Exception ex) { _logger.Log(LogLevel.Error, ex.ToString()); }

            return ResponseModel<List<TodoItemDto>>.Error();
        }

        public async Task<ResponseModel<TodoItemDto>> Update(UpdateTodoItemDto updateCityDto)
        {
            try
            {
                try
                {
                    var todo = await _todoItemRepo.GetById(updateCityDto.Id);

                    if (todo == null)
                        return ResponseModel<TodoItemDto>.Error("Not Found");

                    todo!.Update(updateCityDto);

                    _todoItemRepo.Update(todo);

                    await _todoItemRepo.Save();

                    return ResponseModel<TodoItemDto>.Success(_mapper.Map<TodoItemDto>(todo));
                }
                catch (Exception ex) { _logger.Log(LogLevel.Error, ex.ToString()); }

                return ResponseModel<TodoItemDto>.Error();
            }
            catch (Exception ex) { _logger.Log(LogLevel.Error, ex.ToString()); }

            return ResponseModel<TodoItemDto>.Error();
        }
    }
}
