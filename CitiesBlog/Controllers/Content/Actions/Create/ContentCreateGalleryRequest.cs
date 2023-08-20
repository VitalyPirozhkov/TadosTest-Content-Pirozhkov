namespace CitiesBlog.Controllers.Content.Actions.Create
{
    using Api.Requests.Abstractions;
    using System.Collections.Generic;


    public record ContentCreateGalleryRequest : ContentCreateRequestBase, IRequest<ContentCreateResponse>
    {
        public string Cover { get; set; }

        public List<string> Images { get; set; }
    }
}