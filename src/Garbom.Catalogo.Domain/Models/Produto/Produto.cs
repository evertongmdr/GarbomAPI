using System;
using System.Collections.Generic;
using Garbom.Core.Domain.Objects;

namespace Garbom.Catalogo.Domain.Models
{
    public class Produto : Entity, IAggregateRoot
    {
        public Guid CategoriaId { get; private set; }
        public Guid UnidadeMedidaId { get; private set; }
        public Guid? MarcaId { get; private set; }
        public int Codigo { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public decimal Valor { get; private set; }
        public int QuantidadeEstoque { get; private set; }
        public bool Ativo { get; private set; }

        //EF
        public Categoria Categoria { get; private set; }
        public UnidadeMedida UnidadeMedida { get; private set; }
        public Marca Marca { get; private set; }
        public ICollection<Combo> Combos { get; private set; }

        public Produto(string nome, string descricao,decimal valor, bool ativo, Guid categoriaId,Guid unidadeMedidaId, Guid? marcaId = null)
        {
            Nome = nome;
            Descricao = descricao;
            Valor = valor;
            Ativo = ativo;

            CategoriaId = categoriaId;
            UnidadeMedidaId = unidadeMedidaId;
            MarcaId = marcaId;
        }

        public override bool EhValido()
        {
            ValidationResult = new ProdutoValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
