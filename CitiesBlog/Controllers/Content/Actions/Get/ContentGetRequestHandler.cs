using Api.Requests.Abstractions;
using AutoMapper;
using CitiesBlog.Controllers.City.Actions.Get;
using CitiesBlog.Controllers.Content.Dto;
using CitiesBlog.Domain.Criteria;
using Queries.Abstractions;
using System;
using System.Threading.Tasks;

namespace CitiesBlog.Controllers.Content.Actions.Get
{
    public class ContentGetRequestHandler : IAsyncRequestHandler<ContentGetRequest, ContentGetResponse>
    {
        private readonly IAsyncQueryBuilder _asyncQueryBuilder;
        private readonly IMapper _mapper;

        public ContentGetRequestHandler(IAsyncQueryBuilder asyncQueryBuilder, IMapper mapper)
        {
            _asyncQueryBuilder = asyncQueryBuilder ?? throw new ArgumentNullException(nameof(asyncQueryBuilder));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<ContentGetResponse> ExecuteAsync(ContentGetRequest request)
        {
            var content = await _asyncQueryBuilder.FindByIdAsync<Domain.Entity.Content>(request.Id);

            return new ContentGetResponse(
                Content: _mapper.Map<ContentDto>(content));
        }

    }
}
