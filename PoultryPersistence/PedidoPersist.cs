using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PoultryDomain;
using PoultryPersistence.Contextos;
using PoultryPersistence.Contratos;

namespace PoultryPersistence
{
    public class PedidoPersist : IPedidoPersist
    {
        private readonly PoultryContext _context;
        public PedidoPersist(PoultryContext context)
        {
            _context = context;
        }

        public async Task<Pedido[]> GetAllPedidosAsync()
        {
            IQueryable<Pedido> query = _context.Pedido;

            query = query.AsNoTracking()
                         .Include(p => p.Cliente)
                         .Include(p => p.ItemPedido)
                         .ThenInclude(ip => ip.Produto);

            return await query.ToArrayAsync();
        }

        public async Task<Pedido[]> GetAllPedidosByClienteAsync(int clienteId)
        {
            IQueryable<Pedido> query = _context.Pedido;

            query = query.AsNoTracking()
                         .Where(p => p.ClienteId == clienteId)
                         .Include(p => p.Cliente)
                         .Include(p => p.ItemPedido)
                         .ThenInclude(ip => ip.Produto);

            return await query.ToArrayAsync();
        }

        public async Task<Pedido[]> GetAllPedidosByDtPedidoAsync(DateTime dtPedido)
        {
            IQueryable<Pedido> query = _context.Pedido;

            query = query.AsNoTracking()
                         .Where(p => p.dtPedido == dtPedido)
                         .Include(p => p.Cliente)
                         .Include(p => p.ItemPedido)
                         .ThenInclude(ip => ip.Produto);

            return await query.ToArrayAsync();
        }

        public async Task<Pedido> GetPedidoByIdAsync(int pedidoId)
        {
            IQueryable<Pedido> query = _context.Pedido;

            query = query.AsNoTracking()
                         .Where(p => p.Id == pedidoId)
                         .Include(p => p.Cliente)
                         .Include(p => p.ItemPedido)
                         .ThenInclude(ip => ip.Produto);

            return await query.FirstOrDefaultAsync();
        }
    }
}