using Garbom.Core.Domain.Objects.CDTO;
using System;

namespace Garbom.Core.Domain.Messages.CommonMessages.IntegrationEvents
{
    public class PedidoConfirmadoIntegrationEvent : IntegrationEvent
    {

        public Guid ComandaId { get; private set; }
        public PedidoCDTO Pedido { get; private set; }

        public PedidoConfirmadoIntegrationEvent(Guid comandaId, PedidoCDTO pedido)
        {
            AggregateId = comandaId;
            ComandaId = comandaId;

            Pedido = pedido;
        }
    }
}
