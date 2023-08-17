using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CitiesBlog.Domain.Commands.Contexts;
using Commands.Abstractions;
using Domain.Abstractions;
using Repositories.Abstractions;

namespace CitiesBlog.Persistence.ORM.Commands
{
    public class CreateObjectWithIdCommand<THasId> : IAsyncCommand<CreateObjectWithIdCommandContext<THasId>>
            where THasId : class, IHasId, new()
    {
        private readonly IAsyncRepository<THasId> _repository;


        public CreateObjectWithIdCommand(IAsyncRepository<THasId> repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }


        public Task ExecuteAsync(
            CreateObjectWithIdCommandContext<THasId> commandContext,
            CancellationToken cancellationToken = default)
        {
            return _repository.AddAsync(commandContext.ObjectWithId, cancellationToken);
        }
    }
}
