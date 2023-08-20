using Api.Requests.Abstractions;
using AutoMapper;
using CitiesBlog.Controllers.Content.Dto;
using CitiesBlog.Controllers.User.Actions.GetList;
using CitiesBlog.Domain.Criteria;
using Queries.Abstractions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CitiesBlog.Controllers.Content.Actions.GetList
{
    public class ContentGetListRequestHandler : IAsyncRequestHandler<ContentGetListRequest, ContentGetListResponse>
    {
        private readonly IAsyncQueryBuilder _asyncQueryBuilder;
        private readonly IMapper _mapper;

        public ContentGetListRequestHandler(IAsyncQueryBuilder asyncQueryBuilder, IMapper mapper)
        {
            _asyncQueryBuilder = asyncQueryBuilder ?? throw new ArgumentNullException(nameof(asyncQueryBuilder));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<ContentGetListResponse> ExecuteAsync(ContentGetListRequest request)
        {
            var contents = await _asyncQueryBuilder.
                For<List<Domain.Entity.Content>>().
                WithAsync(new FindBySearchAndContentTypeAndCreator(request.Search, request.Type, request.UserId));

            return new ContentGetListResponse(
                Contents: _mapper.Map<IEnumerable<ContentListItemDto>>(contents));

        }
    }
}
