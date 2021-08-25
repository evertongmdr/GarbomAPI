
using System;
using System.Collections.Generic;
using Garbom.Core.Domain.Objects;


namespace Garbom.Catalogo.Domain.Models
{
    public class Categoria : Entity
    {
        public string Nome { get; private set; }

        //EF Rel.
        public ICollection<Produto> Produtos { get; private set; }

        protected Categoria() { }

        public Categoria(Guid empresaId, string nome, Guid? id = null) : base(empresaId, id)
        {
            Nome = nome;
        }
        public override bool EhValido()
        {
            ValidationResult = new CategoriaValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }


}
