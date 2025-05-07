using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using ToDoManagement.Abstractions;
using ToDoManagement.Dbcontext;

namespace ToDoManagement.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly TodoManagementDbContext _context;
        private DbSet<T> _entity;
        public GenericRepository(TodoManagementDbContext context)
        {
            _context = context;
            _entity = context.Set<T>();
        }

        public async Task Add(T entity) => await _entity.AddAsync(entity);
        
        public void Update(T entity) => _entity.Update(entity);
        
        public void Delete(T entity) => _entity.Remove(entity);
       
        public IReadOnlyList<T> Get() => _entity.AsNoTracking().ToList();
        
        public async Task<T?> GetById(params object[] idValues) => await _entity.FindAsync(idValues);
        
        public async Task<bool> Save() => await _context.SaveChangesAsync() > 0;
    }
}
