using AutoMapper;
using CitiesBlog.Controllers.City.Dto;
using CitiesBlog.Domain.Entity;

namespace CitiesBlog.Controllers.City.Profiles
{
    public class CityProfile : Profile
    {
        public CityProfile() 
        {
            CreateMap<Domain.Entity.City, CityDto>();
            CreateMap<Domain.Entity.City, CityListItemDto>();
        }
    }
}
