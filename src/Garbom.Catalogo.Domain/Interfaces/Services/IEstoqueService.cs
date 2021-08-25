using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace Garbom.Catalogo.Domain.Interfaces.Services
{
    public interface IEstoqueService : IDisposable
    {
        Task<bool> DebitarEstoque(Guid produtoId, int quantidade);
        Task<bool> ReporEstoque(Guid produtoId, int quantidade);

    }
}
