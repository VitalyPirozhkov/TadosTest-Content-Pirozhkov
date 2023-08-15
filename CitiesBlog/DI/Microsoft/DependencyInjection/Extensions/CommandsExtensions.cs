using CitiesBlog.DI.Microsoft.DependencyInjection.Factories;
using Commands.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System;
using System.Linq;

namespace CitiesBlog.DI.Microsoft.DependencyInjection.Extensions
{
    public static class CommandsExtensions
    {
        public static IServiceCollection AddCommandsFromAssemblyContaining<T>(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IAsyncCommandFactory, ScopedAsyncCommandFactory>();
            serviceCollection.AddScoped<IAsyncCommandBuilder, DefaultAsyncCommandBuilder>();

            Assembly assemblyToScan = typeof(T).Assembly;
            Type commandOpenType = typeof(IAsyncCommand<>);

            Type[] commandTypes = assemblyToScan.ExportedTypes
                .Where(x => !x.IsAbstract && !x.IsInterface && x.GetInterfaces()
                    .Any(y => y.GetGenericTypeDefinition() is { } type && type == commandOpenType))
                .ToArray();

            foreach (Type commandType in commandTypes)
            {
                Type[] interfaceTypes = commandType.GetInterfaces()
                    .Where(x => x.GetGenericTypeDefinition() is { } type && type == commandOpenType).ToArray();

                foreach (Type interfaceType in interfaceTypes)
                {
                    serviceCollection.AddTransient(interfaceType, commandType);
                }
            }

            return serviceCollection;
        }
    }
}
