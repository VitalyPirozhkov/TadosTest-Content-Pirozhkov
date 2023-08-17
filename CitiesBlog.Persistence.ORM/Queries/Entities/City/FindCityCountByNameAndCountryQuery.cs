using CitiesBlog.Domain.Criteria;
using Linq.AsyncQueryable.Abstractions.Factories;
using Linq.Providers.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CitiesBlog.Persistence.ORM.Queries.Entities.City
{
    public class FindCityCountByNameAndCountryQuery :
        LinqAsyncQueryBase<Domain.Entity.City, FindCityCountByNameAndCountry, int>
    {
        public FindCityCountByNameAndCountryQuery(
            ILinqProvider linqProvider,
            IAsyncQueryableFactory asyncQueryableFactory) : base(linqProvider, asyncQueryableFactory)
        {
        }

        public override Task<int> AskAsync(FindCityCountByNameAndCountry criterion,
            CancellationToken cancellationToken = default)
        {
            return AsyncQuery().CountAsync(
                x => x.Name == criterion.Name && x.Country == criterion.Country, cancellationToken);
        }
    }
}
