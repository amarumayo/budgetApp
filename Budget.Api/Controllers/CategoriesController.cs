using BudgetApp.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Budget.Api.Controllers
{
    public class CategoriesController : ControllerBase
    {

        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService service)
        {
            _categoryService = service;
            
        }
        [HttpGet]

        public Task <IActionResult> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
