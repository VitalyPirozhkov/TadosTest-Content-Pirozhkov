using Api.Requests.Abstractions;
using CitiesBlog.Controllers.City.Actions.Get;

namespace CitiesBlog.Controllers.Content.Actions.Get
{
    public record ContentGetRequest : IRequest<ContentGetResponse>
    {
        public long Id { get; set; }
    }
}