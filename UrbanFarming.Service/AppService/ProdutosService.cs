using System.Security.Cryptography;
using System.Text;
using UrbanFarming.Domain.Classes;
using UrbanFarming.Domain.Exceptions;
using UrbanFarming.Domain.Interfaces.Repositories;
using UrbanFarming.Domain.Interfaces.Services;

namespace UrbanFarming.Service.AppService
{
    public class ProdutosService : IProdutosService
    {
        private readonly IProdutosRepository _produtosRepository;

        public ProdutosService(IProdutosRepository produtosRepository)
        {
            _produtosRepository = produtosRepository;
        }

        public async Task<Produtos> GetByCodigo(string codigo)
        {
            var produto = await _produtosRepository.GetByCodigo(codigo);
            if (produto == null)
            {
                throw new NotFoundException("Produto não encontrado.");
            }
            return produto;
        }

        public async Task<List<Produtos>> GetAllProdutos()
        {
            return await _produtosRepository.GetAllProdutos();
        }

        public async Task<bool> PostProduto(Produtos produto)
        {
            var sucesso = await _produtosRepository.PostProduto(produto);

            if (!sucesso)
                throw new Exception("Não foi possível cadastrar o produto.");

            return sucesso;
        }

        public async Task<bool> PutProduto(Produtos produto)
        {
            var existingProduto = await _produtosRepository.GetByCodigo(produto.Codigo);
            if (existingProduto == null)
            {
                throw new NotFoundException("Produto não encontrado.");
            }

            return await _produtosRepository.PutProduto(produto);
        }

        public async Task<bool> DeleteProduto(string codigo)
        {
            var existingProduto = await _produtosRepository.GetByCodigo(codigo);
            if (existingProduto == null)
            {
                throw new NotFoundException("Produto não encontrado.");
            }

            return await _produtosRepository.DeleteProduto(codigo);
        }
    }
}
