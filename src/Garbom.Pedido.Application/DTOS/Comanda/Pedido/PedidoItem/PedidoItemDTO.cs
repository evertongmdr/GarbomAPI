using System;

namespace Garbom.Pedido.Application.DTOS
{
    public class PedidoItemDTO
    {
        public Guid PedidoId { get; private set; }
        public Guid ProdutoId { get; private set; }
        public int Quantidade { get; private set; }
        public decimal ValorUnitario { get; private set; }
    }
}
