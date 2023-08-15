using AutoMapper;
using CitiesBlog.Controllers.Country.Dto;
using CitiesBlog.Domain.Entity;
namespace CitiesBlog.Controllers.Country.Profiles
{
    public class CountryProfiles : Profile
    {
        public CountryProfiles() 
        {
            CreateMap<Domain.Entity.Country, CountryDto>();
            CreateMap<Domain.Entity.Country, CountryListItemDto>();
        }
    }
}
