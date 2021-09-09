using System.Collections;
using System.Threading.Tasks;
using PoultryApplication.DTOs;

namespace PoultryApplication.Contratos
{
    public interface IEnderecoService
    {
        Task<EnderecoDTO> AddEndereco(EnderecoDTO model);
        Task<EnderecoDTO> UpdateEndereco(int enderecoId, EnderecoDTO model);
        Task<bool> DeleteEndereco(int enderecoId);
        Task<EnderecoDTO[]> GetAllEnderecosAsync();
        Task<EnderecoDTO[]> GetAllEnderecosByClienteAsync(int clienteId);  
        Task<EnderecoDTO> GetEnderecoByIdAsync(int enderecoId);
    }
}