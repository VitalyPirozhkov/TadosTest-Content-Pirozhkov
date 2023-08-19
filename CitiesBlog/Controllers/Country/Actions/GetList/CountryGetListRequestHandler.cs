using Api.Requests.Abstractions;
using AutoMapper;
using CitiesBlog.Controllers.Country.Dto;
using CitiesBlog.Domain.Criteria;
using NHibernate.Mapping;
using Queries.Abstractions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CitiesBlog.Controllers.Country.Actions.GetList
{
    public class CountryGetListRequestHandler : IAsyncRequestHandler<CountryGetListRequest, CountryGetListResponse>
    {
        private readonly IAsyncQueryBuilder _asyncQueryBuilder;
        private readonly IMapper _mapper;

        public CountryGetListRequestHandler(IAsyncQueryBuilder asyncQueryBuilder, IMapper mapper)
        {
            _asyncQueryBuilder = asyncQueryBuilder ?? throw new ArgumentNullException(nameof(asyncQueryBuilder));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<CountryGetListResponse> ExecuteAsync(CountryGetListRequest request)
        {
            var countries = await _asyncQueryBuilder.
                For<List<Domain.Entity.Country>>()
                .WithAsync(new FindBySearch(request.Search));

            return new CountryGetListResponse(
                Countries: _mapper.Map<IEnumerable<CountryListItemDto>>(countries));
        }
    }
}
