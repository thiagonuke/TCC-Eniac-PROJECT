using UrbanFarming.Domain.Classes;

namespace UrbanFarming.Domain.Interfaces.Repositories
{
    public interface IPedidosRepository
    {
        Task<Pedido> GetByCodigo(int codigo);
        Task<List<Pedido>> GetAllPedidos();
        Task<bool> PostPedido(Pedido Pedido);
        Task<bool> DeletePedido(int codigo);
        Task<bool> PutPedido(Pedido Pedido);
    }
}
