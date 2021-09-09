using AutoMapper;
using PoultryApplication.DTOs;
using PoultryDomain;

namespace PoultryApplication.Helpers
{
    public class PoultryProfile : Profile
    {
        public PoultryProfile()
        {
            CreateMap<Cliente, ClienteDTO>().ReverseMap();
            CreateMap<Endereco, EnderecoDTO>().ReverseMap();
            CreateMap<ItemPedido, ItemPedidoDTO>().ReverseMap();
            CreateMap<Pedido, PedidoDTO>().ReverseMap();
            CreateMap<Produto, ProdutoDTO>().ReverseMap();
        }
    }
}