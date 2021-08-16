using Garbom.Core.Domain.Objects;
using System;
using System.Collections.Generic;

namespace Garbom.Pedido.Domain.Models
{
    public class Comanda : Entity, IAggregateRoot
    {
        public Guid MesaId { get; private set; }
        public long Codigo { get; private set; }
        public DateTime DataAbertura { get; private set; }
        public DateTime DataFechamento { get; private set; }
        public EStatusComanda StatusComanda { get; private set; }
        public decimal ValorTotal { get; private set; }

        //EF Rel.
        public Mesa Mesa { get; private set; }
        public ICollection<Pedido> Pedidos { get; private set; }

        public override bool EhValido()
        {
            ValidationResult = new ComandaValidator().Validate(this);

            return ValidationResult.IsValid;
        }
    }
}
