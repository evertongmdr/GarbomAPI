using System.Net;

namespace Garbom.Core.Domain.Messages.CommonMessages.Notifications
{
    public class DomainNotification
    {
        public DomainNotification(string key, string message, HttpStatusCode? erroCode = HttpStatusCode.BadRequest)
        {
            Key = key;
            Message = message;
            ErroCode = (HttpStatusCode)erroCode;
        }

        public string Key { get; set; }
        public string Message { get; set; }
        public HttpStatusCode ErroCode { get; set; }
    }
}
