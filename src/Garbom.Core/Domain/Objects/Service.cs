using Garbom.Core.Domain.Interfaces.Objects;
using Garbom.Core.Domain.Messages.CommonMessages.Notifications;
using System.Threading.Tasks;

namespace Garbom.Core.Domain.Objects
{
    public abstract class Service
    {
        protected readonly DomainNotificationContext _domainNotificationContext;
        public Service(DomainNotificationContext domainNotificationContext)
        {
            _domainNotificationContext = domainNotificationContext;
        }

        protected async Task<bool> PersistirDados(IUnitOfWork uow)
        {
            if (!await uow.Commit())
            {
                _domainNotificationContext.AddNotificacao(new DomainNotification("", "Houve um erro ao persistir os dados"));
                return false;
            }
            return true;

        }

    }
}
