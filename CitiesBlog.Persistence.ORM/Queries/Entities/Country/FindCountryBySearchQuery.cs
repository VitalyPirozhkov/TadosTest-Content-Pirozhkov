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
    public class FindCountryBySearchQuery :
        LinqAsyncQueryBase<Domain.Entity.Country, FindBySearch, List<Domain.Entity.Country>>
    {
        public FindCountryBySearchQuery(
            ILinqProvider linqProvider,
            IAsyncQueryableFactory asyncQueryableFactory) : base(linqProvider, asyncQueryableFactory)
        {
        }

        public override Task<List<Domain.Entity.Country>> AskAsync(
            FindBySearch criterion, CancellationToken cancellationToken = default)
        {
            IQueryable<Domain.Entity.Country> query = Query;

            if (!string.IsNullOrWhiteSpace(criterion.Search))
                query = query.Where(x => x.Name.Contains(criterion.Search));

            query = query.OrderBy(x => x.Name);

            return ToAsync(query).ToListAsync(cancellationToken);
        }
    }
}
