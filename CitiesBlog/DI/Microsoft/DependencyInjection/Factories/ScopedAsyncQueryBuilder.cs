using Microsoft.Extensions.DependencyInjection;
using Queries.Abstractions;
using System;

namespace CitiesBlog.DI.Microsoft.DependencyInjection.Factories
{
    public class ScopedAsyncQueryBuilder : IAsyncQueryBuilder
    {
        private readonly IServiceProvider _serviceProvider;


        public ScopedAsyncQueryBuilder(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        }


        public IAsyncQueryFor<TResult> For<TResult>()
        {
            return _serviceProvider.GetService<IAsyncQueryFor<TResult>>();
        }
    }
}
