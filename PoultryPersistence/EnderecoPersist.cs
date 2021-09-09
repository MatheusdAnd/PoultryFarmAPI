using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PoultryDomain;
using PoultryPersistence.Contextos;
using PoultryPersistence.Contratos;

namespace PoultryPersistence
{
    public class EnderecoPersist : IEnderecoPersist
    {
        private readonly PoultryContext _context;
        public EnderecoPersist(PoultryContext context)
        {
            _context = context;
        }
        public async Task<Endereco[]> GetAllEnderecosAsync()
        {
            IQueryable<Endereco> query = _context.Endereco;

            query = query.AsNoTracking()
                         .OrderBy(e => e.nome)
                         .Include(e => e.Cliente);

            return await query.ToArrayAsync();
        }

        public async Task<Endereco> GetEnderecoByIdAsync(int enderecoId)
        {
            IQueryable<Endereco> query = _context.Endereco;

            query = query.AsNoTracking()
                         .OrderBy(e => e.nome)
                         .Where(e => e.Id == enderecoId);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Endereco[]> GetEnderecosByClienteAsync(int clienteId)
        {
            IQueryable<Endereco> query = _context.Endereco;

            query = query.AsNoTracking()
                         .OrderBy(e => e.nome)
                         .Where(e => e.ClienteId == clienteId)
                         .Include(e => e.Cliente);
            return await query.ToArrayAsync();
        }
    }
}