using FluentValidation.Results;
using Garbom.Core.Domain.Interfaces;
using System.Net;
using System.Threading.Tasks;

namespace Garbom.Core.Application
{
    public class AppService
    {
        public ValidationResult ValidationResult { get; set; }

        public AppService()
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
        protected async Task<AppValidationResult<T>> PersistirDados<T>(IUnitOfWork uow, T objeto) where T : class
        {
            var validaionFailure = new ValidationFailure(string.Empty,
                "Houve um erro ao persistir os dados", HttpStatusCode.BadRequest.ToString());

            var validatoinResult = new ValidationResult(new[] { validaionFailure });

            if (!await uow.Commit())
                return new AppValidationResult<T>(validatoinResult);

            return new AppValidationResult<T>(objeto);
        }
    }
}
