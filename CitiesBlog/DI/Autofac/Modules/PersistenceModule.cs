using Autofac.Extensions.ConfiguredModules;
using Autofac;
using Database.Abstractions;
using Database.Sqllite;
using Microsoft.Extensions.Configuration;
using Tados.Autofac.Extensions.TypedFactories;
using CitiesBlog.Persistence.NHibernate;
using Linq.AsyncQueryable.Abstractions.Factories;
using Linq.Providers.Abstractions;
using NHibernate.Infrastructure.Linq.AsyncQueryable.Factories;
using NHibernate.Infrastructure.Linq.Providers;
using NHibernate.Infrastructure.Repositories;
using NHibernate.Infrastructure.Sessions.Abstractions;
using NHibernate.Infrastructure.Sessions;
using Persistence.Transactions.Behaviors;
using Repositories.Abstractions;

namespace CitiesBlog.DI.Autofac.Modules
{
    public class PersistenceModule : ConfiguredModule
    {
        protected override void Load(ContainerBuilder builder)
        {
            string connectionString = Configuration.GetConnectionString("CitiesBlog");


            builder
                .RegisterGeneric(typeof(NHibernateAsyncRepository<>))
                .As(typeof(IAsyncRepository<>))
                .InstancePerDependency();

            builder
                .RegisterType<NHibernateLinqProvider>()
                .As<ILinqProvider>()
                .InstancePerDependency();

            builder
                .RegisterType<ExpectCommitScopedSessionProvider>()
                .As<ISessionProvider>()
                .As<IExpectCommit>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<NHibernateAsyncQueryableFactory>()
                .As<IAsyncQueryableFactory>()
                .SingleInstance();

            builder
                .RegisterType<NHibernateInitializer>()
                .AsSelf()
                .SingleInstance()
                .WithParameter(NHibernateInitializer.ConnectionStringParameterName, connectionString);

            builder
                .Register(context =>
                    context.Resolve<NHibernateInitializer>().GetConfiguration().BuildSessionFactory())
                .AsImplementedInterfaces()
                .SingleInstance();
        }
    }
}
