using Commands.Abstractions;
using global::Autofac;
using CitiesBlog.Persistence.ORM;
using CitiesBlog.Persistence.ORM.Commands;
using Tados.Autofac.Extensions.TypedFactories;

namespace CitiesBlog.DI.Autofac.Modules
{
    public class CommandsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterGeneric(typeof(CreateObjectWithIdCommand<>))
                .As(typeof(IAsyncCommand<>))
                .InstancePerDependency();

            builder
                .RegisterAssemblyTypes(typeof(PersistenceOrmAssemblyMarker).Assembly)
                .AsClosedTypesOf(typeof(IAsyncCommand<>))
                .InstancePerDependency();

            builder
                .RegisterGenericTypedFactory<IAsyncCommandFactory>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<DefaultAsyncCommandBuilder>()
                .As<IAsyncCommandBuilder>()
                .InstancePerLifetimeScope();
        }
    }
}
