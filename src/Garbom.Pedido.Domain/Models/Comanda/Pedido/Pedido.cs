using Garbom.Core.Domain.Objects;
using System;
using System.Collections.Generic;

namespace Garbom.Pedido.Domain.Models
{
    public class Pedido : Entity
    {
        public Guid UsuarioId { get; private set; }
        public string NomeUsuario { get; private set; }
        public long Codigo { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public EStatusPedido StatusPedido { get; private set; }
        public decimal ValorTotal { get; private set; }

        //EF Rel.
        public Comanda Comanda { get; private set; }
        public ICollection<PedidoItem> PedidoItens { get; private set; }
    }
}
