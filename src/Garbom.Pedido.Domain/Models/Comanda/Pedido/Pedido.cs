using Garbom.Core.Domain.Objects;
using System;

namespace Garbom.Pedido.Domain.Models
{
    public class Pedido : Entity
    {
        public Guid UsuarioId { get; private set; }
        public int Codigo { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public EStatusPedido StatusPedido { get; private set; }
        public decimal ValorTotal { get; private set; }

        public override bool EhValido()
        {
            throw new System.NotImplementedException();
        }
    }
}
