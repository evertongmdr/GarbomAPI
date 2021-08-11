using Garbom.Core.Domain.Objects;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Garbom.Core.Domain.Interfaces
{
    public interface IReadOnlyRepository<TAggregateRoot> : IDisposable where TAggregateRoot : IAggregateRoot
    {
        Task<TAggregateRoot> ObterPorId(Guid id);
        Task<TAggregateRoot> ObterPrimeiro(Expression<Func<TAggregateRoot, bool>> expressao = null, Func<IQueryable<TAggregateRoot>, IIncludableQueryable<TAggregateRoot, object>> include = null, bool semRastreamento = false);
        Task<ICollection<TAggregateRoot>> ObterTodos(Expression<Func<TAggregateRoot, bool>> expressao = null, Func<IQueryable<TAggregateRoot>, IIncludableQueryable<TAggregateRoot, object>> include = null, bool semRastreamento = false);
        Task<bool> ExisteAlgum(Expression<Func<TAggregateRoot, bool>> expressao = null);
        Task<int> Count(Expression<Func<TAggregateRoot, bool>> expressao = null);
    }
}
