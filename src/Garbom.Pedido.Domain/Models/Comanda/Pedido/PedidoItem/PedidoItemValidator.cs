using FluentValidation;

namespace Garbom.Pedido.Domain.Models
{
    public class PedidoItemValidator : AbstractValidator<PedidoItem>
    {
        public PedidoItemValidator()
        {
            var mensagemErroPadrao = "O campo {PropertyName} é obrigatório";

            RuleFor(x => x.EmpresaId).NotEmpty().WithMessage(mensagemErroPadrao);

            RuleFor(x => x.Id).NotEmpty().WithMessage(mensagemErroPadrao);

            RuleFor(x => x.PedidoId).NotEmpty().WithMessage(mensagemErroPadrao);

            RuleFor(x => x.ProdutoId).NotEmpty().WithMessage(mensagemErroPadrao);

        }
    }
}
