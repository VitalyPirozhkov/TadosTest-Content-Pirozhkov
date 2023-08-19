using CitiesBlog.Domain.Commands.Contexts;
using CitiesBlog.Domain.Criteria;
using CitiesBlog.Domain.Entity;
using CitiesBlog.Domain.Exceptions;
using Commands.Abstractions;
using Domain.Abstractions;
using Queries.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CitiesBlog.Domain.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IAsyncQueryBuilder _queryBuilder;
        private readonly IAsyncCommandBuilder _commandBuilder;

        public UserService(IAsyncQueryBuilder queryBuilder, IAsyncCommandBuilder commandBuilder)
        {
            _queryBuilder = queryBuilder ?? throw new ArgumentNullException(nameof(queryBuilder));
            _commandBuilder = commandBuilder ?? throw new ArgumentNullException(nameof(commandBuilder));
        }

        public async Task<User> CreateUserAsync(string login, City city, CancellationToken cancellationToken = default)
        {
            await CheckIsUserNameExistAsync(login, cancellationToken);

            User user = new User(login, city);

            //await _commandBuilder.ExecuteAsync(new CreateUserCommandContext(user), cancellationToken);
            await _commandBuilder.CreateAsync(user, cancellationToken);

            return user;
        }

        private async Task CheckIsUserNameExistAsync(string login, CancellationToken cancellationToken = default)
        {
            int existingCount = await _queryBuilder
                .For<int>()
                .WithAsync(new FindUsersCountByLogin(login), cancellationToken);

            if (existingCount != 0)
                throw new UsernameAlreadyExistsException();
        }
    }
}
