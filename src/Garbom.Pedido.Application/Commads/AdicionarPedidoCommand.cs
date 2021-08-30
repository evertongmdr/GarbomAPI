using FluentValidation;
using Garbom.Core.Domain.Messages;
using Garbom.Pedido.Application.DTOS;
using System;
using System.Collections.Generic;

namespace Garbom.Pedido.Application.Commads
{
    public class AdicionarPedidoCommand : Command<bool>
    {
        public Guid ComandaId { get; private set; }
        public Guid FuncionarioId { get; private set; }
        public string NomeFuncionario { get; private set; }
        public decimal ValorTotal { get; private set; }
        public ICollection<PedidoItemDTO> PedidoItens { get; private set; }

        public AdicionarPedidoCommand(Guid empresaId, Guid comandaId, Guid funcionarioId, string nomeFuncionario, decimal valorTotal, IList<PedidoItemDTO> pedidoItens)
        {

            AggregateId = comandaId;

            EmpresaId = empresaId;
            ComandaId = comandaId;

            FuncionarioId = funcionarioId;
            NomeFuncionario = nomeFuncionario;
            ValorTotal = valorTotal;
            PedidoItens = pedidoItens;
        }
        public override bool EhValido()
        {
            ValidationResult = new AdicionarItemPedidoValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class AdicionarItemPedidoValidation : AbstractValidator<AdicionarPedidoCommand>
    {
        public AdicionarItemPedidoValidation()
        {

            RuleFor(c => c.ComandaId)
                .NotEqual(Guid.Empty)
                .WithMessage("Id da comanda inválido");

            RuleFor(c => c.FuncionarioId)
                .NotEqual(Guid.Empty)
                .WithMessage("Id do funcionário inválido");

            RuleFor(c => c.NomeFuncionario)
                .NotEmpty()
                .WithMessage("O nome do funcionário não foi informado");

            RuleFor(c => c.PedidoItens.Count)
                    .GreaterThan(0)
                    .WithMessage("O pedido precisa ter no mínimo 1 item");

            //TODO: verificar único produto no pedido.
        }


    }
}

