using Garbom.Catalogo.Domain.Interfaces.Repositories;
using Garbom.Catalogo.Domain.Models;
using Garbom.Core.Infrastructure.Data.Repository;

namespace Garbom.Catalogo.Infrastructure.Data.Repositories
{
    public class WriteOnlyProdutoRepository : WriteOnlyRepository<Produto>, IWriteOnlyProdutoRepository
    {
        public WriteOnlyProdutoRepository(CatalogoContext context) : base(context) { }

        public void AdicionarCategoria(Categoria categoria)
        {
            _context.Set<Categoria>().Add(categoria);
        }
        public void AdicionarUnidadeMedida(UnidadeMedida unidadeMedida)
        {
            _context.Set<UnidadeMedida>().Add(unidadeMedida);
        }
        public void AdicionarMarca(Marca marca)
        {
            _context.Set<Marca>().Add(marca);
        }
    }
}
