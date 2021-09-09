using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PoultryApplication.Contratos;
using PoultryApplication.DTOs;

namespace PoultryAPI.Controllers
{
    [ApiController]
    [Route("api/pedido")]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoService _pedidoService;
        public PedidoController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        [HttpPost]
        public async Task <IActionResult> Post(PedidoDTO model)
        {
            try
            {
                var pedido = await _pedidoService.AddPedido(model);
                if (pedido == null) return NoContent();

                return Ok(pedido);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                       $"Erro ao tentar adicionar Pedido. Erro: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var pedidos = await _pedidoService.GetAllPedidosAsync();
                if (pedidos == null) return NoContent();

                return Ok(pedidos);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                       $"Erro ao tentar recuperar Pedidos. Erro: {ex.Message}");
            }
        }   

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var pedidos = await _pedidoService.GetPedidoByIdAsync(id);
                if (pedidos == null) return NoContent();

                return Ok(pedidos);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                       $"Erro ao tentar recuperar Pedido. Erro: {ex.Message}");
            }
        }

        [HttpGet("cliente/{id}")]
        public async Task<IActionResult> GetByCliente(int id)
        {
            try
            {
                var pedidos = await _pedidoService.GetAllPedidosByClienteAsync(id);
                if (pedidos == null) return NoContent();

                return Ok(pedidos);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                       $"Erro ao tentar recuperar Pedidos. Erro: {ex.Message}");
            }
        }    

        [HttpGet("dtpedido/{dtpedido}")]
        public async Task<IActionResult> GetByDtPedido(DateTime dtpedido)
        {
            try
            {
                var pedidos = await _pedidoService.GetAllPedidosByDtPedidoAsync(dtpedido);
                if (pedidos == null) return NoContent();

                return Ok(pedidos);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                                       $"Erro ao tentar recuperar Pedidos. Erro: {ex.Message}");
            }
        }              
    }
}