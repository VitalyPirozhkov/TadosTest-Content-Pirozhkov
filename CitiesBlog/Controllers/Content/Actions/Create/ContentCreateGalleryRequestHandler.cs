using Api.Requests.Abstractions;
using CitiesBlog.Domain.Services.Contents.Videos;
using Queries.Abstractions;
using System.Threading.Tasks;
using System;
using CitiesBlog.Domain.Services.Contents.Galleries;
using CitiesBlog.Domain.Criteria;

namespace CitiesBlog.Controllers.Content.Actions.Create
{
    public class ContentCreateGalleryRequestHandler : IAsyncRequestHandler<ContentCreateGalleryRequest, ContentCreateResponse>
    {
        private readonly IAsyncQueryBuilder _asyncQueryBuilder;
        private readonly IGalleryService _galleryService;

        public ContentCreateGalleryRequestHandler(IGalleryService galleryService, IAsyncQueryBuilder asyncQueryBuilder)
        {
            _asyncQueryBuilder = asyncQueryBuilder ?? throw new ArgumentNullException(nameof(asyncQueryBuilder));
            _galleryService = galleryService ?? throw new ArgumentNullException(nameof(galleryService));
        }

        public async Task<ContentCreateResponse> ExecuteAsync(ContentCreateGalleryRequest request)
        {
            var user = await _asyncQueryBuilder.FindByIdAsync<Domain.Entity.User>(request.UserId);

            var gallery = await _galleryService.CreateGalleryAsync(
                name: request.Name,
                cover: request.Cover,
                images: request.Images,
                creator: user);

            return new ContentCreateResponse(gallery.Id);
        }
    }
}
