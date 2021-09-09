using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PoultryApplication.Contratos;
using PoultryApplication.DTOs;

namespace PoultryAPI.Controllers
{
    [ApiController]
    [Route("api/cliente")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;
        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(ClienteDTO model)
        {
            try
            {
                //Validação dados cliente
                var resposta = await _clienteService.ValidarCliente(model);
                if (resposta != null)
                {
                    return StatusCode(Convert.ToInt16(resposta[0]), resposta[1].ToString());
                }
                var cliente = await _clienteService.AddCliente(model);
                if (cliente == null) return NoContent();

                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                       $"Erro ao tentar adicionar cliente. Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ClienteDTO model)
        {
            try
            {
                //Validações                
                if (model.tCelular == null )
                {
                    if (model.tFixo == null)
                    {
                        return StatusCode(400, $"É necessário que seja inserido um número de telefone");
                    }
                }
                //Atualizar Cliente
                var cliente = await _clienteService.UpdateCliente(id, model);
                if (cliente == null) return NoContent();

                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                       $"Erro ao tentar atualizar cliente. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return await _clienteService.DeleteCliente(id) ?
                Ok("Deletado.") :
                BadRequest("Cliente não deletado");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar deletar cliente. Erro: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var clientes = await _clienteService.GetAllClientesAsync();
                if (clientes == null) return NoContent();

                return Ok(clientes);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                       $"Erro ao tentar recuperar clientes. Erro: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var cliente = await _clienteService.GetClienteByIdAsync(id);
                if (cliente == null) return NoContent();

                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                       $"Erro ao tentar recuperar cliente. Erro: {ex.Message}");
            }
        }

        [HttpGet("nome/{nome}")]
        public async Task<IActionResult> GetByNome(string nome)
        {
            try
            {
                var cliente = await _clienteService.GetAllClientesByNomeAsync(nome);
                if (cliente == null) return NoContent();

                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                       $"Erro ao tentar recuperar clientes. Erro: {ex.Message}");
            }
        }

        [HttpGet("cpf/{cpf}")]
        public async Task<IActionResult> GetByCPF(string cpf)
        {
            try
            {
                var cliente = await _clienteService.GetClienteByCPFAsync(cpf);
                if (cliente == null) return NoContent();

                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                       $"Erro ao tentar recuperar cliente. Erro: {ex.Message}");
            }
        }
    }
}
