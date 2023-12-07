using AutoMapper;
using EatEaze.AdminWebApplication.Models;
using EatEaze.Data.Entities;

namespace EatEaze.AdminWebApplication.Mapper
{
    public class AdminMappingProfile : Profile
    {
        public AdminMappingProfile() 
        {
            CreateMap<CategoriesViewModel, Category>();
            CreateMap<RestarauntsViewModel, Restaraunt>(); 
            CreateMap<PositionsViewModel, Position>();
        }
    }
}
