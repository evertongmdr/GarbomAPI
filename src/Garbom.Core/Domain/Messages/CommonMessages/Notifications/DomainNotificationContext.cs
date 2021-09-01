using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;

namespace Garbom.Core.Domain.Messages.CommonMessages.Notifications
{
    public class DomainNotificationContext
    {
        private readonly List<DomainNotification> _domainNotifications;
        public IReadOnlyCollection<DomainNotification> DomainNotifications => _domainNotifications;
        public bool TemNotificacoes => _domainNotifications.Any();

        public DomainNotificationContext()
        {
            _domainNotifications = new List<DomainNotification>();
        }

        public void AddNotificacao(string key, string message)
        {
            _domainNotifications.Add(new DomainNotification(key, message));
        }

        public void AddNotificacao(DomainNotification notification)
        {
            _domainNotifications.Add(notification);
        }

        public void AddNotificacoes(ICollection<DomainNotification> notifications)
        {
            _domainNotifications.AddRange(notifications);
        }

        public void AddNotificacoes(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                AddNotificacao(error.ErrorCode, error.ErrorMessage);
            }
        }
    }
}
