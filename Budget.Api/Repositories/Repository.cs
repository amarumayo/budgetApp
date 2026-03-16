using BudgetApp.Data;
using BudgetApp.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace BudgetApp.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {

        protected readonly BudgetContext _context;
        protected readonly DbSet<T> _dbSet;
        
        public Repository(BudgetContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<T?> GetByIdAsync(int id) =>
            await _dbSet.FindAsync(id);

        public async Task<IEnumerable<T>> GetAllAsync() =>
            await _dbSet.ToListAsync();

        public async Task AddAsync(T entity) =>
            await _dbSet.AddAsync(entity);

        public async Task Update(T entity) =>
            _dbSet.Update(entity);
        
        public async Task Remove(T entity) =>
            _dbSet.Remove(entity);

    }
}
