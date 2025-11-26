using System.Security.Cryptography;
using System.Text;
using UrbanFarming.Domain.Classes;
using UrbanFarming.Domain.Exceptions;
using UrbanFarming.Domain.Interfaces.Repositories;
using UrbanFarming.Domain.Interfaces.Services;

namespace UrbanFarming.Service.AppService
{
    public class PedidosService : IPedidosService
    {
        private readonly IPedidosRepository _PedidosRepository;

        public PedidosService(IPedidosRepository PedidosRepository)
        {
            _PedidosRepository = PedidosRepository;
        }

        public async Task<Pedido> GetByCodigo(int codigo)
        {
            var Pedido = await _PedidosRepository.GetByCodigo(codigo);
            if (Pedido == null)
            {
                throw new NotFoundException("Pedido não encontrado.");
            }
            return Pedido;
        }

        public async Task<List<Pedido>> GetAllPedidos()
        {
            return await _PedidosRepository.GetAllPedidos();
        }

        public async Task<bool> PostPedido(Pedido Pedido)
        {
            var sucesso = await _PedidosRepository.PostPedido(Pedido);

            if (!sucesso)
                throw new Exception("Não foi possível cadastrar o Pedido.");

            return sucesso;
        }

        public async Task<bool> PutPedido(Pedido Pedido)
        {
            var existingPedido = await _PedidosRepository.GetByCodigo(Pedido.CodigoPedido);
            if (existingPedido == null)
            {
                throw new NotFoundException("Pedido não encontrado.");
            }

            return await _PedidosRepository.PutPedido(Pedido);
        }

        public async Task<bool> DeletePedido(int codigo)
        {
            var existingPedido = await _PedidosRepository.GetByCodigo(codigo);
            if (existingPedido == null)
            {
                throw new NotFoundException("Pedido não encontrado.");
            }

            return await _PedidosRepository.DeletePedido(codigo);
        }
    }
}
