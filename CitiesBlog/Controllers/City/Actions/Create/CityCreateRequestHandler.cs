using Api.Requests.Abstractions;
using CitiesBlog.Domain.Criteria;
using CitiesBlog.Domain.Services.Cities;
using Queries.Abstractions;
using System;
using System.Threading.Tasks;

namespace CitiesBlog.Controllers.City.Actions.Create
{
    public class CityCreateRequestHandler : IAsyncRequestHandler<CityCreateRequest, CityCreateResponse>
    {
        private readonly IAsyncQueryBuilder _asyncQueryBuilder;
        private readonly ICityService _cityService;

        public CityCreateRequestHandler(ICityService cityService, IAsyncQueryBuilder asyncQueryBuilder) 
        {
            _asyncQueryBuilder = asyncQueryBuilder ?? throw new ArgumentNullException(nameof(asyncQueryBuilder));
            _cityService = cityService ?? throw new ArgumentNullException(nameof(cityService));
        }

        public async Task<CityCreateResponse> ExecuteAsync(CityCreateRequest request)
        {
            var country = await _asyncQueryBuilder.FindByIdAsync<Domain.Entity.Country>(request.CountryId);

            var city = await _cityService.CreateCityAsync(
                name: request.Name,
                country: country);

            return new CityCreateResponse(Id: city.Id);
        }
    }
}
