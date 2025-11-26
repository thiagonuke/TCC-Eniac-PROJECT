using UrbanFarming.Domain.Classes;

namespace UrbanFarming.Domain.Interfaces.Repositories
{
    public interface IFornecedoresRepository
    {
        Task<Fornecedores> GetByCodigo(int codigo);
        Task<List<Fornecedores>> GetAllFornecedores();
        Task<bool> PostFornecedor(Fornecedores fornecedor);
        Task<bool> PutFornecedor(Fornecedores fornecedor);
        Task<bool> DeleteFornecedor(int codigo);
    }
}
