﻿using Garbom.Core.Domain.Objects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Garbom.Core.Domain.Interfaces
{
    public class ReadOnlyRepository<TAggregateRoot> : IReadOnlyRepository<TAggregateRoot> where TAggregateRoot : Entity, IAggregateRoot
    {
        private readonly DbContext _context;
        public ReadOnlyRepository(DbContext context)
        {
            _context = context;
        }
        public async Task<TAggregateRoot> ObterPorId(Guid id)
        {
            return await _context.Set<TAggregateRoot>().FindAsync(id);
        }
        public async Task<TAggregateRoot> ObterPrimeiro(Expression<Func<TAggregateRoot, bool>> expressao = null, Func<IQueryable<TAggregateRoot>, IIncludableQueryable<TAggregateRoot, object>> include = null, bool semRastreamento = false)
        {

            var query = _context.Set<TAggregateRoot>().AsQueryable();

            if(expressao != null) query = query.Where(expressao);
           
            if (include != null) query = include(query);

            if (semRastreamento)
                return await query.AsNoTrackingWithIdentityResolution().FirstOrDefaultAsync();
    
            return await query.FirstOrDefaultAsync();
        }
        public async Task<ICollection<TAggregateRoot>> ObterTodos(Expression<Func<TAggregateRoot, bool>> expressao = null, Func<IQueryable<TAggregateRoot>, IIncludableQueryable<TAggregateRoot, object>> include = null, bool semRastreamento = false)
        {
            var query = _context.Set<TAggregateRoot>().AsQueryable();

            if (expressao != null) query = query.Where(expressao);

            if (include != null) query = include(query);

            if (semRastreamento)
                return await query.AsNoTrackingWithIdentityResolution().ToListAsync();

            return await query.ToListAsync();
        }

        public async Task<bool> ExisteAlgum(Expression<Func<TAggregateRoot, bool>> expressao = null)
        {
            return await _context.Set<TAggregateRoot>().AnyAsync();
        }

        public async Task<int> Count(Expression<Func<TAggregateRoot, bool>> expressao = null)
        {
            return await _context.Set<TAggregateRoot>().CountAsync();
        }
        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
