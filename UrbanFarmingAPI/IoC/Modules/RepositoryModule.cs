using UrbanFarming.Data.Repositories;
using UrbanFarming.Domain.Interfaces.Repositories;
using UrbanFarming.Domain.Interfaces.Services;
using UrbanFarming.Service.AppService;

namespace UrbanFarming.IoC.Modules
{
    public class RepositoryModule
    {
        public static void InjectDependencies(IServiceCollection services)
        {
            services.AddTransient<ILoginRepository, LoginRepository>();
            services.AddTransient<IProdutosRepository, ProdutosRepository>();
            services.AddTransient<IFornecedoresRepository, FornecedoresRepository>();
            services.AddTransient<IPedidosRepository, PedidosRepository>();
        }
    }
}
