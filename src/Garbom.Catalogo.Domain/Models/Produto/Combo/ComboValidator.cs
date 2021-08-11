using FluentValidation;

namespace Garbom.Catalogo.Domain.Models
{
    public class ComboValidator : AbstractValidator<Combo>
    {
        public ComboValidator()
        {
            var mensagemPadraoErro = "O campo {PropertyName} é obrigatório";

            RuleFor(x => x.UsuarioCriacaoId).NotEmpty()
                .WithMessage(mensagemPadraoErro);

            RuleFor(x => x.Nome).NotEmpty()
            .WithMessage(mensagemPadraoErro);

            RuleFor(x => x.UsuarioCriacaoId).NotEmpty()
            .WithMessage(mensagemPadraoErro);
        }
    }
}
