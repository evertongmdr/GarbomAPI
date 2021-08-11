using Garbom.Catalogo.Domain.Interfaces.Repositories.Reads;
using Garbom.Catalogo.Domain.Models;
using Garbom.Core.Domain.Interfaces;

namespace Garbom.Catalogo.Infrastructure.Data.Repositories.Reads
{
    public class ReadOnlyProdutoRepository : ReadOnlyRepository<Produto>, IReadOnlyProdutoRepository
    {
        public ReadOnlyProdutoRepository(CatalogoContext context) : base (context){}
    }
}
