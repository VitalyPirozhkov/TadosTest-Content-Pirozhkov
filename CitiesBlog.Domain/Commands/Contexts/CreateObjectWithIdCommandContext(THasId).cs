using Commands.Abstractions;
using Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CitiesBlog.Domain.Commands.Contexts
{
    public class CreateObjectWithIdCommandContext<THasId> : ICommandContext
            where THasId : class, IHasId, new()
    {
        public CreateObjectWithIdCommandContext(THasId objectWithId)
        {
            ObjectWithId = objectWithId ?? throw new ArgumentNullException(nameof(objectWithId));
        }


        public THasId ObjectWithId { get; }
    }

    public static class CreateObjectWithIdCommandContextExtensions
    {
        public static Task CreateAsync<THasId>(
            this IAsyncCommandBuilder commandBuilder,
            THasId objectWithId,
            CancellationToken cancellationToken = default) where THasId : class, IHasId, new()
        {
            return commandBuilder.ExecuteAsync(
                new CreateObjectWithIdCommandContext<THasId>(objectWithId),
                cancellationToken);
        }
    }
}
