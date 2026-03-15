using AutoMapper;
using BudgetApp.Repositories.Contracts;
using BudgetApp.Services.Contracts;
using BudgetApp.Models;

namespace BudgetApp.Services
{
    public class CategoryService : ICategoryService
    {

        private readonly ICategoryRepository _repo;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public Task<IEnumerable<CategoryModel>> GetAllCategoriesAsync() 
        {
            throw new NotImplementedException();

        }
    }
}
