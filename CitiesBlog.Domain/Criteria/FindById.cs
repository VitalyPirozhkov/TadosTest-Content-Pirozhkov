using Domain.Abstractions;
using Queries.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CitiesBlog.Domain.Criteria
{
    public record FindById(long Id) : ICriterion;



    public static class FindByIdCriterionExtensions
    {
        public static Task<THasId> FindByIdAsync<THasId>(
            this IAsyncQueryBuilder asyncQueryBuilder,
            long id,
            CancellationToken cancellationToken = default)
            where THasId : class, IHasId, new()
        {
            return asyncQueryBuilder
                .For<THasId>()
                .WithAsync(new FindById(id), cancellationToken);
        }
    }
}
