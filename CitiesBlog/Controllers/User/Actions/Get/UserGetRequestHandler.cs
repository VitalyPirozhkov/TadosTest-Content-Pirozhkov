﻿using Api.Requests.Abstractions;
using AutoMapper;
using CitiesBlog.Controllers.User.Dto;
using CitiesBlog.Domain.Criteria;
using Queries.Abstractions;
using System;
using System.Threading.Tasks;

namespace CitiesBlog.Controllers.User.Actions.Get
{
    public class UserGetRequestHandler : IAsyncRequestHandler<UserGetRequest, UserGetResponse>
    {
        private readonly IAsyncQueryBuilder _asyncQueryBuilder;
        private readonly IMapper _mapper;

        public UserGetRequestHandler(IAsyncQueryBuilder asyncQueryBuilder, IMapper mapper)
        {
            _asyncQueryBuilder = asyncQueryBuilder ?? throw new ArgumentNullException(nameof(asyncQueryBuilder));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<UserGetResponse> ExecuteAsync(UserGetRequest request)
        {
            var user = await _asyncQueryBuilder.FindByIdAsync<Domain.Entity.User>(request.Id);

            return new UserGetResponse(
                User: _mapper.Map<UserDto>(user));
        }
    }
}
