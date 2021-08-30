using System;
using System.Collections.Generic;

namespace Garbom.Core.Domain.Objects.CDTO
{
    public class PedidoCDTO
    {
        public Guid PedidoId { get; set; }
        public ICollection<PedidoItemCDTO> Itens { get; set; }
        public PedidoCDTO(Guid pedidoId, ICollection<PedidoItemCDTO> itens)
        {
            PedidoId = pedidoId;
            Itens = itens;
        }
    }



    public class PedidoItemCDTO
    {
        public Guid Id { get; set; }
        public int Quantidade { get; set; }
    }
}
