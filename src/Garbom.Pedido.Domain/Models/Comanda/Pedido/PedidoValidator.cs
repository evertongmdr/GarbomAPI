using FluentValidation;

namespace Garbom.Pedido.Domain.Models
{
    public class PedidoValidator : AbstractValidator<Pedido>
    {
        public PedidoValidator()
        {

            var mensagemErroPadrao = "O campo {PropertyName} é obrigatório";

            RuleFor(p => p.FuncionarioId).NotEmpty().WithMessage(mensagemErroPadrao);
            RuleFor(p => p.NomeFuncionario).NotEmpty().WithMessage(mensagemErroPadrao);
            RuleFor(p => p.DataCadastro).NotEmpty().WithMessage(mensagemErroPadrao);
        }
    }
}
