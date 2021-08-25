using Garbom.Core.Domain.Interfaces.Objects;
using Garbom.Core.Domain.Messages.CommonMessages.Notifications;
using System.Threading.Tasks;

namespace Garbom.Core.Domain.Messages
{
    public abstract class CommandHandler
    {
        protected readonly NotificationContext _notificationContext;
        protected CommandHandler(NotificationContext notificationContext)
        {
            _notificationContext = notificationContext;

        }
        protected async Task<bool> PersistirDados(IUnitOfWork uow)
        {
            if (!await uow.Commit())
            {
                _notificationContext.AddNotificacao(new DomainNotification("", "Houve um erro ao persistir os dados"));
                return false;
            }
            return true;

        }

        protected bool ValidarComando<TResult>(Command<TResult> mensagem)
        {
            if (!mensagem.EhValido())
            {
                _notificationContext.AddNotificacoes(mensagem.ValidationResult);
                return default;
            }
            return true;
        }
    }
}
