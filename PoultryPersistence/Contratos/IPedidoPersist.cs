using System;
using System.Threading.Tasks;
using PoultryDomain;

namespace PoultryPersistence.Contratos
{
    public interface IPedidoPersist
    {
        Task<Pedido[]> GetAllPedidosAsync();
        Task<Pedido[]> GetAllPedidosByClienteAsync(int clienteId);  
        Task<Pedido[]> GetAllPedidosByDtPedidoAsync(DateTime dtPedido);
        Task<Pedido> GetPedidoByIdAsync(int pedidoId);
    }
}