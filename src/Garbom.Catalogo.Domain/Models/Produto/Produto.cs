using Garbom.Core.Domain.Objects;
using System;
using System.Collections.Generic;

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
        /// <summary>
        /// Define se o produto vai ter controle de estoque
        /// </summary>
        public bool ControlarEstoque { get; private set; }
        /// <summary>
        /// Define a quantidade mínima de estoque do produto.
        /// </summary>
        public int QuantidadeEstoqueMinima { get; private set; }
        public int QuantidadeEstoque { get; private set; }
        public bool Ativo { get; private set; }

        //EF Rel.
        public Categoria Categoria { get; private set; }
        public UnidadeMedida UnidadeMedida { get; private set; }
        public Marca Marca { get; private set; }
        public ICollection<Combo> Combos { get; private set; }

        protected Produto() { }
        public Produto(Guid empresaId, Guid categoriaId, Guid unidadeMedidaId, int codigo, string nome, string descricao, decimal valor, bool controlarEstoque, bool ativo, Guid? marcaId = null, Guid? id = null) : base(empresaId, id)
        {
            Codigo = codigo;
            Nome = nome;
            Descricao = descricao;
            Valor = valor;
            ControlarEstoque = controlarEstoque;
            Ativo = ativo;

            CategoriaId = categoriaId;
            UnidadeMedidaId = unidadeMedidaId;
            MarcaId = marcaId;
        }
        public void AtribuirQuantidadeEstoqueMinima(int quantidadeEstoqueMinima)
        {
            QuantidadeEstoqueMinima = quantidadeEstoqueMinima;
        }

        public void AtribuirQuantidadeEstoque(int quantidadeEstoque)
        {
            QuantidadeEstoque = quantidadeEstoque;
        }

        public bool PossuiEstoque(int quantidade)
        {
            return QuantidadeEstoque >= quantidade;
        }

        public void DebitarEstoque(int quantidade)
        {
            if (quantidade < 0) quantidade *= -1;
            if (!PossuiEstoque(quantidade)) throw new DomainException("Estoque insuficiente");
            QuantidadeEstoque -= quantidade;
        }

        public void ReporEstoque(int quantidade)
        {
            QuantidadeEstoque += quantidade;
        }

        public bool EstoqueEstaEmQuantidadeMinima()
        {
            return QuantidadeEstoque <= QuantidadeEstoqueMinima;
        }

        public void Destivar() => Ativo = false;

        public override bool EhValido()
        {
            ValidationResult = new ProdutoValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
