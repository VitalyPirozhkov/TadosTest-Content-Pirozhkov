using Api.Requests.Abstractions;
using CitiesBlog.Controllers.City.Actions.Create;

namespace CitiesBlog.Controllers.Content.Actions.Create
{
    public abstract record ContentCreateRequestBase : IRequest<ContentCreateResponse>
    {
        public string Name { get; set; }

        public long UserId { get; set; }
    }
}