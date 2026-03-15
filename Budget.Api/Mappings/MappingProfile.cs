using AutoMapper;
using BudgetApp.Models;
using BudgetApp.Data.Entities;


namespace Budget.Api.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryModel>();
        }
    }
}
