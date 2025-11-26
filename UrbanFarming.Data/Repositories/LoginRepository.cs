using Microsoft.EntityFrameworkCore;
using UrbanFarming.Data.Context;
using UrbanFarming.Domain.Classes;
using UrbanFarming.Domain.Interfaces.Repositories;
using UrbanFarming.Repositories;

namespace UrbanFarming.Data.Repositories
{
    public class LoginRepository : BaseRepository<Login>, ILoginRepository
    {
        public LoginRepository(UrbanContext context) : base(context)
        {

        }
        
        public async Task<Login> GetByEmail(string email) 
        {
            try
            {
                return await _context.Login.FirstOrDefaultAsync(u => u.Email == email);
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro: {ex.Message}");
            }
        }

        public async Task<bool> PostUsuario(Login usuario)
        {
            try
            {
                await _context.Login.AddAsync(usuario);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex) 
            {
                return false;
            }
        }      

        public async Task<bool> PutUsuario(Login usuario)
        {
            try
            {
                var usuarioExistente = await _context.Login.FirstOrDefaultAsync(u => u.Email == usuario.Email);

                if (usuarioExistente == null)
                {
                    return false;
                }

                usuarioExistente.Email = usuario.Email;
                usuarioExistente.Senha = usuario.Senha;
                usuarioExistente.Nome = usuario.Nome;
                usuarioExistente.Administrador = usuario.Administrador;
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro: {ex.Message}");
            }
        }

        public async Task<bool> DeleteUsuario(string email)
        {
            try
            {
                var usuario = await _context.Fornecedores.FindAsync(email);

                if (usuario == null)
                    return false;

                _context.Fornecedores.Remove(usuario);

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
