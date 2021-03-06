using AutoMapper;
using Garbom.Catalogo.Application.DTOS;
using Garbom.Catalogo.Domain.Models;

namespace Garbom.Catalogo.Application.AutoMapper
{
    public class ProdutoMappingProfile : Profile
    {
      
        public ProdutoMappingProfile()
        {
            CreateMap<ProdutoDTO, Produto>().ReverseMap();
        }
       
    }
}
