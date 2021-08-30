using Garbom.Catalogo.Application.Interfaces;
using Garbom.Catalogo.Domain.Models;
using Garbom.Core.API;
using Garbom.Core.Communication.Mediator;
using Garbom.Core.Domain.Messages.CommonMessages.Notifications;
using Garbom.Pedido.Application.Commads;
using Garbom.Pedido.Application.DTOS;
using Garbom.Pedido.Application.Queries;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Garbom.API.Controllers
{
    [Route("api")]
    public class ComandasController : MainController
    {

        private readonly IMediatorHandler _mediatorHandler;
        private readonly IComandaQueries _comandaQueries;

        private readonly IProdutoAppService _produtoAppService;

        public ComandasController(NotificationContext notificationContex, IMediatorHandler mediatorHandler, IComandaQueries comandaQueries, IProdutoAppService produtoAppService) : base(notificationContex)
        {
            _mediatorHandler = mediatorHandler;
            _comandaQueries = comandaQueries;

            _produtoAppService = produtoAppService;
        }

        [HttpPost("[controller]/abrir-comanda")]
        [ProducesResponseType(201, Type = typeof(Result<Guid>))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> AdicionarComanda([FromBody] Guid mesaId)
        {

            var comandaId = await _mediatorHandler.EnviarComando(new AbrirComandaCommand(mesaId));

            if (OperacaoValida())
                return CriacaoSucessoResponse(comandaId);

            return ErroResponse();
        }
        //api/comandas/id/pedido/
        [HttpPost("[controller]/pedido")]
        [ProducesResponseType(201, Type = typeof(Result<object>))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> AdicionarPedidoComanda(AdicionarPedidoCommand adicionarPedidoCommand)
        {

            if (!adicionarPedidoCommand.EhValido())
            {
                _notificationContext.AddNotificacoes(adicionarPedidoCommand.ValidationResult);
                return ErroResponse();
            }

            var produtos = await _produtoAppService.ObterProdutosPorIds(adicionarPedidoCommand.PedidoItens
                .Select(pi => pi.PedidoId).ToList());

            Produto produto = null;
            foreach (var item in adicionarPedidoCommand.PedidoItens)
            {
                produto = produtos.First(p => p.Id == item.ProdutoId);

                if (!produto.PossuiEstoque(item.Quantidade))
                    _notificationContext.AddNotificacao(new DomainNotification("produto", $"Produto {produto.Nome} sem estoque"));
            }

            if (!OperacaoValida()) return ErroResponse();

            await _mediatorHandler.EnviarComando(adicionarPedidoCommand);

            if (OperacaoValida()) return OkResponse();

            return ErroResponse();
        }

        //api/comandas/aberta
        [HttpGet("[controller]/abertas")]
        [ProducesResponseType(200, Type = typeof(Result<ComandaDTO>))]
        public async Task<IActionResult> AdicionarPedidoComanda()
        {
            return OkResponse(await _comandaQueries.ObterComandaAbertas());
        }
    }
}
