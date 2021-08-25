using Garbom.Core.API;
using Garbom.Core.Communication.Mediator;
using Garbom.Core.Domain.Messages.CommonMessages.Notifications;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System;
using Garbom.Pedido.Application.Commads;
using Garbom.Pedido.Application.DTOS;
using MediatR;

namespace Garbom.API.Controllers
{
    [Route("api")]
    public class ComandasController : MainController
    {
        private readonly IMediatorHandler _mediatorHandler;
        public ComandasController(NotificationContext notificationContex, IMediatorHandler mediatorHandler) : base(notificationContex)
        {
            _mediatorHandler = mediatorHandler;
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
            await _mediatorHandler.EnviarComando(adicionarPedidoCommand);

            if (OperacaoValida())
                return OkResponse();

            return ErroResponse();
        }
    }
}
