using Api.Requests.Abstractions;
using CitiesBlog.Domain.Services.Contents.Aritcles;
using Queries.Abstractions;
using System.Threading.Tasks;
using System;
using CitiesBlog.Domain.Services.Contents.Videos;
using CitiesBlog.Domain.Criteria;

namespace CitiesBlog.Controllers.Content.Actions.Create
{
    public class ContentCreateVideoRequestHandler : IAsyncRequestHandler<ContentCreateVideoRequest, ContentCreateResponse>
    {
        private readonly IAsyncQueryBuilder _asyncQueryBuilder;
        private readonly IVideoService _videoService;

        public ContentCreateVideoRequestHandler(IVideoService videoService, IAsyncQueryBuilder asyncQueryBuilder)
        {
            _asyncQueryBuilder = asyncQueryBuilder ?? throw new ArgumentNullException(nameof(asyncQueryBuilder));
            _videoService = videoService ?? throw new ArgumentNullException(nameof(videoService));
        }

        public async Task<ContentCreateResponse> ExecuteAsync(ContentCreateVideoRequest request)
        {
            var user = await _asyncQueryBuilder.FindByIdAsync<Domain.Entity.User>(request.UserId);

            var video = await _videoService.CreateVideoAsync(
                name: request.Name,
                reference: request.Reference,
                creator: user);

            return new ContentCreateResponse(video.Id);
        } 
    }
}
