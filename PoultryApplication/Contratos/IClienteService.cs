using System.Collections;
using System.Threading.Tasks;
using PoultryApplication.DTOs;

namespace PoultryApplication.Contratos
{
    public interface IClienteService
    {
        Task<ClienteDTO> AddCliente(ClienteDTO model);
        Task<ClienteDTO> UpdateCliente(int clienteId, ClienteDTO model);
        Task<bool> DeleteCliente(int clienteId);
        Task<ClienteDTO[]> GetAllClientesAsync();
        Task<ClienteDTO[]> GetAllClientesByNomeAsync(string nome); 
        Task<ClienteDTO> GetClienteByCPFAsync(string cpf);
        Task<ClienteDTO> GetClienteByIdAsync(int clienteId);  
        Task<ArrayList> ValidarCliente(ClienteDTO model);
    }
}