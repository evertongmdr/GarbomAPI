using FluentValidation;
using Garbom.Core.Domain.Messages;
using MediatR;
using System;

namespace Garbom.Pedido.Application.Commads
{
    public class AbrirComandaCommand : Command<Guid>
    {
        public Guid MesaId { get; private set; }

        public AbrirComandaCommand(Guid mesaId)
        {
            MesaId = mesaId;
        }

        public override bool EhValido()
        {
            ValidationResult = new AbrirComandaCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class AbrirComandaCommandValidator : AbstractValidator<AbrirComandaCommand>
    {
        public AbrirComandaCommandValidator()
        {
            var mensagemPadraoErro = "O campo {PropertyName} é obrigatório";

            RuleFor(x => x.MesaId).NotEmpty().WithMessage(mensagemPadraoErro);

            RuleFor(x => x.EmpresaId).NotEmpty().WithMessage(mensagemPadraoErro);
        }
    }
}
