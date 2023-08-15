using Commands.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CitiesBlog.DI.Microsoft.DependencyInjection.Factories
{
    public class ScopedAsyncCommandFactory : IAsyncCommandFactory
    {
        private readonly IServiceProvider _serviceProvider;


        public ScopedAsyncCommandFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        }


        public IAsyncCommand<TCommandContext> Create<TCommandContext>() where TCommandContext : ICommandContext
        {
            return _serviceProvider.GetService<IAsyncCommand<TCommandContext>>();
        }
    }
}
