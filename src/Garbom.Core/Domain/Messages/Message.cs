using MediatR;
using System;

namespace Garbom.Core.Domain.Messages
{
    public abstract class Message
    {
        public string MessageType { get; protected set; }
        public Guid AggregateId { get; protected set; }
        public Guid EmpresaId { get; protected set; }

        protected Message()
        {
            MessageType = GetType().Name;
        }
    }
}
