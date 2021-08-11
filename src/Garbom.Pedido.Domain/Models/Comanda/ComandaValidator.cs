using FluentValidation;

namespace Garbom.Pedido.Domain.Models
{
    public class ComandaValidator : AbstractValidator<Comanda>
    {
        public ComandaValidator()
        {
            var mensagemErroPadro = "O campo {PropertyName} é obrigatório";
            RuleFor(x => x.MesaId).NotEmpty().WithMessage(mensagemErroPadro);
            //RuleFor(x =>x.DataAbertura).not
        }
    }
}