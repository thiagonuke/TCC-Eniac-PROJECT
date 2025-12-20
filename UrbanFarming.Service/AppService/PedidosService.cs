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
        private readonly EmailService _emailService;
        private readonly IProdutosRepository _ProdutoRepository;
        private readonly IFornecedoresRepository _FornecedoresRepository;
        public PedidosService(IPedidosRepository PedidosRepository, EmailService emailService, IProdutosRepository produtosRepository, IFornecedoresRepository fornecedoresRepository)
        {
            _PedidosRepository = PedidosRepository;
            _emailService = emailService;
            _ProdutoRepository = produtosRepository;
            _FornecedoresRepository = fornecedoresRepository;
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

            foreach (var item in Pedido.Itens)
            {
                var dados = await _ProdutoRepository.GetByCodigo(Convert.ToString(item.CodigoProduto));

                var emailFornecedor = _FornecedoresRepository.GetByCodigo(dados.Fornecedor).Result;
                var mensagemSistema = string.Empty;

                mensagemSistema = emailFornecedor.MensagemPadraoEmail.Replace("{quantidade}", item.Quantidade.ToString());
                mensagemSistema = mensagemSistema.Replace("{produto}", item.NomeProduto);


                _emailService.EnviarEmailAsync(emailFornecedor.Email, "Pedido Zentrix", mensagemSistema);

            }

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
