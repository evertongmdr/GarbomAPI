using Garbom.Catalogo.Application.Interfaces;
using Garbom.Core.Application.Objects;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Garbom.Catalogo.Application.DTOS;

namespace Garbom.API.Controllers.Produtos
{
    public class ProdutoController : MainController
    {
        private readonly IProdutoAppService _produtoAppService;
        public ProdutoController(IProdutoAppService produtoAppService)
        {
            _produtoAppService = produtoAppService;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(ProdutoDTO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> ObterProdutoPorId(Guid id)
        {
           var produto = await _produtoAppService.ObterPorId(id);

            if (produto == null)
            {
                NotFound();
            }
            return Ok(produto);
        }


    }
}
