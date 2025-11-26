using Microsoft.AspNetCore.Mvc;
using UrbanFarming.Domain.Classes;
using UrbanFarming.Domain.Exceptions;
using UrbanFarming.Domain.Interfaces.Services;

namespace UrbanFarmingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private readonly IPedidosService _PedidosService;

        public PedidosController(IPedidosService PedidosService)
        {
            _PedidosService = PedidosService;
        }

        [HttpPost("CadastrarPedido")]
        public async Task<IActionResult> CadastrarPedido([FromBody] Pedido pedido)
        {
            if (pedido == null || pedido.Itens == null || pedido.Itens.Count == 0)
            {
                return BadRequest(new { mensagem = "Pedido inválido." });
            }

            var sucesso = await _PedidosService.PostPedido(pedido);

            if (!sucesso)
            {
                return BadRequest(new { mensagem = "Não foi possível cadastrar o pedido." });
            }

            return Ok(new { mensagem = "Pedido cadastrado com sucesso." });
        }

        [HttpGet("{codigo}")]
        public async Task<IActionResult> GetByCodigo(int codigo) 
        {
            try
            {
                var pedido = await _PedidosService.GetByCodigo(codigo);
                return Ok(pedido);
            }
            catch (NotFoundException ex)
            {
                return NotFound(new { mensagem = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPedidos()
        {
            var pedidos = await _PedidosService.GetAllPedidos();
            return Ok(pedidos);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePedido([FromBody] Pedido pedido)
        {
            if (pedido == null || pedido.CodigoPedido <= 0) 
            {
                return BadRequest(new { mensagem = "Pedido inválido." });
            }

            var sucesso = await _PedidosService.PutPedido(pedido);

            if (!sucesso)
            {
                return NotFound(new { mensagem = "Pedido não encontrado." });
            }

            return Ok(new { mensagem = "Pedido atualizado com sucesso." });
        }

        [HttpDelete("{codigo}")]
        public async Task<IActionResult> DeletePedido(int codigo) 
        {
            var sucesso = await _PedidosService.DeletePedido(codigo);

            if (!sucesso)
            {
                return NotFound(new { mensagem = "Pedido não encontrado." });
            }

            return Ok(new { mensagem = "Pedido deletado com sucesso." });
        }
    }
}
