using Garbom.Core.Domain.Objects;
using System;
using System.Collections.Generic;

namespace Garbom.Core.Domain.Interfaces.Objects
{
    public interface IWriteOnlyRepository<TAggregateRoot> : IDisposable where TAggregateRoot : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
        void Adicionar(TAggregateRoot aggregateRoot);
        void AdicionarConjunto(IList<TAggregateRoot> aggregatesRoot);
        void Atualizar(TAggregateRoot aggregateRoot);

        void Atualizar(TAggregateRoot aggregateRootVelho, TAggregateRoot aggregateRootNovo);
        void Remover(TAggregateRoot aggregateRoot);
    }
}
