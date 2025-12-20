using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UrbanFarming.Domain.Classes;
using UrbanFarmingWeb.UI.Request;
using UrbanFarmingWeb.UI.Util;

namespace UrbanFarmingWeb.UI.Controllers
{
    [Route("[controller]")]
    public class FornecedorController : Controller
    {

        private readonly RequestAPI _request;

        public FornecedorController(RequestAPI req)
        {
            _request = req;
        }

        [HttpGet("Index")]
        public IActionResult Index()
        {
            if (HttpContext.Session.Get<User>("USER") != null)
            {
                ViewBag.Name = HttpContext.Session.Get<User>("USER").Nome;
            }
            return View();
        }


        [HttpPost("CadastrarFornecedor")]
        public async Task<IActionResult> CadastrarFornecedor([FromBody]Fornecedores fornecedor)
        {
            string response = string.Empty;

          
             _request.EfetuarCadastradoFornecedor(fornecedor);


            return Json(response);
        }

        [HttpGet("GetAllFornecedores")]
        public async Task<IActionResult> GetAllFornecedores()
        {
            var lista = await _request.GetFornecedores();

            return Json(lista);
        }
    }
}
