using KASHOP.DAL.DTO.Request;
using KASHOP.DAL.DTO.Response;
using KASHOP.DAL.Models;
using KASHOP.DAL.Repository;
using Mapster;
using System.Linq.Expressions;

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

            var categories = await _categoryRepository.GetAll(new string[] { nameof(Category.Translations)},cancellationToken);

            return categories.Adapt<List<CategoryResponse>>();
        }


        public async Task<CategoryResponse?> GetCategory(Expression<Func<Category, bool>> filter, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetOne(filter, new string[] { nameof(Category.Translations) } , cancellationToken);

            return category.Adapt<CategoryResponse>();
        }


        public async Task<CategoryResponse> Create(CategoryRequest request, CancellationToken cancellationToken)
        {
            var category = request.Adapt<Category>();

            await _categoryRepository.Create(category,cancellationToken);

            return category.Adapt<CategoryResponse>();
        }
    }
}
