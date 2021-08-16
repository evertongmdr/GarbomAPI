﻿using FluentValidation.Results;
using System;
namespace Garbom.Core.Domain.Objects
{
    public abstract class Entity
    {
        public Guid Id { get; private set; }
        public Guid EmpresaId { get; private set; }
        public ValidationResult ValidationResult { get; set; }
        protected Entity()
        {
            Id = Guid.NewGuid();
        }
        public Entity(Guid empresaId, Guid? id = null)
        {
            EmpresaId = empresaId;
            Id = id == null ? Id = Guid.NewGuid() : Id = id.Value;
           
        }
        public virtual bool EhValido()
        {
            throw new NotImplementedException();
        }
       
    }
}
