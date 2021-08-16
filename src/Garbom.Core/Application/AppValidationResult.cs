using FluentValidation.Results;

namespace Garbom.Core.Application
{
    public class AppValidationResult<T> where T : class
    {
        public ValidationResult ValidationResult { get; set; }
        public T Objeto { get; set; }

        public AppValidationResult(T objeto = null)
        {
            Objeto = objeto;
            ValidationResult = new ValidationResult();
        }

        public AppValidationResult(ValidationResult validationResult)
        {
            ValidationResult = validationResult;
        }

        public bool EhValido()
        {
            return ValidationResult.IsValid;
        }
    }
}
