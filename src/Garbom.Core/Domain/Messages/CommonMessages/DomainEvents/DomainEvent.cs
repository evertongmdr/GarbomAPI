using MediatR;
using System;

namespace Garbom.Core.Domain.Messages.CommonMessages.DomainEvents
{
    public class DomainEvent : Message, INotification
    {
        public DateTime Timestamp { get; private set; }
        public DomainEvent(Guid aggregateId)
        {
            AggregateId = aggregateId;
            Timestamp = DateTime.Now;
        }
    }
}
