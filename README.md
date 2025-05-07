# Todo Management API

## How to run the project
1. Clone the repository to your local machine.
2. Open the solution in Visual Studio or VS Code.
3. Run the `Todo.Api` project for the API and `Todo.Mvc` project for the frontend (MVC).
4. Make sure SQL Server is running, and the connection string is set in `appsettings.json`.

## Setup requirements
- .NET 6 SDK
- SQL Server (or SQL Express)
- Entity Framework Core for database migrations

## What I managed to complete
- **TodoItemController**
  - `GET /GetAllTodo`: Returns a list of all todo items (`List<TodoItemDto>`)
  - `POST /AddTodo`: Accepts `AddTodoItemDto` and creates a new todo item
  - `PUT /UpdateTodo`: Accepts `UpdateTodoItemDto` and updates an existing item
  - `DELETE /DeleteTodo?id=`: Takes an `id` and deletes the corresponding item

- **Service Layer**
  - Implemented `ITodoItemService` to handle business logic
  - All methods return a `ResponseModel<T>` with either data or an error message
  - **Pagination**: Implemented simple pagination using `PageIndex` and `PageSize` parameters in the `Get()` method
  - **Caching**: Used in-memory caching (`IMemoryCache`) to store and retrieve todo list data to reduce database calls and improve performance

- **DTOs**
  - Used `AddTodoItemDto`, `UpdateTodoItemDto`, and `TodoItemDto` to structure request and response data

- **Validation**
  - Used Data Annotations like `[Required]`, `[MaxLength]` in DTOs for input validation

- **Database**
  - Integrated with SQL Server using Entity Framework Core
  - Created one migration: `InitialCreate`

- **Swagger**
  - Enabled Swagger UI for easy API testing

## What I found challenging
- Time management and ensuring the API and MVC frontend worked seamlessly together.



