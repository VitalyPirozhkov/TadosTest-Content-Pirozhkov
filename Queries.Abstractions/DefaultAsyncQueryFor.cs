﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Queries.Abstractions
{
    public class DefaultAsyncQueryFor<TResult> : IAsyncQueryFor<TResult>
    {
        private readonly IAsyncQueryFactory _asyncQueryFactory;


        public DefaultAsyncQueryFor(IAsyncQueryFactory asyncQueryFactory)
        {
            _asyncQueryFactory = asyncQueryFactory ?? throw new ArgumentNullException(nameof(asyncQueryFactory));
        }


        public Task<TResult> WithAsync<TCriterion>(
            TCriterion criterion,
            CancellationToken cancellationToken = default)
            where TCriterion : ICriterion
        {
            return _asyncQueryFactory.Create<TCriterion, TResult>().AskAsync(criterion, cancellationToken);
        }
    }
}
