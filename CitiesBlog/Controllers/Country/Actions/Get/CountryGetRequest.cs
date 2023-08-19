using Api.Requests.Abstractions;
using CitiesBlog.Controllers.Country.Actions.GetList;

namespace CitiesBlog.Controllers.Country.Actions.Get
{
    public record CountryGetRequest : IRequest<CountryGetResponse>
    {
        public long Id { get; set; }
    }
}