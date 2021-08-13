using Garbom.Catalogo.Domain.Models;
using Garbom.Core.Domain.Interfaces;

namespace Garbom.Catalogo.Domain.Interfaces.Repositories
{
    public interface IWriteOnlyProdutoRepository : IWriteOnlyRepository<Produto>
    {
        public void AdicionarCategoria(Categoria categoria);
        public void AdicionarUnidadeMedida(UnidadeMedida unidadeMedida);
        public void AdicionarMarca(Marca marca);
    }
}
