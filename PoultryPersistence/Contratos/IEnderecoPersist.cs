using System.Threading.Tasks;
using PoultryDomain;

namespace PoultryPersistence.Contratos
{
    public interface IEnderecoPersist
    {
        Task<Endereco[]> GetAllEnderecosAsync();
        Task<Endereco[]> GetEnderecosByClienteAsync(int clienteId);  
        Task<Endereco> GetEnderecoByIdAsync(int enderecoId);  
    }
}