using Garbom.Core.Domain.Objects;
using System;
using System.Collections.Generic;

namespace Garbom.Core.Domain.Interfaces
{
    public interface IWriteOnlyRepository<TAggregateRoot> : IDisposable where TAggregateRoot : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
        void Adicionar(TAggregateRoot aggregateRoot);
        void AdicionarConjunto(ICollection<TAggregateRoot> aggregatesRoot);
        void Atualizar(TAggregateRoot aggregateRoot);
        void Remover(TAggregateRoot aggregateRoot);
    }
}
