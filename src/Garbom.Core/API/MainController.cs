using Garbom.Core.Domain.Messages.CommonMessages.Notifications;
using Garbom.Core.Domain.Objects;
using Garbom.Core.Helps.Objects;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace Garbom.Core.API
{
    [ApiController]
    //[Authorize]   
    public abstract class MainController : ControllerBase
    {
        protected readonly NotificationContext _notificationContext;

        public MainController(NotificationContext notificationContext)
        {
            _notificationContext = notificationContext;
        }

        protected bool OperacaoValida()
        {
            return !_notificationContext.TemNotificacoes;
        }

        protected IEnumerable<string> ObterMensagensErro()
        {
            return _notificationContext.DomainNotifications.Select(n => n.Message).ToList();
        }

        protected void NotificarErro(string codigo, string mensagem)
        {
            _notificationContext.AddNotificacao("TODO", mensagem);
        }

        protected ActionResult CustomResponse(object dado = null)
        {
            var sucesso = OperacaoValida() ? true : false;

            var result = new Result<object>
            {
                Sucesso = sucesso,
                Errors = _notificationContext.DomainNotifications.Select(n => n.Message).ToList(),
                Dado = dado
            };
            return StatusCode(400, result);
        }
        protected ActionResult CriacaoSucessoResponse(object dado = null)
        {
            var result = new Result<object>
            {
                Sucesso = true,
                Errors = null,
                Dado = dado
            };

            return StatusCode(201, result);
        }

        protected ActionResult OkResponse(object dado = null)
        {
            var result = new Result<object>
            {
                Sucesso = true,
                Errors = null,
                Dado = dado
            };

            return StatusCode(200, result);
        }

        protected ActionResult ErroResponse(object dado = null)
        {
            var codigoErro = (int)_notificationContext.DomainNotifications.Select(n => n.ErroCode).First();
            var result = new Result<object>
            {
                Sucesso = false,
                Errors = _notificationContext.DomainNotifications.Select(n => n.Message).ToList(),
                Dado = dado
            };

            return StatusCode(codigoErro, result);
        }
        protected void CriarUri<T>(string nomeRota, T recursoParametro, ListaPaginadaDinamica listaDinamica) where T : RecursoParametro
        {

            //TODO: ignorar os campos vazio da classe recursoParametro

            string linkPaginaAnterior = "", linkPaginaProxima = "";
            var numeroPaginaAtual = recursoParametro.NumeroPagina;

            if (listaDinamica.TemAnterior)
            {
                recursoParametro.NumeroPagina = numeroPaginaAtual -1 ;
                linkPaginaAnterior =  Url.Link(nomeRota, recursoParametro);

            }

            if (listaDinamica.TemProxima)
            {
                recursoParametro.NumeroPagina = numeroPaginaAtual + 1;
                linkPaginaProxima = Url.Link(nomeRota, recursoParametro);
            }
            var metaData = new
            {
                quantidadeToal = listaDinamica.QuantidadeTotal,
                tamanhoPagina = listaDinamica.TamanhoPagina,
                paginaAtual = listaDinamica.PaginaAtual,
                totalpaginas = listaDinamica.TotalPaginas,
                linkPaginaAnterior = linkPaginaAnterior,
                linkPaginaProxima = linkPaginaProxima
            };
            Response.Headers.Add("Pagination", JsonSerializer.Serialize(metaData));
        }
    }
}
