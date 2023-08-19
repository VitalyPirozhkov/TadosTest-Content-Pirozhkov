using Api.Requests.Abstractions;

namespace CitiesBlog.Controllers.Country.Actions.Create
{
    public record CountryCreateResponse(long Id) : IResponse;
}