using AutoMapper;
using EatEaze.Data.Entities;
using EatEaze.Responce;

namespace EatEaze.WebApplicationAPI.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Position, FoodCardResponce>()
                .ForMember(dest => dest.PositionId, opt => opt.MapFrom(src => src.PositionId))
                .ForMember(dest => dest.PositionName, opt => opt.MapFrom(src => src.PositionName))
                .ForMember(dest => dest.Count, opt => opt.MapFrom(src => src.Count))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.ImageURL, opt => opt.MapFrom(src => src.ImageURL))
                .ForMember(dest => dest.RestarauntName, opt => opt.MapFrom(src => src.Restaraunt.RestarauntName))
                .ForMember(dest => dest.RestarauntImageURL, opt => opt.MapFrom(src => src.Restaraunt.ImageURL))
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.CategoryName));
        }
    }
}
