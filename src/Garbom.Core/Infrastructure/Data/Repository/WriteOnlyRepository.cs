using Garbom.Core.Domain.Interfaces.Objects;
using Garbom.Core.Domain.Objects;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Garbom.Core.Infrastructure.Data.Repository
{
    public class WriteOnlyRepository<TAggregateRoot> : IWriteOnlyRepository<TAggregateRoot> where TAggregateRoot : Entity, IAggregateRoot
    {
        protected DbContext _context;
        public IUnitOfWork UnitOfWork => (IUnitOfWork)_context;
        public WriteOnlyRepository(DbContext context)
        {
            _context = context;
        }

        public void Adicionar(TAggregateRoot aggregateRoot)
        {
            _context.Set<TAggregateRoot>().Add(aggregateRoot);
        }

        public void AdicionarConjunto(IList<TAggregateRoot> aggregatesRoot)
        {
            _context.Set<TAggregateRoot>().AddRange(aggregatesRoot);
        }

        public void Atualizar(TAggregateRoot aggregateRoot)
        {
            _context.Set<TAggregateRoot>().Update(aggregateRoot);
        }

        public void Atualizar(TAggregateRoot aggregateRootVelho, TAggregateRoot aggregateRootNovo)
        {
            _context.Entry(aggregateRootVelho).CurrentValues.SetValues(aggregateRootNovo);
        }
        public void Remover(TAggregateRoot aggregateRoot)
        {
            _context.Set<TAggregateRoot>().Remove(aggregateRoot);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }

       
    }
}
