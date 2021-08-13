using FluentValidation;

namespace Garbom.Pedido.Domain.Models
{
    public class ProdutoValidator : AbstractValidator<Produto>
    {
        public ProdutoValidator()
        {
            var mensagemErroPadrao = "O campo {PropertyName} é obrigatório";

            RuleFor(x => x.Id).NotEmpty().WithMessage(mensagemErroPadrao);

            RuleFor(x => x.EmpresaId).NotEmpty().WithMessage(mensagemErroPadrao);

            RuleFor(x => x.Nome).NotEmpty().WithMessage(mensagemErroPadrao);

            RuleFor(x => x.ValorUnitario).GreaterThanOrEqualTo(0)
                 .WithMessage("O valor do campo {PropertyName} deve ser maior que 0");

        }
    }
}
