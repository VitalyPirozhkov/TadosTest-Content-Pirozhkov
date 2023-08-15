using CitiesBlog.Domain.Commands.Contexts;
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
using CitiesBlog.Domain.Criteria;

namespace CitiesBlog.Domain.Services.Countries
{
    public class CountryService : ICountryService
    {
        private readonly IAsyncQueryBuilder _queryBuilder;
        private readonly IAsyncCommandBuilder _commandBuilder;

        public CountryService(IAsyncQueryBuilder queryBuilder, IAsyncCommandBuilder commandBuilder)
        {
            _queryBuilder = queryBuilder ?? throw new ArgumentNullException(nameof(queryBuilder));
            _commandBuilder = commandBuilder ?? throw new ArgumentNullException(nameof(commandBuilder));
        }

        public async Task<Country> CreateCountryAsync(string name, CancellationToken cancellationToken = default)
        {
            await CheckIsCountryNameExistAsync(name);

            Country country = new Country(name);

            await _commandBuilder.ExecuteAsync(new CreateCountryCommandContext(country), cancellationToken);

            return country;
        }

        private async Task CheckIsCountryNameExistAsync(string name, CancellationToken cancellationToken = default)
        {
            int existingCount = await _queryBuilder
                .For<int>()
                .WithAsync(new FindCountryCountByName(name), cancellationToken);

            if (existingCount != 0)
                throw new CountryAlreadyExistsException();
        }
    }
}
