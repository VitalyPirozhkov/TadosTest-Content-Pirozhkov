using Autofac;
using Autofac.Extensions.ConfiguredModules;//tados lib
using CitiesBlog.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Json.Converters.Hierarchy;

namespace CitiesBlog
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }



        public IConfiguration Configuration { get; }



        public void ConfigureDevelopmentServices(IServiceCollection services)
        {
            services
                .AddSwagger();


            ConfigureServices(services);
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddAutoMapper(typeof(ApplicationAssemblyMarker).Assembly)
                .AddControllersWithViews()
                .ConfigureApiBehaviorOptions(options =>
                {
                    options.SuppressModelStateInvalidFilter = true;
                })
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.Converters.Add(new HierarchyJsonConverter());
                });
        }



        public void ConfigureContainer(ContainerBuilder containerBuilder)
        {
            containerBuilder
                .RegisterConfiguredModulesFromCurrentAssembly(Configuration);
        }



        public void ConfigureDevelopment(IApplicationBuilder applicationBuilder)
        {
            applicationBuilder
                .UseDeveloperExceptionPage()
                .UseSwagger();

            Configure(applicationBuilder);
        }
        public void Configure(IApplicationBuilder applicationBuilder)
        {
            applicationBuilder
                .UseStaticFiles()
                .UseRouting()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapControllerRoute(
                        name: "default",
                        pattern: "{controller=Home}/{action=Index}/{id?}");

                    endpoints.MapControllers();
                });
        }

    }
}