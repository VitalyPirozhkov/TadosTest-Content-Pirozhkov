using CitiesBlog.Domain.Entity;
using Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitiesBlog.Domain.Services.Countries
{
    public class CountryService : ICountryService
    {
        public async Task<Country> CreateCountryAsync(string name)
        {
            await CheckIsCountryNameExistAsync(name);

            return new Country(name);
        }

        private async Task CheckIsCountryNameExistAsync(string name)
        {
            throw new NotImplementedException();
        }
    }
}
