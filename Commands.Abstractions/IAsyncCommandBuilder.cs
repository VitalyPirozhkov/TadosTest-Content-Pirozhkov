using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Commands.Abstractions
{
    public interface IAsyncCommandBuilder
    {
        Task ExecuteAsync<TCommandContext>(
            TCommandContext commandContext,
            CancellationToken cancellationToken = default) where TCommandContext : ICommandContext;
    }
}
