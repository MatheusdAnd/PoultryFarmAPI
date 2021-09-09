using System;
using System.Threading.Tasks;
using AutoMapper;
using PoultryApplication.Contratos;
using PoultryApplication.DTOs;
using PoultryDomain;
using PoultryPersistence.Contratos;

namespace PoultryApplication
{
    public class PedidoService : IPedidoService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IPedidoPersist _pedidoPersist;
        private readonly IMapper _mapper;
        public PedidoService(IGeralPersist geralPersist,
                              IPedidoPersist pedidoPersist,
                              IMapper mapper)
        {
            _geralPersist = geralPersist;
            _pedidoPersist = pedidoPersist;
            _mapper = mapper;
        }

        public async Task<PedidoDTO> AddPedido(PedidoDTO model)
        {
            try
            {
                var pedido = _mapper.Map<Pedido>(model);
                _geralPersist.Add<Pedido>(pedido);
                
                if (await _geralPersist.SaveChangesAsync())
                {
                    var pedidoRetorno = await _pedidoPersist.GetPedidoByIdAsync(pedido.Id);
                    return _mapper.Map<PedidoDTO>(pedidoRetorno);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        public async Task<PedidoDTO[]> GetAllPedidosAsync()
        {
            try
            {
                var pedidos = await _pedidoPersist.GetAllPedidosAsync();
                if (pedidos == null) return null;

                var resultado = _mapper.Map<PedidoDTO[]>(pedidos);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PedidoDTO[]> GetAllPedidosByClienteAsync(int clienteId)
        {
            try
            {
                var pedidos = await _pedidoPersist.GetAllPedidosByClienteAsync(clienteId);
                if (pedidos == null) return null;

                var resultado = _mapper.Map<PedidoDTO[]>(pedidos);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PedidoDTO[]> GetAllPedidosByDtPedidoAsync(DateTime dtPedido)
        {
            try
            {
                var pedidos = await _pedidoPersist.GetAllPedidosByDtPedidoAsync(dtPedido);
                if (pedidos == null) return null;

                var resultado = _mapper.Map<PedidoDTO[]>(pedidos);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PedidoDTO> GetPedidoByIdAsync(int pedidoId)
        {
            try
            {
                var pedido = await _pedidoPersist.GetPedidoByIdAsync(pedidoId);
                if (pedido == null) return null;

                var resultado = _mapper.Map<PedidoDTO>(pedido);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}