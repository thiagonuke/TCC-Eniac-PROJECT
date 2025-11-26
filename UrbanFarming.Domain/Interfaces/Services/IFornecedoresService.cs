using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrbanFarming.Domain.Classes;

namespace UrbanFarming.Domain.Interfaces.Services
{
    public interface IFornecedoresService
    {
        Task<Fornecedores> GetByCodigo(int codigo);
        Task<List<Fornecedores>> GetAllFornecedores();
        Task<bool> PostFornecedor(Fornecedores fornecedor); 
        Task<bool> PutFornecedor(Fornecedores fornecedor);
        Task<bool> DeleteFornecedor(int codigo);
    }
}
