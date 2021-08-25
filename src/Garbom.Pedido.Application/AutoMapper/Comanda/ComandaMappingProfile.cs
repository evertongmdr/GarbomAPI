using AutoMapper;
using Garbom.Pedido.Application.DTOS;
using Garbom.Pedido.Domain.Models;
namespace Garbom.Pedido.Application.AutoMapper
{
    class ComandaMappingProfile : Profile
    {
        public ComandaMappingProfile()
        {
            CreateMap<ComandaDTO, Comanda>().ReverseMap();

        }
    }
}
