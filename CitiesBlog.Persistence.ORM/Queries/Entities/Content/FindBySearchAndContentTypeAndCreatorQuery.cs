using CitiesBlog.Domain.Criteria;
using Linq.AsyncQueryable.Abstractions.Factories;
using Linq.Providers.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CitiesBlog.Persistence.ORM.Queries.Entities.Content
{
    public class FindBySearchAndContentTypeAndCreatorQuery :
        LinqAsyncQueryBase<Domain.Entity.Content, FindBySearchAndContentTypeAndCreator, List<Domain.Entity.Content>>
    {
        public FindBySearchAndContentTypeAndCreatorQuery(
            ILinqProvider linqProvider,
            IAsyncQueryableFactory asyncQueryableFactory) : base(linqProvider, asyncQueryableFactory)
        {
        }

        public override Task<List<Domain.Entity.Content>> AskAsync(
            FindBySearchAndContentTypeAndCreator criterion, CancellationToken cancellationToken = default)
        {
            IQueryable<Domain.Entity.Content> query = Query;
            if(criterion.ContentType.HasValue)
                query = query.Where(x=> x.Type== criterion.ContentType.Value);
            if(criterion.UserId>0)
                query = query.Where(x=> x.Creator.Id==criterion.UserId);
            if (!string.IsNullOrWhiteSpace(criterion.Search))
                query = query.Where(x => x.Name.Contains(criterion.Search));

            query = query.OrderBy(x => x.Name);

            return ToAsync(query).ToListAsync(cancellationToken);
        }
    }
}
