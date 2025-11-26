using UrbanFarming.Domain.Classes;

namespace UrbanFarming.Domain.Interfaces.Services
{
    public interface IPedidosService
    {
        Task<Pedido> GetByCodigo(int codigo);
        Task<List<Pedido>> GetAllPedidos();
        Task<bool> PostPedido(Pedido Pedido); 
        Task<bool> PutPedido(Pedido Pedido);
        Task<bool> DeletePedido(int codigo);
    }
}
