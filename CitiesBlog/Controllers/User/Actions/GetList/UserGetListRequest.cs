using Api.Requests.Abstractions;
using CitiesBlog.Controllers.City.Actions.GetList;

namespace CitiesBlog.Controllers.User.Actions.GetList
{
    public record UserGetListRequest : IRequest<UserGetListResponse>
    {
        public string Search { get; init; }
    }
}