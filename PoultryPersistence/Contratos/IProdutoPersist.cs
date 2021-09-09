using System.Threading.Tasks;
using PoultryDomain;

namespace PoultryPersistence.Contratos
{
    public interface IProdutoPersist
    {
        Task<Produto[]> GetAllProdutosAsync();
        Task<Produto[]> GetAllProdutosByNomeAsync(string nome);  
        Task<Produto> GetProdutoByIdAsync(int produtoId);
    }
}