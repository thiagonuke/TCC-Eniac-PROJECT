using Microsoft.AspNetCore.Mvc;
using UrbanFarming.Domain.Classes;
using UrbanFarmingWeb.UI.Request;
using UrbanFarmingWeb.UI.Util;

namespace UrbanFarmingWeb.UI.Controllers
{
    public class ProdutosController : Controller
    {

        private readonly RequestAPI _request;

        public ProdutosController(RequestAPI req)
        {
            _request = req;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.Get<User>("USER") != null)
            {
                ViewBag.Name = HttpContext.Session.Get<Login>("USER").Nome;

                ViewBag.Adm = HttpContext.Session.Get<Login>("USER").Administrador;  
            }

            var produtos = _request.ListaProdutos().Result;

            return View(produtos);
        }

        public IActionResult Cadastrar([FromBody] Produtos produto)
        {
            if (ModelState.IsValid)
            {
                var cadastro = _request.EfetuarCadastradoProduto(produto).Result;

                return Ok(new { message = "Produto cadastrado com sucesso!" });
            }

            return BadRequest("Erro ao cadastrar o produto.");
        }
        public IActionResult Deletar([FromBody] string produto)
        {
            try
            {
                var cadastro = _request.EfetuarDeleteProduto(produto).Result;

                return Ok(new { message = "Produto cadastrado com sucesso!" });

            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao cadastrar o produto.");
            }
          
        }
    }
}
