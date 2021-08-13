using FluentValidation.Results;
using Garbom.Catalogo.Application.DTOS;
using Garbom.Catalogo.Domain.Models;
using Garbom.Core.Domain.Interfaces;
using System;

using System.Threading.Tasks;

namespace Garbom.Catalogo.Application.Interfaces
{
    public interface IProdutoAppService : IService
    {
        Task<ProdutoDTO> ObterPorId(Guid id);
        Task<ValidationResult> Adicionar(ProdutoDTO produtoDTO);
    }
}
