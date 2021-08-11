using Garbom.Catalogo.Application.DTOS;
using Garbom.Catalogo.Domain.Models;
using Garbom.Core.Domain.Interfaces;
using System;
using System.Threading.Tasks;

namespace Garbom.Catalogo.Application.Interfaces
{
    public interface IProdutoAppService : IService
    {
        Task<Produto> ObterPorId(Guid id);
        Task Adicionar(ProdutoDTO produtoDTO);
    }
}
