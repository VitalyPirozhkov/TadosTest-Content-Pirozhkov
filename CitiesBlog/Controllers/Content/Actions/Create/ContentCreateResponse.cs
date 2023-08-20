using Api.Requests.Abstractions;

namespace CitiesBlog.Controllers.Content.Actions.Create
{
    public record ContentCreateResponse(long Id) : IResponse;
}