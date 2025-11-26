using UrbanFarming.Domain.Classes;

namespace UrbanFarming.Domain.Interfaces.Repositories
{
    public interface ILoginRepository
    {
        Task<Login> GetByEmail(string email);
        Task<bool> PostUsuario(Login usuario);
        Task<bool> PutUsuario(Login usuario);
        Task<bool> DeleteUsuario(string email);
    }
}
