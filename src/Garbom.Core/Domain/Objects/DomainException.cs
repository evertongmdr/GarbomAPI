using System;

namespace Garbom.Core.Domain.Objects
{
    public class DomainException : Exception
    {
        public DomainException() {}
        public DomainException(string mensagem) : base(mensagem) {}
        public DomainException(string mensagem, Exception excecaoInterna) : base(mensagem,excecaoInterna) {}

    }
}
