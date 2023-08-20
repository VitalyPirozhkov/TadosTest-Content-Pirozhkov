using Api.Requests.Abstractions;

namespace CitiesBlog.Controllers.User.Actions.Get
{
    public record UserGetRequest : IRequest<UserGetResponse>
    {
        public long Id { get; set; }
    }
}