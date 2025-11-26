
using Microsoft.AspNetCore.Mvc;
using UrbanFarming.Domain.Classes;
using UrbanFarming.Domain.Exceptions;
using UrbanFarming.Domain.Interfaces.Services;

namespace UrbanFarmingAPI.Controllers
{
    [Route("api/[controller]")]
    public class FornecedoresController : ControllerBase
    {
        private readonly IFornecedoresService _fornecedoresService;

        public FornecedoresController(IFornecedoresService fornecedoresService)
        {
            _fornecedoresService = fornecedoresService;
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarFornecedor([FromBody]Fornecedores fornecedor)
        {
            if (fornecedor == null)
            {
                return BadRequest(new { mensagem = "Fornecedor inválido." });
            }

            var sucesso = await _fornecedoresService.PostFornecedor(fornecedor);

            if (!sucesso)
            {
                return BadRequest(new { mensagem = "Não foi possível cadastrar o fornecedor." });
            }

            return Ok(new { mensagem = "Fornecedor cadastrado com sucesso." });
        }

        [HttpGet("{codigo}")]
        public async Task<IActionResult> GetByCodigo(int codigo)
        {
            try
            {
                var Fornecedor = await _fornecedoresService.GetByCodigo(codigo);
                return Ok(Fornecedor);
            }
            catch (NotFoundException ex)
            {
                return NotFound(new { mensagem = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFornecedores()
        {
            var Fornecedores = await _fornecedoresService.GetAllFornecedores();
            return Ok(Fornecedores);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFornecedor([FromBody] Fornecedores fornecedor)
        {
            if (fornecedor == null)
            {
                return BadRequest(new { mensagem = "Fornecedor inválido." });
            }

            var sucesso = await _fornecedoresService.PutFornecedor(fornecedor);

            if (!sucesso)
            {
                return NotFound(new { mensagem = "Fornecedor não encontrado." });
            }

            return Ok(new { mensagem = "Fornecedor atualizado com sucesso." });
        }

        [HttpDelete("{codigo}")]
        public async Task<IActionResult> DeleteFornecedor(int codigo)
        {
            var sucesso = await _fornecedoresService.DeleteFornecedor(codigo);

            if (!sucesso)
            {
                return NotFound(new { mensagem = "Fornecedor não encontrado." });
            }

            return Ok(new { mensagem = "Fornecedor deletado com sucesso." });
        }
    }
}