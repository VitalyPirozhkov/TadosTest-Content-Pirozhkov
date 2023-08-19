using Api.Requests.Abstractions;
using AutoMapper;
using CitiesBlog.Controllers.City.Dto;
using CitiesBlog.Controllers.Country.Actions.GetList;
using CitiesBlog.Domain.Criteria;
using Queries.Abstractions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CitiesBlog.Controllers.City.Actions.GetList
{
    public class CityGetListRequestHandler : IAsyncRequestHandler<CityGetListRequest, CityGetListResponse>
    {
        private readonly IAsyncQueryBuilder _asyncQueryBuilder;
        private readonly IMapper _mapper;

        public CityGetListRequestHandler(IAsyncQueryBuilder asyncQueryBuilder, IMapper mapper)
        {
            _asyncQueryBuilder = asyncQueryBuilder ?? throw new ArgumentNullException(nameof(asyncQueryBuilder));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }



        public async Task<CityGetListResponse> ExecuteAsync(CityGetListRequest request)
        {
            var cities = await _asyncQueryBuilder.
                For<List<Domain.Entity.City>>()
                .WithAsync(new FindBySearch(request.Search));

            return new CityGetListResponse(
                Cities: _mapper.Map<IEnumerable<CityListItemDto>>(cities));
        }
    }
}
