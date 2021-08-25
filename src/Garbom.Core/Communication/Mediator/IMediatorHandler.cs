using Garbom.Core.Domain.Messages;
using Garbom.Core.Domain.Messages.CommonMessages.DomainEvents;
using System.Threading.Tasks;

namespace Garbom.Core.Communication.Mediator
{
    public interface IMediatorHandler
    {
        Task PublicarEvento<T>(T evento) where T : Event;
        Task<T> EnviarComando<T>(Command<T> commando);
        Task PublicarDomainEvent<T>(T notificacao) where T : DomainEvent;
    }
}
