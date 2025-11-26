using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UrbanFarming.Domain.Classes;
using UrbanFarming.Domain.Interfaces.Services;

namespace UrbanFarmingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SegurancaController : ControllerBase
    {
        [HttpPost("CadastrarUsuario")]
        public async Task<IActionResult> CadastrarUsuario(Login usuario, [FromServices] ILoginService loginService)
            => Ok(await loginService.CadastrarUsuario(usuario));

        [HttpGet("Login")]
        public async Task<IActionResult> Login(string email, string senha, [FromServices] ILoginService loginService)
        {
            var usuario = await loginService.Login(email, senha);

            if (usuario == null)
            {
                return Unauthorized(new { mensagem = "Credenciais inválidas." });
            }

            return Ok(usuario);
        }
    }
}
