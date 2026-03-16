using BudgetApp.Repositories.Contracts;
using BudgetApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using BudgetApp.Data;

namespace BudgetApp.Repositories
{
    public class CategoryRepository
    : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(BudgetContext context) : base(context) { }

        public async Task<Category?> GetByNameAsync(string name) =>
            await _dbSet.FirstOrDefaultAsync(c => c.Name == name);
    }

}
