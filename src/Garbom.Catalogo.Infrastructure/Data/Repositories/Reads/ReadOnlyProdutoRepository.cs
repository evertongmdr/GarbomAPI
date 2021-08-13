using Garbom.Catalogo.Domain.Interfaces.Repositories;
using Garbom.Catalogo.Domain.Models;
using Garbom.Core.Infrastructure.Repository;

namespace Garbom.Catalogo.Infrastructure.Data.Repositories
{
    public class ReadOnlyProdutoRepository : ReadOnlyRepository<Produto>, IReadOnlyProdutoRepository
    {
        public ReadOnlyProdutoRepository(CatalogoContext context) : base (context){}
    }
}
