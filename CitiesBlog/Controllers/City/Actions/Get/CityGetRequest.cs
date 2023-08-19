using Api.Requests.Abstractions;
using CitiesBlog.Controllers.Country.Actions.GetList;

namespace CitiesBlog.Controllers.City.Actions.Get
{
    public record CityGetRequest : IRequest<CityGetResponse>
    {
        public long Id { get; set; }
    }
}