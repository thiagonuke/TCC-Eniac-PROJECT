using Microsoft.AspNetCore.Mvc;
using UrbanFarming.Domain.Classes;
using UrbanFarming.Domain.Exceptions;
using UrbanFarming.Domain.Interfaces.Services;

namespace UrbanFarmingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutosService _produtosService;

        public ProdutosController(IProdutosService produtosService)
        {
            _produtosService = produtosService;
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarProduto([FromBody] Produtos produto)
            {
            if (produto == null)
            {
                return BadRequest(new { mensagem = "Produto inválido." });
            }

            var sucesso = await _produtosService.PostProduto(produto);

            if (!sucesso)
            {
                return BadRequest(new { mensagem = "Não foi possível cadastrar o produto." });
            }

            return Ok(new { mensagem = "Produto cadastrado com sucesso." });
        }

        [HttpGet("{codigo}")]
        public async Task<IActionResult> GetByCodigo(string codigo)
        {
            try
            {
                var produto = await _produtosService.GetByCodigo(codigo);
                return Ok(produto);
            }
            catch (NotFoundException ex)
            {
                return NotFound(new { mensagem = ex.Message });
            }
        }

        [HttpGet("GetAllProdutos")]
        public async Task<IActionResult> GetAllProdutos()
        {
            var produtos = await _produtosService.GetAllProdutos();
            return Ok(produtos);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduto([FromBody] Produtos produto)
        {
            if (produto == null || string.IsNullOrWhiteSpace(produto.Codigo))
            {
                return BadRequest(new { mensagem = "Produto inválido." });
            }

            var sucesso = await _produtosService.PutProduto(produto);

            if (!sucesso)
            {
                return NotFound(new { mensagem = "Produto não encontrado." });
            }

            return Ok(new { mensagem = "Produto atualizado com sucesso." });
        }

        [HttpDelete("{codigo}")]
        public async Task<IActionResult> DeleteProduto(string codigo)
        {
            var sucesso = await _produtosService.DeleteProduto(codigo);

            if (!sucesso)
            {
                return NotFound(new { mensagem = "Produto não encontrado." });
            }

            return Ok(new { mensagem = "Produto deletado com sucesso." });
        }
    }
}