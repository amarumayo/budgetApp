using BudgetApp.Repositories.Contracts;
using BudgetApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using BudgetApp.Data;

namespace BudgetApp.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(BudgetContext context) : base(context) { }
        
    }

}
