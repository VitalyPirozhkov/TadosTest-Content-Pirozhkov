using Api.Requests.Abstractions;

namespace CitiesBlog.Controllers.City.Actions.Create
{
    public record CityCreateResponse(long Id) : IResponse;
}