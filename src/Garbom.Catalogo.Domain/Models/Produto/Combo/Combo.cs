using System;
using System.Collections.Generic;
using Garbom.Core.Domain.Objects;

namespace Garbom.Catalogo.Domain.Models
{
    public class Combo : Entity
    {
        public Guid UsuarioCriacaoId { get; private set; }
        public string Nome { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public bool Ativo { get; private set; }

        //EF Rel.
        public ICollection<Produto> Produtos { get; private set; }

        public Combo(string nome, DateTime dataCriacao,bool ativo, Guid usuarioCriacaoId)
        {
            UsuarioCriacaoId = usuarioCriacaoId;
            Nome = nome;
            DataCriacao = dataCriacao;
            Ativo = ativo;
        }

        public override bool EhValido()
        {
            ValidationResult = new ComboValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
