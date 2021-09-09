using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PoultryApplication.Contratos;
using PoultryApplication.DTOs;

namespace PoultryAPI.Controllers
{
    [ApiController]
    [Route("api/endereco")]
    public class EnderecoController : ControllerBase
    {
        private readonly IEnderecoService _enderecoService;
        public EnderecoController(IEnderecoService enderecoService)
        {
            _enderecoService = enderecoService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(EnderecoDTO model)
        {
            try
            {
                var endereco = await _enderecoService.AddEndereco(model);
                if (endereco == null) return NoContent();

                return Ok(endereco);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                       $"Erro ao tentar adicionar endereço. Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, EnderecoDTO model)
        {
            try
            {
                var endereco = await _enderecoService.UpdateEndereco(id, model);
                if (endereco == null) return NoContent();

                return Ok(endereco);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                       $"Erro ao tentar atualizar endereço. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return await _enderecoService.DeleteEndereco(id) ?
                Ok("Deletado.") :
                BadRequest("Endereço não deletado");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar deletar endereço. Erro: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var enderecos = await _enderecoService.GetAllEnderecosAsync();
                if (enderecos == null) return NoContent();

                return Ok(enderecos);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                       $"Erro ao tentar recuperar endereços. Erro: {ex.Message}");
            }
        }

        [HttpGet("clienteid/{id}")]
        public async Task<IActionResult> GetByCliente(int id)
        {
            try
            {
                var endereco = await _enderecoService.GetAllEnderecosByClienteAsync(id);
                if (endereco == null) return NoContent();

                return Ok(endereco);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                       $"Erro ao tentar recuperar endereço. Erro: {ex.Message}");
            }
        }

        [HttpGet("enderecoid/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var endereco = await _enderecoService.GetEnderecoByIdAsync(id);
                if (endereco == null) return NoContent();

                return Ok(endereco);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                       $"Erro ao tentar recuperar endereço. Erro: {ex.Message}");
            }
        }
    }
}
