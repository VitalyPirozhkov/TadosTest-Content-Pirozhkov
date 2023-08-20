using Api.Requests.Abstractions;

namespace CitiesBlog.Controllers.Content.Actions.Create
{
    public record ContentCreateArticleRequest : ContentCreateRequestBase,  IRequest<ContentCreateResponse>
    {
        public string Text { get; set; }
    }
}