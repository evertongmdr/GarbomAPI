using Garbom.Catalogo.Domain.Events;
using Garbom.Catalogo.Domain.Interfaces.Repositories;
using Garbom.Catalogo.Domain.Interfaces.Services;
using Garbom.Catalogo.Domain.Models;
using Garbom.Core.Communication.Mediator;
using Garbom.Core.Domain.Messages.CommonMessages.Notifications;
using Garbom.Core.Domain.Objects;
using Garbom.Core.Domain.Objects.CDTO;
using Garbom.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Garbom.Catalogo.Domain.Services
{
    public class EstoqueService : Service, IEstoqueService
    {

        private readonly IMediatorHandler _mediatorHandler;
        private readonly IReadOnlyProdutoRepository _readOnlyProdutoRepository;
        private readonly IWriteOnlyProdutoRepository _writeOnlyProdutoRepository;

        public EstoqueService(
            DomainNotificationContext domainNotificationContext,
            IMediatorHandler mediatorHandler,
        IReadOnlyProdutoRepository readOnlyProdutoRepository,
            IWriteOnlyProdutoRepository writeOnlyProdutoRepository) : base(domainNotificationContext)
        {

            _mediatorHandler = mediatorHandler;
            _readOnlyProdutoRepository = readOnlyProdutoRepository;
            _writeOnlyProdutoRepository = writeOnlyProdutoRepository;
        }

        public async Task<bool> DebitarEstoque(Guid produtoId, int quantidade)
        {
            if (!await DebitarItemEstoque(produtoId, quantidade))
                return false;

            return await PersistirDados(_writeOnlyProdutoRepository.UnitOfWork);
        }

        private async Task<bool> DebitarItemEstoque(Guid produtoId, int quantidade)
        {
            var produto = await _readOnlyProdutoRepository.ObterPorId<Produto>(produtoId);

            if (produto == null)
            {
                _domainNotificationContext.AddNotificacao(new DomainNotification("estoque", "Produto não encontrado"));
                return false;
            }

            if (!produto.PossuiEstoque(quantidade))
            {
                _domainNotificationContext.AddNotificacao(new DomainNotification("estoque", $"Produto - {produto.Nome} sem estoque"));
                return false;
            }

            produto.DebitarEstoque(quantidade);

            if (produto.EstoqueEstaEmQuantidadeMinima())
            {
                await _mediatorHandler.PublicarDomainEvent(new ProdutoAbaixoEstoqueEvent(produto.Id, produto.QuantidadeEstoque));
            }

            _writeOnlyProdutoRepository.Atualizar(produto);

            return true;
        }

        public async Task<bool> DebitarEstoqueListaProduto(ICollection<PedidoItemCDTO> produtoItens)
        {
            var produtos = await _readOnlyProdutoRepository.ObterTodos<Produto>(p => produtoItens.Select(x => x.Id).ToList().Contains(p.Id));

            if (produtos == null)
            {
                _domainNotificationContext.AddNotificacao(new DomainNotification("estoque", "Produto(s) não encontrado"));
                return false;
            }

            if (produtos.Count != produtoItens.Count)
            {
                _domainNotificationContext.AddNotificacao(new DomainNotification("estoque", "Produto(s) não encontrado"));
                return false;
            }
            Produto p = null;

            foreach (var pi in produtoItens)
            {
                p = produtos.First(x => x.Id == pi.Id);
                if (!p.PossuiEstoque(pi.Quantidade))
                {
                    _domainNotificationContext.AddNotificacao(new DomainNotification("estoque", $"Produto - {p.Nome } sem estoque"));
                    return false;
                }
                p.DebitarEstoque(pi.Quantidade);
                // _writeOnlyProdutoRepository.Atualizar(p);
            }

            return await PersistirDados(_writeOnlyProdutoRepository.UnitOfWork);
        }
        public async Task<bool> ReporEstoque(Guid produtoId, int quantidade)
        {
            if (!await ReporItemEstoque(produtoId, quantidade))
                return false;

            return await PersistirDados(_writeOnlyProdutoRepository.UnitOfWork);
        }

        private async Task<bool> ReporItemEstoque(Guid produtoId, int quantidade)
        {
            var produto = await _readOnlyProdutoRepository.ObterPorId<Produto>(produtoId);

            if (produto == null)
            {
                _domainNotificationContext.AddNotificacao(new DomainNotification("estoque", "Produto não encontrado", HttpStatusCode.NotFound));
                return false;
            }

            produto.ReporEstoque(quantidade);

            _writeOnlyProdutoRepository.Atualizar(produto);

            return true;
        }

        public void Dispose()
        {
            _readOnlyProdutoRepository?.Dispose();
            _writeOnlyProdutoRepository?.Dispose();
        }


    }
}
