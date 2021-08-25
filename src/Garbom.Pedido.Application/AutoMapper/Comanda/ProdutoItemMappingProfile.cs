using AutoMapper;
using Garbom.Pedido.Application.DTOS;
using Garbom.Pedido.Domain.Models;

namespace Garbom.Pedido.Application.AutoMapper
{
    public class ProdutoItemMappingProfile : Profile
    {
        public ProdutoItemMappingProfile()
        {
            CreateMap<PedidoItemDTO, PedidoItem>().ReverseMap();
        }
    }
}
