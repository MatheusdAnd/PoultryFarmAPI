using System;
using System.Collections;
using System.Threading.Tasks;
using AutoMapper;
using PoultryApplication.Contratos;
using PoultryApplication.DTOs;
using PoultryDomain;
using PoultryPersistence.Contratos;

namespace PoultryApplication
{
    public class ClienteService : IClienteService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IClientePersist _clientePersist;
        private readonly IMapper _mapper;
        public ClienteService(IGeralPersist geralPersist,
                              IClientePersist clientePersist,
                              IMapper mapper)
        {
            _geralPersist = geralPersist;
            _clientePersist = clientePersist;
            _mapper = mapper;
        }

        public async Task<ClienteDTO> AddCliente(ClienteDTO model)
        {
            try
            {
                var cliente = _mapper.Map<Cliente>(model);
                _geralPersist.Add<Cliente>(cliente);
                if (await _geralPersist.SaveChangesAsync())
                {
                    var clienteRetorno = await _clientePersist.GetClienteByIdAsync(cliente.Id);
                    return _mapper.Map<ClienteDTO>(clienteRetorno);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ClienteDTO> UpdateCliente(int clienteId, ClienteDTO model)
        {
            try
            {
                var cliente = await _clientePersist.GetClienteByIdAsync(clienteId);
                if (cliente == null) return null;

                model.Id = cliente.Id;
                _mapper.Map(model, cliente);
                _geralPersist.Update<Cliente>(cliente);

                if (await _geralPersist.SaveChangesAsync())
                {
                    var clienteRetorno = await _clientePersist.GetClienteByIdAsync(cliente.Id);
                    return _mapper.Map<ClienteDTO>(clienteRetorno);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteCliente(int clienteId)
        {
            try
            {
                var cliente = await _clientePersist.GetClienteByIdAsync(clienteId);
                if (cliente == null) throw new Exception("Cliente para delete não encontrado.");

                _geralPersist.Delete<Cliente>(cliente);
                return await _geralPersist.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        public async Task<ClienteDTO[]> GetAllClientesAsync()
        {
            try
            {
                var clientes = await _clientePersist.GetAllClientesAsync();
                if (clientes == null) return null;

                var resultado = _mapper.Map<ClienteDTO[]>(clientes);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ClienteDTO[]> GetAllClientesByNomeAsync(string nome)
        {
            try
            {
                var clientes = await _clientePersist.GetAllClientesByNomeAsync(nome);
                if (clientes == null) return null;

                var resultado = _mapper.Map<ClienteDTO[]>(clientes);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ClienteDTO> GetClienteByCPFAsync(string cpf)
        {
            try
            {
                var cliente = await _clientePersist.GetClienteByCPFAsync(cpf);
                if (cliente == null) return null;

                var resultado = _mapper.Map<ClienteDTO>(cliente);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ClienteDTO> GetClienteByIdAsync(int clienteId)
        {
            try
            {
                var cliente = await _clientePersist.GetClienteByIdAsync(clienteId);
                if (cliente == null) return null;

                var resultado = _mapper.Map<ClienteDTO>(cliente);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ArrayList> ValidarCliente(ClienteDTO model)
        {
            try
            {
                var consultaCPF = await _clientePersist.GetClienteByCPFAsync(model.cpf);
                ArrayList resposta = new ArrayList();

                if (consultaCPF != null)
                {
                  resposta.Add(409);
                  resposta.Add($"O CPF já está cadastrado no banco de dados.");
                    return resposta;
                }else if (model.tCelular == null && model.tFixo == null)
                {
                    resposta.Add(400);
                    resposta.Add($"É necessário que seja inserido um número de telefone");
                    return resposta;
                }else return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}