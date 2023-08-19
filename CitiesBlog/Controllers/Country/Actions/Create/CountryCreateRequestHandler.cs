using Api.Requests.Abstractions;
using CitiesBlog.Domain.Services.Cities;
using CitiesBlog.Domain.Services.Countries;
using System;
using System.Threading.Tasks;

namespace CitiesBlog.Controllers.Country.Actions.Create
{
    public class CountryCreateRequestHandler : IAsyncRequestHandler<CountryCreateRequest, CountryCreateResponse>
    {
        private readonly ICountryService _countryService;

        public CountryCreateRequestHandler(ICountryService countryService) 
        {
            _countryService = countryService ?? throw new ArgumentNullException(nameof(countryService)); ;
        }

        public async Task<CountryCreateResponse> ExecuteAsync(CountryCreateRequest request)
        {
            var country = await _countryService.CreateCountryAsync(
                name: request.Name);
            return new CountryCreateResponse(Id: country.Id);
        }
    }
}
