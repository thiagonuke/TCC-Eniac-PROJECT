using UrbanFarming.Domain.Classes;

namespace UrbanFarming.Domain.Interfaces.Repositories
{
    public interface IProdutosRepository
    {
        Task<Produtos> GetByCodigo(string codigo);
        Task<List<Produtos>> GetAllProdutos();
        Task<bool> PostProduto(Produtos produto);
        Task<bool> DeleteProduto(string codigo);
        Task<bool> PutProduto(Produtos produto);
    }
}
