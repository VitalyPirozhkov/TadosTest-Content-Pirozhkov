namespace CitiesBlog.DI.Autofac.Modules
{
    using Domain;
    using global::Autofac;
    using global::Domain.Abstractions;
    using Pets.Domain;

    public class DomainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterAssemblyTypes(typeof(DomainAssemblyMarker).Assembly)
                .AssignableTo<IDomainService>()
                .AsImplementedInterfaces()
                .InstancePerDependency();
        }
    }
}
