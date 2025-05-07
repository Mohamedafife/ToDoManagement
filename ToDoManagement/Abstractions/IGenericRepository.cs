using System.Linq.Expressions;

namespace ToDoManagement.Abstractions
{
    public interface IGenericRepository<T> where T : class
    {
        Task Add(T entity);
        IReadOnlyList<T> Get();
        Task<T?> GetById(params object[] idValues);
        void Delete(T entity);
        void Update(T entity);
        Task<bool> Save();
    }
}
