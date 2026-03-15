using BudgetApp.Data.Entities;

namespace BudgetApp.Repositories.Contracts
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllAsync();
    }
}
