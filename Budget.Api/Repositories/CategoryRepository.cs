using BudgetApp.Repositories.Contracts;
using BudgetApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using BudgetApp.Data;

namespace BudgetApp.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly BudgetContext _context;

        public CategoryRepository(BudgetContext context)
        {
            _context = context;
        }

        public async Task <IEnumerable<Category>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync();
        }
    }
}
