using FluentValidation.Results;
using System;
namespace Garbom.Core.Domain.Objects
{
    public abstract class Entity
    {
        public Guid Id { get; private set; }
        public Guid EmpresaId { get; private set; }
        public ValidationResult ValidationResult { get; set; }
        public abstract bool EhValido();
        protected Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}
