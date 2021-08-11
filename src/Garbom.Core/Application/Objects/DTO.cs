using System;

namespace Garbom.Core.Application.Objects
{
    public abstract class DTO
    {
        public Guid Id { get; private set; }
        public Guid EmpresaId { get; private set; }
    }
}
