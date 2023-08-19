using Api.Requests.Abstractions;

namespace CitiesBlog.Controllers.City.Actions.Create
{
    public record CityCreateRequest : IRequest<CityCreateResponse>
    {
        public string Name { get; set; }

        public long CountryId { get; set; }
    }
}