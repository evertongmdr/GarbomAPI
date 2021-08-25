using System;
using System.Collections.Generic;
using Garbom.Core.Domain.Objects;


namespace Garbom.Catalogo.Domain.Models
{
    public class Marca : Entity
    {
        public string Nome { get; private set; }

        //EF Rel.
        public ICollection<Produto> Produtos { get; set; }
        protected Marca() { }
        public Marca(Guid empresaId, string nome, Guid? id = null) : base(empresaId, id)
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
