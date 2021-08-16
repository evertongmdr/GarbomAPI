using Garbom.Catalogo.Application.DTOS;
using Garbom.Catalogo.Application.Interfaces;
using Garbom.Catalogo.Domain.Models;
using Garbom.Catalogo.Infrastructure.Data;
using Garbom.Core.API;
using Garbom.Core.Infrastructure.Data.DatabaseFunctionMapping;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Garbom.API.Controllers.Produtos
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : MainController
    {
        private readonly IProdutoAppService _produtoAppService;
        private readonly CatalogoContext _catalogoContext;
        public ProdutoController(IProdutoAppService produtoAppService, CatalogoContext catalogoContext)
        {
            _produtoAppService = produtoAppService;
            _catalogoContext = catalogoContext;

        }

        [HttpGet("{id}")]
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

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(ProdutoDTO))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> AdicionarProduto([FromBody] ProdutoDTO produtoDTO)
        {
            if (produtoDTO == null)
                return BadRequest("Dados do produto inválido");

            
            var appResult = await _produtoAppService.AdicionarProduto(produtoDTO);

            if (!appResult.EhValido())
                return BadRequest(appResult.ValidationResult.Errors);

            return CreatedAtAction(nameof(ObterProdutoPorId), new { id = appResult.Objeto.Id }, null);
        }

        [HttpGet("teste")]
    
        public  IActionResult Teste()
        {
            var result = _catalogoContext.Set<Produto>().Select(x => GarbomFuncoesBanco.Left(x.Nome, 3));

            string nomes = "";
            foreach (var nome in result)
            {
                nomes+=nome +"\n";
              
            }
            return Ok(nomes);
        }
    }
}
