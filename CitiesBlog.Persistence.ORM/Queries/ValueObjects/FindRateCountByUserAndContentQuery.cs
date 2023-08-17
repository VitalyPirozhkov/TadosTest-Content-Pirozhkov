using CitiesBlog.Domain.Criteria;
using Linq.AsyncQueryable.Abstractions.Factories;
using Linq.Providers.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CitiesBlog.Persistence.ORM.Queries.ValueObjects
{
    internal class FindRateCountByUserAndContentQuery :
        LinqAsyncQueryBase<Domain.ValueObjects.Rating, FindRateCountByUserAndContent, int>
    {
        public FindRateCountByUserAndContentQuery(
        ILinqProvider linqProvider,
        IAsyncQueryableFactory asyncQueryableFactory) : base(linqProvider, asyncQueryableFactory)
        {

        }

        public override Task<int> AskAsync(FindRateCountByUserAndContent criterion,
            CancellationToken cancellationToken = default)
        {
            return AsyncQuery().CountAsync(x=>x.User==criterion.User && x.Content == criterion.Content, cancellationToken);
        }
    }
}
