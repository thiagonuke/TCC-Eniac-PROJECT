using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrbanFarming.Domain.Classes;

namespace UrbanFarming.Domain.Interfaces.Services
{
    public interface IProdutosService
    {
        Task<Produtos> GetByCodigo(string codigo);
        Task<List<Produtos>> GetAllProdutos();
        Task<bool> PostProduto(Produtos produto); 
        Task<bool> PutProduto(Produtos produto);
        Task<bool> DeleteProduto(string codigo);
    }
}
