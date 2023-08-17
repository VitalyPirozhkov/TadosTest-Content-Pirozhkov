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
    internal class FindUsersCountByLoginQuery :
        LinqAsyncQueryBase<Domain.Entity.User, FindUsersCountByLogin, int>
    {
        public FindUsersCountByLoginQuery(
        ILinqProvider linqProvider,
        IAsyncQueryableFactory asyncQueryableFactory) : base(linqProvider, asyncQueryableFactory)
        {

        }

        public override Task<int> AskAsync(FindUsersCountByLogin criterion,
            CancellationToken cancellationToken = default)
        {
            return AsyncQuery().CountAsync(
                x => x.Login == criterion.Login, cancellationToken);
        }
    }
}
