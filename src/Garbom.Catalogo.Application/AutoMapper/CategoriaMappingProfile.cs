﻿using AutoMapper;
using Garbom.Catalogo.Application.DTOS;
using Garbom.Catalogo.Domain.Models;

namespace Garbom.Catalogo.Application.AutoMapper
{
    public class CategoriaMappingProfile : Profile
    {
        //prDoPr
        public CategoriaMappingProfile()
        {
            CreateMap<CategoriaDTO, Categoria>().ReverseMap();
        }
    }
}
