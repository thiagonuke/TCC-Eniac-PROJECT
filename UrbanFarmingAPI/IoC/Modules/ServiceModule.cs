using UrbanFarming.Domain.Interfaces.Services;
using UrbanFarming.Service.AppService;

namespace UrbanFarming.IoC.Modules
{
    public class ServiceModule
    {
        public static void InjectDependencies(IServiceCollection services)
        {
            services.AddTransient<ILoginService, LoginService>();
            services.AddTransient<IProdutosService, ProdutosService>();
            services.AddTransient<IFornecedoresService, FornecedoresService>();
            services.AddTransient<IPedidosService, PedidosService>();
            services.AddTransient<EmailService>();
        }
    }
}


