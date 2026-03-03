using KASHOP.BLL.Services;
using KASHOP.DAL.DTO.Request;
using KASHOP.PL.Resourses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace KASHOP.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IStringLocalizer<SharedResource> _localizer;
        private readonly ICategoryService _categoryService;
        public CategoriesController
            (
            IStringLocalizer<SharedResource> localizer ,
            ICategoryService categoryService
            )
        {
            _localizer = localizer;
            _categoryService = categoryService;
        }


        [HttpGet]
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var categories = await _categoryService.GetAll(cancellationToken);

            return Ok(new
            {
                message = _localizer["Success"].Value,
                categories
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id , CancellationToken cancellationToken)
        {
            var category = await _categoryService.GetCategory((c => c.Id == id), cancellationToken);

            return Ok(new
            {
                message = _localizer["Success"].Value,
                category
            });
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetByName(string name, CancellationToken cancellationToken)
        {
            var category = await _categoryService.GetCategory((
                c => c.Translations.Any(t => t.Name == name)), 
                cancellationToken);

            return Ok(new
            {
                message = _localizer["Success"].Value,
                category
            });
        }


        [HttpPost("")]
        public async Task<IActionResult> Create(CategoryRequest request, CancellationToken cancellationToken)
        {
            var response = await _categoryService.Create(request,cancellationToken);

            return Ok(new
            {
                message= _localizer["Success"].Value,
                response
            });
        }


    }
}
