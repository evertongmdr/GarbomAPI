using Garbom.Catalogo.Domain.Models;
using Garbom.Core.Domain.Interfaces.Objects;
using Garbom.Core.Helps.Objects;
using System;
using System.Threading.Tasks;

namespace Garbom.Catalogo.Domain.Interfaces.Repositories
{
    public interface IReadOnlyProdutoRepository : IReadOnlyRepository<Produto>
    {
        //Produto
        public Task<ListaPaginadaDinamica> ObterProdutos(ProdutoRecursoParametro produtoRecursoParametro);
        //Categoria
        public Task<Categoria> ObterCategoriaPorId(Guid id);
        //UnidadeMedida
        public Task<UnidadeMedida> ObterUnidadeMedidaPorId(Guid id);
        //Marca
        public Task<Marca> ObterMarcaPorId(Guid id);

    }
}
