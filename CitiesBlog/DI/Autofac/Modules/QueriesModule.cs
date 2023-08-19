using Autofac;
using CitiesBlog.Persistence.ORM.Queries;
using CitiesBlog.Persistence.ORM;
using Queries.Abstractions;
using Tados.Autofac.Extensions.TypedFactories;

namespace CitiesBlog.DI.Autofac.Modules
{
    public class QueriesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterGeneric(typeof(FindObjectWithIdByIdQuery<>))
                .As(typeof(IAsyncQuery<,>))
                .InstancePerDependency();

            builder
                .RegisterAssemblyTypes(typeof(PersistenceOrmAssemblyMarker).Assembly)
                .AsClosedTypesOf(typeof(IAsyncQuery<,>))
                .InstancePerDependency();

            builder
                .RegisterGeneric(typeof(DefaultAsyncQueryFor<>))
                .As(typeof(IAsyncQueryFor<>))
                .InstancePerLifetimeScope();

            builder
                .RegisterGenericTypedFactory<IAsyncQueryFactory>()
                .InstancePerLifetimeScope();

            builder
                .RegisterGenericTypedFactory<IAsyncQueryBuilder>()
                .InstancePerLifetimeScope();
        }
    }
}
