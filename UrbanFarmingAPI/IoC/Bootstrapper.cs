using UrbanFarming.IoC.Modules;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace ProjetoModeloApi.IoC
{
    public static class Bootstrapper
    {
        public static IServiceCollection StartRegisterServices(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            RepositoryModule.InjectDependencies(services);
            ServiceModule.InjectDependencies(services);
            return services;
        }
    }
}
