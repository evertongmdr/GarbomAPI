using System;

namespace Garbom.Core.Application
{
    public abstract class DTO
    {
        public Guid Id { get;  set; }
        public Guid EmpresaId { get;  set; }
    }
}
