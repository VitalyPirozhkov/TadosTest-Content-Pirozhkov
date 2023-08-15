using CitiesBlog.Domain.Commands.Contexts;
using CitiesBlog.Domain.Criteria;
using CitiesBlog.Domain.Entity;
using CitiesBlog.Domain.Exceptions;
using Commands.Abstractions;
using Domain.Abstractions;
using Queries.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CitiesBlog.Domain.Services.Cities
{
    public class CityService : ICityService
    {
        private readonly IAsyncQueryBuilder _queryBuilder;
        private readonly IAsyncCommandBuilder _commandBuilder;

        public CityService(IAsyncQueryBuilder queryBuilder, IAsyncCommandBuilder commandBuilder)
        {
            _queryBuilder = queryBuilder ?? throw new ArgumentNullException(nameof(queryBuilder));
            _commandBuilder = commandBuilder ?? throw new ArgumentNullException(nameof(commandBuilder));
        }

        public async Task<City> CreateCityAsync(string name, Country country, CancellationToken cancellationToken = default)
        {
            await CheckIsCityNameExistAsync(name, country, cancellationToken);

            City city = new City(name, country);

            await _commandBuilder.ExecuteAsync(new CreateCityCommandContext(city), cancellationToken);

            return city;
        }

        private async Task CheckIsCityNameExistAsync(string name, Country country, CancellationToken cancellationToken = default)
        {
            int existingCount = await _queryBuilder
                .For<int>()
                .WithAsync(new FindCityCountByNameAndCountry(name, country), cancellationToken);

            if (existingCount != 0)
                throw new CityAlreadyExistsException();
        }
    }
}
