using Api.Requests.Abstractions;
using AutoMapper;
using CitiesBlog.Controllers.Country.Dto;
using CitiesBlog.Domain.Criteria;
using Queries.Abstractions;
using System;
using System.Threading.Tasks;

namespace CitiesBlog.Controllers.Country.Actions.Get
{
    public class CountryGetRequestHandler : IAsyncRequestHandler<CountryGetRequest, CountryGetResponse>
    {
        private readonly IAsyncQueryBuilder _asyncQueryBuilder;
        private readonly IMapper _mapper;

        public CountryGetRequestHandler(IAsyncQueryBuilder asyncQueryBuilder, IMapper mapper)
        {
            _asyncQueryBuilder = asyncQueryBuilder ?? throw new ArgumentNullException(nameof(asyncQueryBuilder));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<CountryGetResponse> ExecuteAsync(CountryGetRequest request)
        {
            var country = await _asyncQueryBuilder.FindByIdAsync<Domain.Entity.Country>(request.Id);

            return new CountryGetResponse(
                Country: _mapper.Map<CountryDto>(country));
        }
    }
}
