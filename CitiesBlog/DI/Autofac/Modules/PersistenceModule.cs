using Autofac.Extensions.ConfiguredModules;
using Autofac;
using Database.Abstractions;
using Database.Sqllite;
using Microsoft.Extensions.Configuration;
using Tados.Autofac.Extensions.TypedFactories;

namespace CitiesBlog.DI.Autofac.Modules
{
    public class PersistenceModule : ConfiguredModule
    {
        protected override void Load(ContainerBuilder builder)
        {
            string connectionString = Configuration.GetConnectionString("Pets");


            builder
                .RegisterType<Database>()
                .AsSelf()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<SqliteConnectionFactory>()
                .As<IDbConnectionFactory>()
                .WithParameter(SqliteConnectionFactory.ConnectionStringParameterName, connectionString)
                .SingleInstance();

            builder
                .RegisterType<ExpectCommitScopedSessionProvider>()
                .As<IDbTransactionProvider>()
                .As<IExpectCommit>()
                .InstancePerLifetimeScope();
        }
    }
}
