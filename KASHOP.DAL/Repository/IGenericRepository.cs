using System.Linq.Expressions;

namespace KASHOP.DAL.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<List<T>> GetAll(string[]? includes, CancellationToken cancellationToken);
        Task<T> Create(T entity, CancellationToken cancellationToken);
        Task<T?> GetOne(Expression<Func<T, bool>> filter, string[]? includes, CancellationToken cancellationToken);
    }
}
