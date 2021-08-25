using Garbom.Core.Domain.Objects;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Garbom.Core.Domain.Interfaces.Objects
{
    public interface IReadOnlyRepository<TAggregateRoot> : IDisposable where TAggregateRoot : IAggregateRoot
    {
        Task<TEntity> ObterPorId<TEntity>(Guid id) where TEntity : Entity;
        Task<TAggregateRoot> ObterPrimeiro(Expression<Func<TAggregateRoot, bool>> expressao = null, Func<IQueryable<TAggregateRoot>, IIncludableQueryable<TAggregateRoot, object>> include = null, bool semRastreamento = false);
        Task<ICollection<TEntity>> ObterTodos<TEntity>(Expression<Func<TEntity, bool>> expressao = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, bool semRastreamento = false) where TEntity : Entity;
        Task<bool> ExisteAlgum(Expression<Func<TAggregateRoot, bool>> expressao = null);
        Task<int> Count(Expression<Func<TAggregateRoot, bool>> expressao = null);
    }
}
