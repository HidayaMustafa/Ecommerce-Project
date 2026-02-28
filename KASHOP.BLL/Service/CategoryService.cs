using KASHOP.DAL.DTO.Request;
using KASHOP.DAL.DTO.Response;
using KASHOP.DAL.Models;
using KASHOP.DAL.Repository;
using Mapster;

namespace KASHOP.BLL.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepo) 
        {
            _categoryRepository = categoryRepo;
        }

        public async Task<List<CategoryResponse>> GetAll(CancellationToken cancellationToken)
        {
            var categories = await _categoryRepository.GetAll(cancellationToken);

            return categories.Adapt<List<CategoryResponse>>();
        }

        public async Task<CategoryResponse> Create(CategoryRequest request, CancellationToken cancellationToken)
        {
            var category = request.Adapt<Category>();

            await _categoryRepository.Create(category,cancellationToken);

            return category.Adapt<CategoryResponse>();
        }
    }
}
