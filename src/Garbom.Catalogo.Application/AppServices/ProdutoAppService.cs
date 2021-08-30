using AutoMapper;
using Garbom.Catalogo.Application.DTOS;
using Garbom.Catalogo.Application.Interfaces;
using Garbom.Catalogo.Domain.Interfaces.Repositories;
using Garbom.Catalogo.Domain.Interfaces.Services;
using Garbom.Catalogo.Domain.Models;
using Garbom.Core.Domain.Messages.CommonMessages.Notifications;
using Garbom.Core.Domain.Objects;
using Garbom.Core.Helps.Objects;
using Garbom.Core.Helps.Solutions.ValidacaoPropriedades;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Garbom.Catalogo.Application.AppServices
{
    public class ProdutoAppService : Service, IProdutoAppService
    {

        private readonly IReadOnlyProdutoRepository _readOnlyProdutoRepository;
        private readonly IWriteOnlyProdutoRepository _writeOnlyProdutoRepository;
        private readonly IEstoqueService _estoqueService;
        private readonly IMapper _mapper;

        public ProdutoAppService(
            NotificationContext notificationContext,
            IReadOnlyProdutoRepository readOnlyProdutoRepository,
            IWriteOnlyProdutoRepository writeOnlyProdutoRepository,
            IEstoqueService estoqueService,
            IMapper mapper
            ) : base(notificationContext)
        {
            _readOnlyProdutoRepository = readOnlyProdutoRepository;
            _writeOnlyProdutoRepository = writeOnlyProdutoRepository;
            _estoqueService = estoqueService;
            _mapper = mapper;
        }

        #region Produto

        public async Task<ProdutoDTO> ObterProdutoPorId(Guid id)
        {
            return _mapper.Map<ProdutoDTO>(await _readOnlyProdutoRepository.ObterPorId<Produto>(id));
        }

        public async Task<ICollection<Produto>> ObterProdutosPorIds(ICollection<Guid> ids)
        {
           return await _readOnlyProdutoRepository.ObterTodos<Produto>(p => ids.Contains(p.Id), null, true);
        }

        public async Task<ListaPaginadaDinamica> ObterProdutos(ProdutoRecursoParametro produtoRecursoParametro)
        {
            if (string.IsNullOrWhiteSpace(produtoRecursoParametro.Selecionar))
            {
                _notificationContext.AddNotificacao(new DomainNotification("produto", $"O parametro selecionar não pode ser vazio"));
                return default;
            }
            var propriedadadeInvalida = ValidacaoPropriedades
                      .TemPropriedadesValida<Produto>(produtoRecursoParametro.Selecionar);

            if (!string.IsNullOrEmpty(propriedadadeInvalida))
            {
                _notificationContext.AddNotificacao(new DomainNotification("produto", $"O parametro {propriedadadeInvalida} da pesquisa é inválido"));
                return default;
            }

            return await _readOnlyProdutoRepository.ObterProdutos(produtoRecursoParametro);
        }

        public async Task<ProdutoDTO> AdicionarProduto(ProdutoDTO produtoDTO)
        {
            var produto = _mapper.Map<Produto>(produtoDTO);

            if (!produto.EhValido())
            {
                _notificationContext.AddNotificacoes(produto.ValidationResult);
                return default;
            }
            var codigoJaExiste = await _readOnlyProdutoRepository
                .ExisteAlgum(p => p.EmpresaId == produto.EmpresaId && p.Codigo == produto.Codigo);

            if (codigoJaExiste)
            {
                _notificationContext.AddNotificacao(new DomainNotification("produto", "Código do produto já cadastrado"));
                return default;
            }

            _writeOnlyProdutoRepository.Adicionar(produto);

            produtoDTO.Id = produto.Id;

            if (!await _writeOnlyProdutoRepository.UnitOfWork.Commit())
            {
                _notificationContext.AddNotificacao(new DomainNotification("produto", "Houve um erro ao persistir os dados"));
                return default;
            }

            return produtoDTO;
        }

        public async Task<ProdutoDTO> AtualizarProduto(ProdutoDTO produtoDTO)
        {
            var produtoAtualizado = _mapper.Map<Produto>(produtoDTO);

            if (!produtoAtualizado.EhValido())
            {
                _notificationContext.AddNotificacoes(produtoAtualizado.ValidationResult);
                return default;
            }

            var produto = await _readOnlyProdutoRepository.ObterPorId<Produto>(produtoAtualizado.Id);

            if (produto == null)
            {
                _notificationContext.AddNotificacao(new DomainNotification("produto", "Produto não encontrado", HttpStatusCode.NotFound));
                return default;
            }

            _writeOnlyProdutoRepository.Atualizar(produto, produtoAtualizado);

            if (!await PersistirDados(_writeOnlyProdutoRepository.UnitOfWork))
                return default;

            return produtoDTO;

        }
        #endregion

        #region Categoria
        public async Task<CategoriaDTO> ObterCategoriaPorId(Guid id)
        {
            return _mapper.Map<CategoriaDTO>(await _readOnlyProdutoRepository.ObterCategoriaPorId(id));
        }

        public async Task<CategoriaDTO> AdicionarCategoria(CategoriaDTO categoriaDTO)
        {
            var categoria = _mapper.Map<Categoria>(categoriaDTO);
            if (!categoria.EhValido())
            {
                _notificationContext.AddNotificacoes(categoria.ValidationResult);
                return default;
            }

            _writeOnlyProdutoRepository.AdicionarCategoria(categoria);
            categoriaDTO.Id = categoria.Id;

            if (!await PersistirDados(_writeOnlyProdutoRepository.UnitOfWork))
                return default;

            return categoriaDTO;
        }
        #endregion

        #region Estoque
        public async Task<bool> DebitarEstoque(Guid id, int quantidade)
        {
            return await _estoqueService.DebitarEstoque(id, quantidade);
        }

        public async Task<bool> ReporEstoque(Guid id, int quantidade)
        {
            return await _estoqueService.ReporEstoque(id, quantidade);
        }
        #endregion

        public void Dispose()
        {
            _readOnlyProdutoRepository?.Dispose();
            _writeOnlyProdutoRepository?.Dispose();
            _estoqueService?.Dispose();
        }

     
    }
}
