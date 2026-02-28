using KASHOP.DAL.DTO.Request;
using KASHOP.DAL.DTO.Response;
using KASHOP.DAL.Models;

namespace KASHOP.BLL.Services
{
    public interface ICategoryService
    {
        Task<List<CategoryResponse>> GetAll(CancellationToken cancellationToken);
        Task<CategoryResponse> Create(CategoryRequest request, CancellationToken cancellationToken);
    }
}
