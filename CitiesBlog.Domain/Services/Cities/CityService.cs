using CitiesBlog.Domain.Entity;
using Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitiesBlog.Domain.Services.Cities
{
    internal class CityService : ICityService
    {
        public async Task<City> CreateCityAsync(string name, Country country)
        {
            await CheckIsCityNameExistAsync(name, country);

            return new City(name, country);
        }

        private async Task CheckIsCityNameExistAsync(string name, Country country)
        {
            throw new NotImplementedException();
        }
    }
}
