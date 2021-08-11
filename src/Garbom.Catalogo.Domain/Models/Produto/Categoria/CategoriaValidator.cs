using FluentValidation;

namespace Garbom.Catalogo.Domain.Models
{
    public class CategoriaValidator : AbstractValidator<Categoria>
    {
        public CategoriaValidator()
        {
            RuleFor(x => x.Nome).NotEmpty()
                .WithMessage("O campo {PropertyName} é obrigatório");
        }
    }
}
