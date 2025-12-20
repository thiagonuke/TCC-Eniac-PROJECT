using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrbanFarming.Domain.Interfaces.Services
{
    public interface IEmailService
    {
        Task EnviarEmailAsync(string para, string assunto, string mensagemHtml);
    }
}
