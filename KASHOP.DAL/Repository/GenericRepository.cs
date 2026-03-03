using KASHOP.DAL.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace KASHOP.DAL.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<T>> GetAll(string[]? includes = null, CancellationToken cancellationToken = default)
        {
            IQueryable<T> query = _context.Set<T>();
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            return await query.ToListAsync(cancellationToken);
        }

        public async Task<T?> GetOne(Expression<Func<T, bool>> filter, string[]? includes = null, CancellationToken cancellationToken = default)
        {
            IQueryable<T> query = _context.Set<T>();
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            return await query.FirstOrDefaultAsync(filter, cancellationToken);
        }


        public async Task<T> Create(T entity, CancellationToken cancellationToken = default)
        {
            await _context.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return entity;
        }
    }
}
