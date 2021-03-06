using Garbom.Core.Domain.Objects;
using System;

namespace Garbom.Pedido.Domain.Models
{
    public class PedidoItem : Entity
    {
        public Guid PedidoId { get; private set; }
        public Guid ProdutoId { get; private set; }
        public int Quantidade { get; private set; }
        public decimal ValorUnitario { get; private set; }

        public PedidoItem(Guid empresaId, Guid pedidoId, Guid produtoId, int quantidade, decimal valorUnitario, Guid? id = null) : base(empresaId, id)
        {
            PedidoId = pedidoId;
            ProdutoId = produtoId;
            Quantidade = quantidade;
            ValorUnitario = valorUnitario;
        }

        //EF Rel.
        protected PedidoItem() { }
        public Pedido Pedido { get; private set; }
        public Produto Produto { get; private set; }

        public override bool EhValido()
        {
            ValidationResult = new PedidoItemValidator().Validate(this);

            return ValidationResult.IsValid;
        }

    }
}
