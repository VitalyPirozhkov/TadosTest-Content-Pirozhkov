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
    public class FindCityBySearchQuery :
        LinqAsyncQueryBase<Domain.Entity.City, FindBySearch, List<Domain.Entity.City>>
    {
        public FindCityBySearchQuery(
            ILinqProvider linqProvider,
            IAsyncQueryableFactory asyncQueryableFactory) : base(linqProvider, asyncQueryableFactory)
        {
        }

        public override Task<List<Domain.Entity.City>> AskAsync(
            FindBySearch criterion, CancellationToken cancellationToken = default)
        {
            IQueryable<Domain.Entity.City> query = Query;

            if (!string.IsNullOrWhiteSpace(criterion.Search))
                query = query.Where(x => x.Name.Contains(criterion.Search));

            query = query.OrderBy(x => x.Name);

            return ToAsync(query).ToListAsync(cancellationToken);
        }

    }
}
