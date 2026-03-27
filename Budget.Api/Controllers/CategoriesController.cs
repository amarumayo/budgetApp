using BudgetApp.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace BudgetApp.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {

        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService service)
        {
            _categoryService = service;

        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            return Ok(categories);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }


        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteCategoryById(int id)
        {
            var deleteSuccess = await _categoryService.DeleteCategoryAsync(id);

            if (!deleteSuccess)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
