using AutoMapper;
using BudgetApp.Models;
using BudgetApp.Data.Entities;


namespace BudgetApp.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryModel>();
        }
    }
}
