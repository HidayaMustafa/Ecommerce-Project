using KASHOP.DAL.Data;
using KASHOP.DAL.Models;
namespace KASHOP.DAL.Repository
{
    public class CategoryRepository : GenericRepository<Category>,ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
        } 
    }
}
