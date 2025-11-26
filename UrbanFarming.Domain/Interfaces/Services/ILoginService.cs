using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrbanFarming.Domain.Classes;

namespace UrbanFarming.Domain.Interfaces.Services
{
    public interface ILoginService
    {
        Task<bool> CadastrarUsuario(Login usuario);
        Task<Login> Login(string email, string senha);
    }
}
