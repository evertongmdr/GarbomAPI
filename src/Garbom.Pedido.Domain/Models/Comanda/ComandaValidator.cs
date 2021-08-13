using FluentValidation;

namespace Garbom.Pedido.Domain.Models
{
    public class ComandaValidator : AbstractValidator<Comanda>
    {
        public ComandaValidator()
        {
            var mensagemErroPadrao = "O campo {PropertyName} é obrigatório";

            RuleFor(x => x.MesaId).NotEmpty().WithMessage(mensagemErroPadrao);

            RuleFor(x => x.DataAbertura).NotEmpty().WithMessage(mensagemErroPadrao);

            RuleFor(x => x.StatusComanda).IsInEnum().WithMessage("O valor do campo {PropertyName} está inválido");

            RuleFor(x => x.ValorTotal).GreaterThanOrEqualTo(0).WithMessage("O valor do campo {PropertyName} está inválido, o valor deve ser maior ou igual a zero");

        }
    }
}