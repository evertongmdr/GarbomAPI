using FluentValidation.Results;
using Garbom.Catalogo.Application.DTOS;
using Garbom.Core.Application;
using System;

using System.Threading.Tasks;

namespace Garbom.Catalogo.Application.Interfaces
{
    public interface IProdutoAppService : IDisposable
    {
        //Produto
        Task<ProdutoDTO> ObterProdutoPorId(Guid id);
        Task<AppValidationResult<ProdutoDTO>> AdicionarProduto(ProdutoDTO produtoDTO);

        // Categoria
        Task<CategoriaDTO> ObterCategoriaPorId(Guid id);
        Task<AppValidationResult<CategoriaDTO>> AdicionarCategoria(CategoriaDTO categoriaDTO);
    }
}
