using Garbom.Catalogo.Domain.Interfaces.Repositories.Writes;
using Garbom.Catalogo.Domain.Models;
using Garbom.Core.Domain.Interfaces;

namespace Garbom.Catalogo.Infrastructure.Data.Repositories.Writes
{
    public class WriteOnlyProdutoRepository : WriteOnlyRepository<Produto>, IWriteOnlyProdutoRepository
    {
        public WriteOnlyProdutoRepository(CatalogoContext context): base (context){}
    }
}
