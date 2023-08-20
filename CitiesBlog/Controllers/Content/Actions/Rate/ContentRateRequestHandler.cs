using Api.Requests.Abstractions;
using CitiesBlog.Domain.Criteria;
using CitiesBlog.Domain.Services.Raitings;
using Queries.Abstractions;
using System;
using System.Threading.Tasks;

namespace CitiesBlog.Controllers.Content.Actions.Rate
{
    public class ContentRateRequestHandler : IAsyncRequestHandler<ContentRateRequest>
    {
        private readonly IAsyncQueryBuilder _asyncQueryBuilder;
        private readonly IRatingService _ratingService;

        public ContentRateRequestHandler(IAsyncQueryBuilder asyncQueryBuilder, IRatingService ratingService)
        {
            _asyncQueryBuilder = asyncQueryBuilder ?? throw new ArgumentNullException(nameof(asyncQueryBuilder));
            _ratingService = ratingService ?? throw new ArgumentNullException(nameof(ratingService));
        }

        public async Task ExecuteAsync(ContentRateRequest request)
        {
            var user = await _asyncQueryBuilder.FindByIdAsync<Domain.Entity.User>(request.UserId);

            var content = await _asyncQueryBuilder.FindByIdAsync<Domain.Entity.Content>(request.ContentId);

            await _ratingService.RateAsync(content, user, request.Value);
        }
    }
}
