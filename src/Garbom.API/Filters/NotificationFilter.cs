using Garbom.Core.Domain.Messages.CommonMessages.Notifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;

namespace Garbom.API.Filters
{
    public class NotificationFilter : IAsyncResultFilter
    {
        private readonly NotificationContext _notificationContext;
        public NotificationFilter(NotificationContext notificationContext)
        {
            _notificationContext = notificationContext;
        }
        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            if (_notificationContext.TemNotificacoes)
            {

                var erroCode = _notificationContext.DomainNotifications.Select(n => n.ErroCode).First();
                var erros = _notificationContext.DomainNotifications.Select(n => n.Message).ToList();

                context.HttpContext.Response.StatusCode = (int)erroCode;
                context.HttpContext.Response.ContentType = "application/json";

                var result = new Result<object>
                {
                    Sucesso = false,
                    Errors = erros
                };

                await context.HttpContext.Response.WriteAsync(JsonConvert.SerializeObject(result));

                return;
            }
            await next();
        }
        
    }
}
