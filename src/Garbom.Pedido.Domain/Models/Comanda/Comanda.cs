using Garbom.Core.Domain.Objects;
using System;
using System.Collections.Generic;

namespace Garbom.Pedido.Domain.Models
{
    public class Comanda : Entity
    {
        public Guid MesaId { get; private set; }
        public int Codigo { get; private set; }
        public DateTime DataAbertura { get; private set; }
        public DateTime DataFechamento { get; private set; }
        public EStatusComanda StatusComanda { get; private set; }
        public decimal ValorTotal { get; private set; }

        //EF
        public Mesa Mesa { get; private set; }
        public ICollection<Pedido> Pedidos { get; private set; }

        public override bool EhValido()
        {
            throw new System.
        }
    }
}
