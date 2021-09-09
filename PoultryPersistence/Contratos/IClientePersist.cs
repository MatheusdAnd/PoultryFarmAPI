using System.Threading.Tasks;
using PoultryDomain;

namespace PoultryPersistence.Contratos
{
    public interface IClientePersist
    {
        Task<Cliente[]> GetAllClientesAsync();
        Task<Cliente[]> GetAllClientesByNomeAsync(string nome);  
        Task<Cliente> GetClienteByCPFAsync(string cpf);
        Task<Cliente> GetClienteByIdAsync(int clienteId);  
    }
}