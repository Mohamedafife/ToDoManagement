using Microsoft.EntityFrameworkCore;
using ToDoManagement.Models;

namespace ToDoManagement.Dbcontext
{
    public class TodoManagementDbContext : DbContext
    {
        public TodoManagementDbContext(DbContextOptions<TodoManagementDbContext> options)
           : base(options)
        {
            Console.WriteLine("\n******************************************** new ********************************************\n");
        }
        public DbSet<TodoItem> todoItems { get; set; }
    }
}
