using Domain.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System;
using System.Linq;

namespace CitiesBlog.DI.Microsoft.DependencyInjection.Extensions
{
    public static class DomainServicesExtensions
    {
        public static IServiceCollection AddDomainServicesFromAssemblyContaining<T>(
            this IServiceCollection serviceCollection)
        {
            Assembly assemblyToScan = typeof(T).Assembly;
            Type domainServiceType = typeof(IDomainService);

            Type[] domainServiceTypes = assemblyToScan.ExportedTypes
                .Where(x => !x.IsAbstract && !x.IsInterface && x.IsAssignableTo(domainServiceType))
                .ToArray();

            foreach (Type type in domainServiceTypes)
            {
                foreach (Type @interface in type.GetInterfaces().Where(x => x.IsAssignableTo(domainServiceType)))
                {
                    serviceCollection.AddScoped(@interface, type);
                }
            }

            return serviceCollection;
        }
    }
}
