using Api.Requests.Abstractions;
using CitiesBlog.Controllers.City.Actions.Create;

namespace CitiesBlog.Controllers.User.Actions.Create
{
    public record UserCreateRequest : IRequest<UserCreateResponse>
    {
        public string Login { get; set; }

        public long CityId { get; set; }
    }
}