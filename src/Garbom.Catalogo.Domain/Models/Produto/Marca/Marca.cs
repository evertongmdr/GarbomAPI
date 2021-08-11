using System.Collections.Generic;
using Garbom.Core.Domain.Objects;


namespace Garbom.Catalogo.Domain.Models
{
    public class Marca : Entity
    {
        public string Nome { get;private set; }

        //EF
        public ICollection<Produto> Produtos { get; set; }

        public Marca(string nome)
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
