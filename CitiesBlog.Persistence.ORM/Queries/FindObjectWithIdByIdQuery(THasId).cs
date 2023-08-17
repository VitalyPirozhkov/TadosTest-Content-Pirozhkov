using CitiesBlog.Domain.Criteria;
using Domain.Abstractions;
using Linq.AsyncQueryable.Abstractions.Factories;
using Linq.Providers.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CitiesBlog.Persistence.ORM.Queries
{
    public class FindObjectWithIdByIdQuery<THasId> : LinqAsyncQueryBase<THasId, FindById, THasId>
            where THasId : class, IHasId, new()
    {
        public FindObjectWithIdByIdQuery(
            ILinqProvider linqProvider,
            IAsyncQueryableFactory asyncQueryableFactory) : base(linqProvider, asyncQueryableFactory)
        {
        }

        public override Task<THasId> AskAsync(FindById criterion, CancellationToken cancellationToken = default)
        {
            return AsyncQuery().SingleOrDefaultAsync(x => x.Id == criterion.Id, cancellationToken);
        }
    }
}
