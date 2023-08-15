using CitiesBlog.DI.Microsoft.DependencyInjection.Factories;
using Microsoft.Extensions.DependencyInjection;
using Queries.Abstractions;
using System.Reflection;
using System;
using System.Linq;

namespace CitiesBlog.DI.Microsoft.DependencyInjection.Extensions
{
    public static class QueriesExtensions
    {
        public static IServiceCollection AddQueriesFromAssemblyContaining<T>(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IAsyncQueryFor<>), typeof(DefaultAsyncQueryFor<>));
            serviceCollection.AddScoped<IAsyncQueryFactory, ScopedAsyncQueryFactory>();
            serviceCollection.AddScoped<IAsyncQueryBuilder, ScopedAsyncQueryBuilder>();

            Assembly assemblyToScan = typeof(T).Assembly;
            Type queryOpenType = typeof(IAsyncQuery<,>);

            Type[] queryTypes = assemblyToScan.ExportedTypes
                .Where(x => !x.IsAbstract && !x.IsInterface && x.GetInterfaces()
                    .Any(y => y.GetGenericTypeDefinition() is { } type && type == queryOpenType))
                .ToArray();

            foreach (Type queryType in queryTypes)
            {
                Type[] interfaceTypes = queryType.GetInterfaces()
                    .Where(x => x.GetGenericTypeDefinition() is { } type && type == queryOpenType).ToArray();

                foreach (Type interfaceType in interfaceTypes)
                {
                    serviceCollection.AddTransient(interfaceType, queryType);
                }
            }

            return serviceCollection;
        }
    }
}
