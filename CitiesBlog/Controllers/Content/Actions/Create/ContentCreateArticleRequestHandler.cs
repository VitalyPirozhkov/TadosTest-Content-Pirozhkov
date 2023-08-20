using Api.Requests.Abstractions;
using CitiesBlog.Controllers.City.Actions.Create;
using CitiesBlog.Domain.Criteria;
using CitiesBlog.Domain.Services.Cities;
using CitiesBlog.Domain.Services.Contents.Aritcles;
using Queries.Abstractions;
using System;
using System.Threading.Tasks;

namespace CitiesBlog.Controllers.Content.Actions.Create
{
    public class ContentCreateArticleRequestHandler : IAsyncRequestHandler<ContentCreateArticleRequest, ContentCreateResponse>
    {
        private readonly IAsyncQueryBuilder _asyncQueryBuilder;
        private readonly IArticleService _articleService;

        public ContentCreateArticleRequestHandler(IArticleService articleService, IAsyncQueryBuilder asyncQueryBuilder)
        {
            _asyncQueryBuilder = asyncQueryBuilder ?? throw new ArgumentNullException(nameof(asyncQueryBuilder));
            _articleService = articleService ?? throw new ArgumentNullException(nameof(articleService));
        }

        public async Task<ContentCreateResponse> ExecuteAsync(ContentCreateArticleRequest request)
        {
            var user = await _asyncQueryBuilder.FindByIdAsync<Domain.Entity.User>(request.UserId);

            var article = await _articleService.CreateArticleAsync(
                name: request.Name,
                text: request.Text,
                creator: user);

            return new ContentCreateResponse(article.Id);
        }
    }
}
