using FluentValidation.Results;
using MediatR;
using System;


namespace Garbom.Core.Domain.Messages
{
    public class Command<TResult> : Message, IRequest<TResult>  
    {
        public DateTime Timestamp { get; private set; } // guarda a hora que ele foi chamado
        public ValidationResult ValidationResult { get; set; }

        protected Command()
        {
            Timestamp = DateTime.Now;
        }

        public virtual bool EhValido()
        {
            throw new NotImplementedException();
        }
    }
}
