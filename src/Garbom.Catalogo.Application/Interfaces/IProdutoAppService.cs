using Garbom.Catalogo.Application.DTOS;
using Garbom.Catalogo.Domain.Models;
using Garbom.Core.Helps.Objects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Garbom.Catalogo.Application.Interfaces
{
    public interface IProdutoAppService : IDisposable
    {

        #region Produto
        Task<ProdutoDTO> ObterProdutoPorId(Guid id);
        Task<ICollection<Produto>> ObterProdutosPorIds(ICollection<Guid> ids);
        Task<ListaPaginadaDinamica> ObterProdutos(ProdutoRecursoParametro produtoRecursoParametro);
        Task<ProdutoDTO> AdicionarProduto(ProdutoDTO produtoDTO);
        Task<ProdutoDTO> AtualizarProduto(ProdutoDTO produtoDTO);
        #endregion

        #region Categoria
        Task<CategoriaDTO> ObterCategoriaPorId(Guid id);
        Task<CategoriaDTO> AdicionarCategoria(CategoriaDTO categoriaDTO);
        #endregion

        #region Estoque
        Task<bool> DebitarEstoque(Guid id, int quantidade);
        Task<bool> ReporEstoque(Guid id, int quantidade);
        #endregion
    }
}
