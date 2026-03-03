using KASHOP.DAL.DTO.Request;
using KASHOP.DAL.DTO.Response;
using KASHOP.DAL.Models;
using System.Linq.Expressions;

namespace KASHOP.BLL.Services
{
    public interface ICategoryService
    {
        Task<List<CategoryResponse>> GetAll(CancellationToken cancellationToken);
        Task<CategoryResponse> Create(CategoryRequest request, CancellationToken cancellationToken);
        Task<CategoryResponse?> GetCategory(Expression<Func<Category, bool>> filter, CancellationToken cancellationToken);
    }
}
