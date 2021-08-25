using System;
using System.Collections.Generic;
using Garbom.Core.Domain.Objects;

namespace Garbom.Catalogo.Domain.Models
{
    public class UnidadeMedida : Entity
    {
        public string Nome { get; private set; }

        //EF
        public ICollection<Produto> Produtos { get; set; }
        protected UnidadeMedida() { }
        public UnidadeMedida(Guid empresaId, string nome, Guid? id = null) : base(empresaId, id)
        {
            Nome = nome;
        }

        public override bool EhValido()
        {
            //TODO
            return true;
        }
    }
}
