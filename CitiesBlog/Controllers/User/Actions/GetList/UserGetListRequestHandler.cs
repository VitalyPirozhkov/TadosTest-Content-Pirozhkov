using Api.Requests.Abstractions;
using AutoMapper;
using CitiesBlog.Controllers.User.Dto;
using CitiesBlog.Domain.Criteria;
using NHibernate.Mapping;
using Queries.Abstractions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CitiesBlog.Controllers.User.Actions.GetList
{
    public class UserGetListRequestHandler : IAsyncRequestHandler<UserGetListRequest, UserGetListResponse>
    {
        private readonly IAsyncQueryBuilder _asyncQueryBuilder;
        private readonly IMapper _mapper;

        public UserGetListRequestHandler(IAsyncQueryBuilder asyncQueryBuilder, IMapper mapper)
        {
            _asyncQueryBuilder = asyncQueryBuilder ?? throw new ArgumentNullException(nameof(asyncQueryBuilder));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }



        public async Task<UserGetListResponse> ExecuteAsync(UserGetListRequest request)
        {
            var users = await _asyncQueryBuilder.
                For<List<Domain.Entity.User>>().
                WithAsync(new FindBySearch(request.Search));

            return new UserGetListResponse(
                Users: _mapper.Map<IEnumerable<UserListItemDto>>(users));
        }
    }
}
