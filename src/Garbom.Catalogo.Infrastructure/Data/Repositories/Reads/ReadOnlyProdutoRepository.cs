using Garbom.Catalogo.Domain.Interfaces.Repositories;
using Garbom.Catalogo.Domain.Models;
using Garbom.Core.Infrastructure.Data.Repository;
using System;
using System.Threading.Tasks;

namespace Garbom.Catalogo.Infrastructure.Data.Repositories
{
    public class ReadOnlyProdutoRepository : ReadOnlyRepository<Produto>, IReadOnlyProdutoRepository
    {
        public ReadOnlyProdutoRepository(CatalogoContext context) : base(context) { }

        public async Task<Categoria> ObterCategoriaPorId(Guid id)
        {
            return await _context.Set<Categoria>().FindAsync(id);
        }
        public async Task<UnidadeMedida> ObterUnidadeMedidaPorId(Guid id)
        {
            return await _context.Set<UnidadeMedida>().FindAsync(id); ;
        }
        public async Task<Marca> ObterMarcaPorId(Guid id)
        {
            return await _context.Set<Marca>().FindAsync(id);
        }


    }
}
