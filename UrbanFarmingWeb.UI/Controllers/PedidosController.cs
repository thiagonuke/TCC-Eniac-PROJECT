using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UrbanFarming.Domain.Classes;
using UrbanFarmingWeb.UI.Request;
using UrbanFarmingWeb.UI.Util;

namespace UrbanFarmingWeb.UI.Controllers
{
	public class PedidosController : Controller
	{
        private readonly RequestAPI _requestAPI;
        public PedidosController(RequestAPI requestAPI) { 
        
            _requestAPI = requestAPI;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.Get<User>("USER") != null)
            {
                ViewBag.Name = HttpContext.Session.Get<User>("USER").Nome;
            }

            var pedidos = _requestAPI.ListaPedidos().Result;

            return View(pedidos);
        }

        [HttpPost]
        public IActionResult CadastrarPedidos([FromBody] Pedido pedido)
        {
            pedido.Data = DateTime.Now;
            pedido.Usuario = HttpContext.Session.Get<User>("USER").Nome;

          
            var teste = _requestAPI.EfetuarCadastradoPedido(pedido).Result;

            return Ok("Pedido cadastrado com sucesso!");
            
        }
    }
}
