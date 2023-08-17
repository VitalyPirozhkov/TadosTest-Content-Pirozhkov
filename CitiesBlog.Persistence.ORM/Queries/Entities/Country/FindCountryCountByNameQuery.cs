using CitiesBlog.Domain.Criteria;
using Linq.AsyncQueryable.Abstractions.Factories;
using Linq.Providers.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CitiesBlog.Persistence.ORM.Queries.Entities.Country
{
    public class FindCountryCountByNameQuery :
        LinqAsyncQueryBase<Domain.Entity.Country, FindCountryCountByName, int>
    {
        public FindCountryCountByNameQuery(
        ILinqProvider linqProvider,
        IAsyncQueryableFactory asyncQueryableFactory) : base(linqProvider, asyncQueryableFactory)
        {

        }

        public override Task<int> AskAsync(FindCountryCountByName criterion,
            CancellationToken cancellationToken = default)
        {
            return AsyncQuery().CountAsync(
                x => x.Name == criterion.Name, cancellationToken);
        }
    }
}
