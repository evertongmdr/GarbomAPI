
using FluentValidation;

namespace Garbom.Catalogo.Domain.Models
{
    public class ProdutoValidator : AbstractValidator<Produto>
    {
        public ProdutoValidator()
        {
            var mensagemPadraoErro = "O campo {PropertyName} é obrigatório";
            RuleFor(x => x.CategoriaId).NotEmpty()
                .WithMessage(mensagemPadraoErro);

            RuleFor(x => x.Nome).NotEmpty()
                .WithMessage(mensagemPadraoErro);

            RuleFor(x => x.Valor).GreaterThan(0)
                .WithMessage("O valor do campo {PropertyName} deve ser maior que 0");
        }
    }
}
