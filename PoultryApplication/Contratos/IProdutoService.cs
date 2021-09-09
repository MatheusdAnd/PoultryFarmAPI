using System.Collections;
using System.Threading.Tasks;
using PoultryApplication.DTOs;

namespace PoultryApplication.Contratos
{
    public interface IProdutoService
    {
        Task<ProdutoDTO> AddProduto(ProdutoDTO model);
        Task<ProdutoDTO> UpdateProduto(int produtoId, ProdutoDTO model);
        Task<bool> DeleteProduto(int produtoId);
        Task<ProdutoDTO[]> GetAllProdutosAsync();
        Task<ProdutoDTO[]> GetAllProdutosByNomeAsync(string nome);  
        Task<ProdutoDTO> GetProdutoByIdAsync(int produtoId);
    }
}