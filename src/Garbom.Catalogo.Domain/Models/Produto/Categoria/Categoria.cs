
using System.Collections.Generic;
using Garbom.Core.Domain.Objects;


namespace Garbom.Catalogo.Domain.Models
{
    public class Categoria : Entity
    {
        public string Nome { get; private set; }

        //EF Rel.
        public ICollection<Produto> Produtos { get; private set; }

        public Categoria(string nome)
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
