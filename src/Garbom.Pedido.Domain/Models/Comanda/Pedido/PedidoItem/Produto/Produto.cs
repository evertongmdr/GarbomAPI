using Garbom.Core.Domain.Objects;
using System;
using System.Collections.Generic;

namespace Garbom.Pedido.Domain.Models
{
    public class Produto : Entity
    {
        public string Nome { get; private set; }

        //EF Rel.
        protected Produto() { }
        public ICollection<PedidoItem> PedidoItens { get; private set; }

        public Produto(Guid empersaId, Guid id, string nome) : base(empersaId, id)
        {
            Nome = nome;

        }

        public override bool EhValido()
        {
            ValidationResult = new ProdutoValidator().Validate(this);
            return ValidationResult.IsValid;
        }

    }
}
