using AutoMapper;
using CitiesBlog.Controllers.User.Dto;

namespace CitiesBlog.Controllers.User.Profiles
{
    public class UserProfiles : Profile
    {
        public UserProfiles() 
        {
            CreateMap<Domain.Entity.User, UserDto>();
            CreateMap<Domain.Entity.User, UserListItemDto>();
        }
    }
}
