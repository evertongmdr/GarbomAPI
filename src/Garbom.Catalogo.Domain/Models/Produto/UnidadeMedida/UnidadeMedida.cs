using System.Collections.Generic;
using Garbom.Core.Domain.Objects;

namespace Garbom.Catalogo.Domain.Models
{
    public class UnidadeMedida : Entity
    {
        public string Nome { get; private set; }

        //EF
        public ICollection<Produto> Produtos { get; set; }

        public UnidadeMedida(string nome)
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
