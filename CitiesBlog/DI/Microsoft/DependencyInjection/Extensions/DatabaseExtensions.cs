using Database.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace CitiesBlog.DI.Microsoft.DependencyInjection.Extensions
{
    public static class DatabaseExtensions
    {
        public static IServiceCollection AddDatabase<TDbConnectionFactory, TDbTransactionProvider>(this IServiceCollection serviceCollection)
            where TDbConnectionFactory : class, IDbConnectionFactory
            where TDbTransactionProvider : class, IDbTransactionProvider
        {
            serviceCollection.AddSingleton<IDbConnectionFactory, TDbConnectionFactory>();
            serviceCollection.AddScoped<IDbTransactionProvider, TDbTransactionProvider>();

            return serviceCollection;
        }
    }
}
