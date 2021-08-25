using System.Collections.Generic;

namespace Garbom.Core.Domain.Messages.CommonMessages.Notifications
{
    public class Result<T> //where T : class
    {
        public bool Sucesso { get; set; }
        public T Dado { get; set; }
        public List<string> Errors { get; set; }
    }
}
