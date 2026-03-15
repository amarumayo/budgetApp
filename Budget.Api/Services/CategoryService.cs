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

        public async Task<IEnumerable<CategoryModel>> GetAllCategoriesAsync() 
        {
            var entities = await _repo.GetAllAsync();
            var models = _mapper.Map<IEnumerable< CategoryModel>>(entities);
            return models;
        }
    }
}
