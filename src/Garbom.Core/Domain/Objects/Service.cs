using FluentValidation.Results;
using Garbom.Core.Domain.Interfaces;
using System.Net;
using System.Threading.Tasks;

namespace Garbom.Core.Domain.Objects
{
    public abstract class Service
    {
        public ValidationResult ValidationResult { get; set; }

        public Service()
        {
            ValidationResult = new ValidationResult();
        }

        protected void AdicionarErro(string propertyName, string errorMessage, HttpStatusCode httpStatusCode)
        {
            var validationFailure = new ValidationFailure(propertyName, errorMessage);
            validationFailure.ErrorCode = httpStatusCode.ToString();
            ValidationResult.Errors.Add(validationFailure);
        }
        protected void AdicionarErro(string errorMessage, HttpStatusCode httpStatusCode)
        {
            var validationFailure = new ValidationFailure(string.Empty, errorMessage);
            validationFailure.ErrorCode = httpStatusCode.ToString();

            ValidationResult.Errors.Add(validationFailure);
        }

        protected async Task<ValidationResult> PersistirDados(IUnitOfWork uow)
        {
            if (!await uow.Commit()) AdicionarErro("Houve um erro ao persistir os dados", HttpStatusCode.BadRequest);

            return ValidationResult;
        }
    }
}
