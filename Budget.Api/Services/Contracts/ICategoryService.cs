using BudgetApp.Models;

namespace BudgetApp.Services.Contracts
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryModel>> GetAllCategoriesAsync();

        Task<CategoryModel?> GetCategoryByIdAsync(int id);
    }
}
