using System;
using System.Threading.Tasks;
using AutoMapper;
using PoultryApplication.Contratos;
using PoultryApplication.DTOs;
using PoultryDomain;
using PoultryPersistence.Contratos;

namespace PoultryApplication
{
    public class EnderecoService : IEnderecoService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IEnderecoPersist _enderecoPersist;
        private readonly IMapper _mapper;
        public EnderecoService(IGeralPersist geralPersist,
                              IEnderecoPersist enderecoPersist,
                              IMapper mapper)
        {
            _geralPersist = geralPersist;
            _enderecoPersist = enderecoPersist;
            _mapper = mapper;
        }

        public async Task<EnderecoDTO> AddEndereco(EnderecoDTO model)
        {
            try
            {
                var endereco = _mapper.Map<Endereco>(model);
                _geralPersist.Add<Endereco>(endereco);
                if (await _geralPersist.SaveChangesAsync())
                {
                    var enderecoRetorno = await _enderecoPersist.GetEnderecoByIdAsync(endereco.Id);
                    return _mapper.Map<EnderecoDTO>(enderecoRetorno);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EnderecoDTO> UpdateEndereco(int enderecoId, EnderecoDTO model)
        {
            try
            {
                var endereco = await _enderecoPersist.GetEnderecoByIdAsync(enderecoId);
                if (endereco == null) return null;

                model.Id = endereco.Id;
                _mapper.Map(model, endereco);
                _geralPersist.Update<Endereco>(endereco);

                if (await _geralPersist.SaveChangesAsync())
                {
                    var enderecoRetorno = await _enderecoPersist.GetEnderecoByIdAsync(endereco.Id);
                    return _mapper.Map<EnderecoDTO>(enderecoRetorno);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteEndereco(int enderecoId)
        {
            try
            {
                var endereco = await _enderecoPersist.GetEnderecoByIdAsync(enderecoId);
                if (endereco == null) throw new Exception("Endereço para delete não encontrado.");

                _geralPersist.Delete<Endereco>(endereco);
                return await _geralPersist.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EnderecoDTO[]> GetAllEnderecosAsync()
        {
            try
            {
                var enderecos = await _enderecoPersist.GetAllEnderecosAsync();
                if (enderecos == null) return null;

                var resultado = _mapper.Map<EnderecoDTO[]>(enderecos);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EnderecoDTO[]> GetAllEnderecosByClienteAsync(int clienteId)
        {
            try
            {
                var endereco = await _enderecoPersist.GetEnderecosByClienteAsync(clienteId);
                if (endereco == null) return null;

                var resultado = _mapper.Map<EnderecoDTO[]>(endereco);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<EnderecoDTO> GetEnderecoByIdAsync(int enderecoId)
        {
            try
            {
                var endereco = await _enderecoPersist.GetEnderecoByIdAsync(enderecoId);
                if (endereco == null) return null;

                var resultado = _mapper.Map<EnderecoDTO>(endereco);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}