using Garbom.Core.Domain.Messages;
using Garbom.Core.Domain.Messages.CommonMessages.DomainEvents;
using Garbom.Core.Domain.Messages.CommonMessages.Notifications;
using MediatR;
using System.Threading.Tasks;

namespace Garbom.Core.Communication.Mediator
{
    public class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;
        public MediatorHandler(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task PublicarEvento<T>(T evento) where T : Event
        {
            await _mediator.Publish(evento);
        }
        public async Task<T> EnviarComando<T>(Command<T> commando)
        {
            //enviando um request. O send é um request
            return await _mediator.Send(commando);
        }

        public async Task PublicarNotificacao<T>(T notificacao) where T : DomainNotification
        {
            await _mediator.Publish(notificacao);
        }

        public async Task PublicarDomainEvent<T>(T notificacao) where T : DomainEvent
        {
            await _mediator.Publish(notificacao);
        }


    }
}
