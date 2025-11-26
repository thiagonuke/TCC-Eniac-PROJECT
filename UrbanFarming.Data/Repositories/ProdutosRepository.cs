using Microsoft.EntityFrameworkCore;
using UrbanFarming.Data.Context;
using UrbanFarming.Domain.Classes;
using UrbanFarming.Domain.Interfaces.Repositories;
using UrbanFarming.Repositories;

namespace UrbanFarming.Data.Repositories
{
    public class ProdutosRepository : BaseRepository<Produtos>, IProdutosRepository
    {
        public ProdutosRepository(UrbanContext context) : base(context)
        {

        }
        
        public async Task<Produtos> GetByCodigo(string codigo) 
        {
            try
            {
                return await _context.Produtos.FirstOrDefaultAsync(u => u.Codigo == codigo);
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro: {ex.Message}");
            }
        }

        public async Task<List<Produtos>> GetAllProdutos()
        {
            return await _context.Produtos.ToListAsync();
        }

        public async Task<bool> PostProduto(Produtos produto)
        {
            try
            {
                await _context.Produtos.AddAsync(produto);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex) 
            {
                throw new Exception($"Ocorreu um erro: {ex.Message}");
            }
        }

        public async Task<bool> DeleteProduto(string codigo)
        {
            try
            {
                var produto = await _context.Produtos.FindAsync(codigo);

                if (produto == null)
                    return false;

                _context.Produtos.Remove(produto);

                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro: {ex.Message}");
            }
        }

        public async Task<bool> PutProduto(Produtos produto)
        {
            try
            {
                var existingProduto = await _context.Produtos.FindAsync(produto.Codigo);

                if (existingProduto == null)
                {
                    return false; 
                }

                existingProduto.Codigo = produto.Codigo;
                existingProduto.Nome = produto.Nome;
                existingProduto.Valor = produto.Valor;
                existingProduto.Descricao = produto.Descricao;

                await _context.SaveChangesAsync();

                return true; 
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro: {ex.Message}");
            }
        }

    }
}
