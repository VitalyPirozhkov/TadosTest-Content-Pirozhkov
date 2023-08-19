using Api.Requests.Abstractions;
using CitiesBlog.Controllers.City.Actions.Create;

namespace CitiesBlog.Controllers.Country.Actions.Create
{
    public record CountryCreateRequest : IRequest<CountryCreateResponse>
    {
        public string Name { get; set; }
    }
}