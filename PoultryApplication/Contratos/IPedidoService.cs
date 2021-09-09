using System;
using System.Collections;
using System.Threading.Tasks;
using PoultryApplication.DTOs;

namespace PoultryApplication.Contratos
{
    public interface IPedidoService
    {
        Task<PedidoDTO> AddPedido(PedidoDTO model);
        Task<PedidoDTO[]> GetAllPedidosAsync();
        Task<PedidoDTO[]> GetAllPedidosByClienteAsync(int clienteId);  
        Task<PedidoDTO[]> GetAllPedidosByDtPedidoAsync(DateTime dtPedido);
        Task<PedidoDTO> GetPedidoByIdAsync(int pedidoId);
    }
}