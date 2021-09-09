using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PoultryDomain;
using PoultryPersistence.Contextos;
using PoultryPersistence.Contratos;

namespace PoultryPersistence
{
    public class ClientePersist : IClientePersist
    {
        private readonly PoultryContext _context;
        public ClientePersist(PoultryContext context)
        {
            _context = context;
        }
        public async Task<Cliente[]> GetAllClientesAsync()
        {
            IQueryable<Cliente> query = _context.Cliente;
            query = query.AsNoTracking()
                         .OrderBy(c => c.nome)
                         .Include(c => c.Endereco);
            return await query.ToArrayAsync();
        }

        public async Task<Cliente[]> GetAllClientesByNomeAsync(string nome)
        {
            IQueryable<Cliente> query = _context.Cliente;

            query = query.AsNoTracking()
                         .OrderBy(c => c.nome)
                         .Where(c => c.nome.ToLower().Contains(nome.ToLower()))
                         .Include(c => c.Endereco);
            return await query.ToArrayAsync();
        }

        public async Task<Cliente> GetClienteByCPFAsync(string cpf)
        {
            IQueryable<Cliente> query = _context.Cliente;

            query = query.AsNoTracking()
                         .OrderBy(c => c.nome)
                         .Where(c => c.cpf == cpf)
                         .Include(c => c.Endereco);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Cliente> GetClienteByIdAsync(int clienteId)
        {
            IQueryable<Cliente> query = _context.Cliente;

            query = query.AsNoTracking()
                         .Where(c => c.Id == clienteId)
                         .Include(c => c.Endereco);
            return await query.FirstOrDefaultAsync();
        }
    }
}