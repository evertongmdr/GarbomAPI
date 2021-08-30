using Garbom.Catalogo.Application.DTOS;
using Garbom.Catalogo.Application.Interfaces;
using Garbom.Catalogo.Domain.Models;
using Garbom.Catalogo.Infrastructure.Data;
using Garbom.Core.API;
using Garbom.Core.Domain.Messages.CommonMessages.Notifications;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Garbom.API.Controllers
{
    [Route("api")]
    public class ProdutosController : MainController
    {

        private readonly IProdutoAppService _produtoAppService;

        private readonly CatalogoContext _catalogoContext;
        public ProdutosController(NotificationContext notificationContex, IProdutoAppService produtoAppService, CatalogoContext catalogoContext) : base(notificationContex)
        {
            _produtoAppService = produtoAppService;
            _catalogoContext = catalogoContext;

        }

        [HttpGet("[controller]/{id}")]
        [ProducesResponseType(200, Type = typeof(ProdutoDTO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> ObterProdutoPorId(Guid id)
        {
            var produto = await _produtoAppService.ObterProdutoPorId(id);

            if (produto == null)
                return NotFound("Produto não encontrado");

            return Ok(produto);
        }

        [HttpPost("[controller]")]
        [ProducesResponseType(201, Type = typeof(Result<ProdutoDTO>))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> AdicionarProduto([FromBody] ProdutoDTO produtoDTO)
        {
            var produtoDTORespota = await _produtoAppService.AdicionarProduto(produtoDTO);

            if (OperacaoValida())
                return CriacaoSucessoResponse(produtoDTORespota);

            return ErroResponse();
        }

        [HttpGet("[controller]", Name = "ObterProdutos")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> ObterProdutos([FromQuery] ProdutoRecursoParametro produtoRecursoParametro)
        {
            var produtosPaginado = await _produtoAppService.ObterProdutos(produtoRecursoParametro);

            if (OperacaoValida())
            {
                CriarUri("ObterProdutos", produtoRecursoParametro, produtosPaginado);
                return OkResponse(produtosPaginado);
            }


            return ErroResponse();
        }

        [HttpGet("[controller]/todos")]
        public IActionResult ObterProdutos()
        {
            var result = _catalogoContext.Set<Produto>().ToList();

            return Ok(result);
        }
    }
}
