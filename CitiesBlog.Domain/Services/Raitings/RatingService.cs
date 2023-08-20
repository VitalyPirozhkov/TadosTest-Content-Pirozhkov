using CitiesBlog.Domain.Commands.Contexts;
using CitiesBlog.Domain.Criteria;
using CitiesBlog.Domain.Entity;
using CitiesBlog.Domain.Exceptions;
using CitiesBlog.Domain.ValueObjects;
using Commands.Abstractions;
using Domain.Abstractions;
using Queries.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CitiesBlog.Domain.Services.Raitings
{
    public class RatingService : IRatingService
    {
        private readonly IAsyncQueryBuilder _queryBuilder;
        private readonly IAsyncCommandBuilder _commandBuilder;

        public RatingService(IAsyncQueryBuilder queryBuilder, IAsyncCommandBuilder commandBuilder)
        {
            _queryBuilder = queryBuilder ?? throw new ArgumentNullException(nameof(queryBuilder));
            _commandBuilder = commandBuilder ?? throw new ArgumentNullException(nameof(commandBuilder));
        }

        public async Task RateAsync(Content content, User user, int value, CancellationToken cancellationToken=default)
        {
            if (content == null)
                throw new ArgumentNullException(nameof(content));

            if (user == null)
                throw new ArgumentNullException(nameof(user));

            if (value < 1 || value > 5)
                throw new ArgumentOutOfRangeException(nameof(value));

            await CheckIsUserRateExistAsync(user, content, cancellationToken);

            Rating rating = content.Rate(value, user);

        }

        private async Task CheckIsUserRateExistAsync(User user, Content content, CancellationToken cancellationToken = default)
        {
            int existingCount = await _queryBuilder
                .For<int>()
                .WithAsync(new FindRateCountByUserAndContent(user, content), cancellationToken);

            if (existingCount != 0)
                throw new MultipleUserRateException();
        }
    }
}
