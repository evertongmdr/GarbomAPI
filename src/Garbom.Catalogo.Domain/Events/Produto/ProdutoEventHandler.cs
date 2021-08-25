using Garbom.Catalogo.Domain.Interfaces.Repositories;
using Garbom.Catalogo.Domain.Models;
using Garbom.Core.Domain.Interfaces.Services;
using Garbom.Core.Domain.Messages.CommonMessages.Notifications;
using MediatR;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Garbom.Catalogo.Domain.Events
{
    public class ProdutoEventHandler : INotificationHandler<ProdutoAbaixoEstoqueEvent>
    {
        private readonly NotificationContext _notificationContext;
        private readonly IReadOnlyProdutoRepository _readOnlyProdutoRepository;
        private readonly IEmailService _emailService;
        public ProdutoEventHandler(NotificationContext notificationContext, IReadOnlyProdutoRepository readOnlyProdutoRepository, IEmailService emailService)
        {
            _notificationContext = notificationContext;
            _readOnlyProdutoRepository = readOnlyProdutoRepository;
            _emailService = emailService;
        }
        public async Task Handle(ProdutoAbaixoEstoqueEvent messagem, CancellationToken cancellationToken)
        {
            var produto = await _readOnlyProdutoRepository.ObterPorId<Produto>(messagem.AggregateId);

            if (produto == null)
            {
                _notificationContext.AddNotificacao(new DomainNotification("estoque", "Produto não encontrado", HttpStatusCode.NotFound));

            }
            await _emailService.EnviarEmail(new List<string>() { "" }, "garbom@gabrom.com.br", $"O Produto {produto.Nome} está com o estoque mínimo");
        }
    }
}
