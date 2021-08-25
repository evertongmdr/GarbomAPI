using Garbom.Core.Domain.Objects;
using System;
using System.Collections.Generic;

namespace Garbom.Pedido.Domain.Models
{
    public class Pedido : Entity
    {
        public Guid FuncionarioId { get; private set; }
        public Guid ComandaId { get; private set; }
        public string NomeFuncionario { get; private set; }
        public long Codigo { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public EStatusPedido StatusPedido { get; private set; }
        public decimal ValorTotal { get; private set; }

        public Pedido(Guid empresaId, Guid comandaId, Guid funcionarioId, string nomeFuncionario, DateTime dataCadastro, EStatusPedido statusPedido, decimal valorTotal, ICollection<PedidoItem> pedidoItens = null,Guid? id = null) : base(empresaId, id)
        {
            ComandaId = comandaId;
            FuncionarioId = funcionarioId;
            NomeFuncionario = nomeFuncionario;
            DataCadastro = dataCadastro;
            StatusPedido = statusPedido;
            ValorTotal = valorTotal;
            PedidoItens = pedidoItens;
        }

        //EF Rel.
        protected Pedido() { }
        public Comanda Comanda { get; private set; }
        public ICollection<PedidoItem> PedidoItens { get; private set; }

        public override bool EhValido()
        {
            ValidationResult = new PedidoValidator().Validate(this);
            return ValidationResult.IsValid;
        }

        public static class PedidoFactory
        {
            public static Pedido NovoPedido(Guid empresaId, Guid comandaId, Guid funcionarioId, string nomeFuncionario)
            {
                var pedido = new Pedido
                {
                    ComandaId = comandaId,
                    FuncionarioId = funcionarioId,
                    NomeFuncionario = nomeFuncionario,
                    StatusPedido = EStatusPedido.Iniciado,
                    ValorTotal = 0
                };
                pedido.AtribuirEmpresaId(empresaId);

                return pedido;
            }
        }
    }
}
