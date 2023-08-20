using CitiesBlog.Domain.Criteria;
using Linq.AsyncQueryable.Abstractions.Factories;
using Linq.Providers.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CitiesBlog.Persistence.ORM.Queries.Entities.User
{
    public class FindUserBySearchQuery :
        LinqAsyncQueryBase<Domain.Entity.User, FindBySearch, List<Domain.Entity.User>>
    {
        public FindUserBySearchQuery(
            ILinqProvider linqProvider,
            IAsyncQueryableFactory asyncQueryableFactory) : base(linqProvider, asyncQueryableFactory)
        {
        }

        public override Task<List<Domain.Entity.User>> AskAsync(
            FindBySearch criterion, CancellationToken cancellationToken = default)
        {
            IQueryable<Domain.Entity.User> query = Query;

            if (!string.IsNullOrWhiteSpace(criterion.Search))
                query = query.Where(x => x.Login.Contains(criterion.Search));

            query = query.OrderBy(x => x.Login);

            return ToAsync(query).ToListAsync(cancellationToken);
        }
    }
}
