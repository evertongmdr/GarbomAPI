using FluentValidation.Results;
using Garbom.Core.Domain.Objects.CDTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Garbom.Catalogo.Domain.Interfaces.Services
{
    public interface IEstoqueService : IDisposable
    {
        Task<bool> DebitarEstoque(Guid produtoId, int quantidade);
        Task<bool> DebitarEstoqueListaProduto(ICollection<PedidoItemCDTO> produtoItens);
        Task<bool> ReporEstoque(Guid produtoId, int quantidade);

    }
}
