using Api.Requests.Abstractions;

namespace CitiesBlog.Controllers.Content.Actions.Create
{
    public record ContentCreateVideoRequest : ContentCreateRequestBase, IRequest<ContentCreateResponse>
    {
        public string Reference { get; set; }
    }
}