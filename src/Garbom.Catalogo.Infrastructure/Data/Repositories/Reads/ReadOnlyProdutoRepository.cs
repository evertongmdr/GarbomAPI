using Garbom.Catalogo.Domain.Interfaces.Repositories;
using Garbom.Catalogo.Domain.Models;
using Garbom.Core.Helps.Objects;
using Garbom.Core.Infrastructure.Data.Repository;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace Garbom.Catalogo.Infrastructure.Data.Repositories
{
    public class ReadOnlyProdutoRepository : ReadOnlyRepository<Produto>, IReadOnlyProdutoRepository
    {
        public ReadOnlyProdutoRepository(CatalogoContext context) : base(context) { }

        //Produto
        public async Task<ListaPaginadaDinamica> ObterProdutos(ProdutoRecursoParametro produtoRecursoParametro)
        {
            var query = _context.Set<Produto>().AsQueryable();

            if (produtoRecursoParametro.Codigo != null)
                query = query.Where(p => p.Codigo == produtoRecursoParametro.Codigo);

            if (!string.IsNullOrWhiteSpace(produtoRecursoParametro.Nome))
                query = query.Where(p => p.Nome.Contains(produtoRecursoParametro.Nome));

            if (produtoRecursoParametro.QuantidadeEstoque != null)
                query = query.Where(p => p.QuantidadeEstoque == produtoRecursoParametro.QuantidadeEstoque);

            //query = query.Select($"new {{{produtoRecursoParametro.Selecionar}}}");

            return await ListaPaginadaDinamica.CriarDinamico(query, produtoRecursoParametro.NumeroPagina, produtoRecursoParametro.TamanhoPagina);

            //return await query.Select($"new {{{produtoRecursoParametro.Selecionar}}}").ToDynamicListAsync();
        }


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
