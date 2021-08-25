﻿
using AutoMapper;
using Garbom.Core.Domain.Messages;
using Garbom.Core.Domain.Messages.CommonMessages.Notifications;
using Garbom.Pedido.Application.DTOS;
using Garbom.Pedido.Domain.Interfaces.Repositories;
using Garbom.Pedido.Domain.Models;
using MediatR;
using System;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Garbom.Pedido.Application.Commads
{
    public class ComandaCommandHandler : CommandHandler,
        IRequestHandler<AbrirComandaCommand, Guid>,
        IRequestHandler<AdicionarPedidoCommand, bool>
    {

        private readonly IMapper _mapper;
        private readonly IReadOnlyComandaRepository _readOnlyComandaRepository;
        private readonly IWriteOnlyComandaRepository _writeOnlyComandaRepository;
        public ComandaCommandHandler(
            NotificationContext notificationContext,
            IMapper mapper,
            IReadOnlyComandaRepository readOnlyComandaRepository,
            IWriteOnlyComandaRepository writeOnlyComandaRepository) : base(notificationContext)
        {
            _mapper = mapper;
            _readOnlyComandaRepository = readOnlyComandaRepository;
            _writeOnlyComandaRepository = writeOnlyComandaRepository;
        }
        public async Task<Guid> Handle(AbrirComandaCommand mensagem, CancellationToken cancellationToken)
        {
            if (!ValidarComando(mensagem)) return default;

            var mesa = await _readOnlyComandaRepository.ObterPorId<Mesa>(mensagem.MesaId);

            if (mesa == null)
            {
                _notificationContext.AddNotificacao(new DomainNotification("comanda", "Mesa não encontrado", HttpStatusCode.NotFound));
                return default;
            }

            if (mesa.StatusMesa != EStatusMesa.Disponivel)
            {
                _notificationContext.AddNotificacao(new DomainNotification("comanda", "Mesa não disponível", HttpStatusCode.NotFound));
                return default;
            }

            var comanda = new Comanda(mensagem.EmpresaId, mensagem.MesaId, DateTime.Now, EStatusComanda.Aberta, 0);

            _writeOnlyComandaRepository.Adicionar(comanda);

            var mesaComStatusAtualizado = (Mesa)mesa.Clone();
            mesaComStatusAtualizado.MesaOcupada();

            _writeOnlyComandaRepository.AtualizarMesa(mesa, mesaComStatusAtualizado);

            if (!await _writeOnlyComandaRepository.UnitOfWork.Commit()) return default;

            return comanda.Id;
        }

        public async Task<bool> Handle(AdicionarPedidoCommand mensagem, CancellationToken cancellationToken)
        {
            if (!ValidarComando(mensagem)) return default;

            var comanda = _readOnlyComandaRepository.ObterPorId<Comanda>(mensagem.ComandaId);

            if (comanda == null)
            {
                _notificationContext.AddNotificacao(new DomainNotification("comanda", "Comanda não encontrada", HttpStatusCode.NotFound));
                return default;
            }

            var pedidoItenIds = mensagem.PedidoItens.Select(pi => pi.ProdutoId);
            var existeProdutoNaoEcontrado = await _readOnlyComandaRepository.ObterTodos<Produto>(p => !pedidoItenIds.Contains(p.Id));

            if (existeProdutoNaoEcontrado != null)
            {
                existeProdutoNaoEcontrado.ToList().ForEach(produto =>
                {
                    _notificationContext.AddNotificacao(new DomainNotification("comanda", $"O produto {produto.Nome } não foi encontrado", HttpStatusCode.NotFound));
                });
                return default;
            }

            var novoPedido = new Domain.Models.Pedido(mensagem.EmpresaId, mensagem.ComandaId,
                mensagem.FuncionarioId, mensagem.NomeFuncionario, DateTime.Now, EStatusPedido.Iniciado, mensagem.ValorTotal,
                mensagem.PedidoItens.Select(pi => _mapper.Map<PedidoItem>(pi)).ToList());

            _writeOnlyComandaRepository.AdicionarPedido(novoPedido);

            if (!await _writeOnlyComandaRepository.UnitOfWork.Commit()) return default;

            return true;

        }
    }

}
