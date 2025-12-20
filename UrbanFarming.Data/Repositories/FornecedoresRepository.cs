using Microsoft.EntityFrameworkCore;
using UrbanFarming.Data.Context;
using UrbanFarming.Domain.Classes;
using UrbanFarming.Domain.Interfaces.Repositories;
using UrbanFarming.Repositories;

namespace UrbanFarming.Data.Repositories
{
    public class FornecedoresRepository : BaseRepository<Fornecedores>, IFornecedoresRepository
    {
        public FornecedoresRepository(UrbanContext context) : base(context)
        {
             
        }
        
        public async Task<Fornecedores> GetByCodigo(int codigo) 
        {
            try
            {
                return await _context.Fornecedores.FirstOrDefaultAsync(f => f.Codigo == codigo);
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro: {ex.Message}");
            }
        }

        public async Task<List<Fornecedores>?> GetAllFornecedores()
        {
            return await _context.Fornecedores.ToListAsync();
        }

        public async Task<bool> PostFornecedor(Fornecedores fornecedores)
        {
            try
            {
                fornecedores.Codigo = 0;

                await _context.Fornecedores.AddAsync(fornecedores);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao cadastrar fornecedor: {ex.Message}");
            }
        }


        public async Task<bool> PutFornecedor(Fornecedores fornecedor)
        {
            try
            {
                var fornecedorExistente = await _context.Fornecedores.FindAsync(fornecedor.Codigo);

                if (fornecedorExistente == null)
                {
                    return false; 
                }

                fornecedorExistente.Codigo = fornecedor.Codigo;
                fornecedorExistente.RazaoSocial = fornecedor.RazaoSocial;
                fornecedorExistente.NomeFantasia = fornecedor.NomeFantasia;
                fornecedorExistente.CNPJ = fornecedor.CNPJ;
                fornecedorExistente.PaisOrigem = fornecedor.PaisOrigem;
                fornecedorExistente.Email = fornecedor.Email;
                fornecedorExistente.PessoaJuridica = fornecedor.PessoaJuridica;
                fornecedorExistente.PessoaFisica = fornecedor.PessoaFisica;
                await _context.SaveChangesAsync();

                return true; 
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro: {ex.Message}");
            }
        }

        public async Task<bool> DeleteFornecedor(int codigo)
        {
            try
            {
                var fornecedor = await _context.Fornecedores.FindAsync(codigo);

                if (fornecedor == null)
                    return false;

                _context.Fornecedores.Remove(fornecedor);

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
