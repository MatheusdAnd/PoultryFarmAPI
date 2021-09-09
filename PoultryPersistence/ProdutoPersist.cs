using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PoultryDomain;
using PoultryPersistence.Contextos;
using PoultryPersistence.Contratos;

namespace PoultryPersistence
{
    public class ProdutoPersist : IProdutoPersist
    {
        private readonly PoultryContext _context;
        public ProdutoPersist(PoultryContext context)
        {
            _context = context;
        }
        public async Task<Produto[]> GetAllProdutosAsync()
        {
            IQueryable<Produto> query = _context.Produto;

            query = query.AsNoTracking()
                         .OrderBy(p => p.nome);

            return await query.ToArrayAsync();
        }

        public async Task<Produto[]> GetAllProdutosByNomeAsync(string nome)
        {
            IQueryable<Produto> query = _context.Produto;

            query = query.AsNoTracking()
                         .OrderBy(p => p.nome)
                         .Where(p => p.nome.ToLower().Contains(nome.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Produto> GetProdutoByIdAsync(int produtoId)
        {
            IQueryable<Produto> query = _context.Produto;

            query = query.AsNoTracking()
                         .Where(p => p.Id == produtoId);
                         
            return await query.FirstOrDefaultAsync();
        }
    }
}