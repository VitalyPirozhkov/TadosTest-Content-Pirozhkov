using Api.Requests.Abstractions;

namespace CitiesBlog.Controllers.User.Actions.Create
{
    public record UserCreateResponse(long Id) : IResponse;
}