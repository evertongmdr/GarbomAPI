using FluentValidation.Results;
using Garbom.Catalogo.Domain.Interfaces.Repositories;
using Garbom.Catalogo.Domain.Interfaces.Services;
using Garbom.Core.Domain.Objects;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Garbom.Catalogo.Domain.Services
{
    public class EstoqueService : Service, IEstoqueService
    {
        private readonly IReadOnlyProdutoRepository _readOnlyProdutoRepository;
        private readonly IWriteOnlyProdutoRepository _writeOnlyProdutoRepository;


        public EstoqueService(IReadOnlyProdutoRepository readOnlyProdutoRepository,
            IWriteOnlyProdutoRepository writeOnlyProdutoRepository)
        {
            _readOnlyProdutoRepository = readOnlyProdutoRepository;
            _writeOnlyProdutoRepository = writeOnlyProdutoRepository;
        }

        public async Task<ValidationResult> DebitarEstoque(Guid produtoId, int quantidade)
        {

            if (!await DebitarItemEstoque(produtoId, quantidade))
                return ValidationResult;

            return await PersistirDados(_writeOnlyProdutoRepository.UnitOfWork);
        }

        private async Task<bool> DebitarItemEstoque(Guid produtoId, int quantidade)
        {
            var produto = await _readOnlyProdutoRepository.ObterPorId(produtoId);

            if (produto == null)
            {
                AdicionarErro("Estoque", "Produto não encontrado", HttpStatusCode.NotFound);
                return false;
            }

            if (!produto.PossuiEstoque(quantidade))
            {
                AdicionarErro("Estoque", $"Produto - {produto.Nome} sem estoque", HttpStatusCode.BadRequest);
                return false;
            }

            produto.DebitarEstoque(quantidade);

            // TODO: 10 pode ser parametrizavel em arquivo de configuração
            if (produto.QuantidadeEstoque < 10) { }

            _writeOnlyProdutoRepository.Atualizar(produto);

            return true;
        }
        public async Task<ValidationResult> ReporEstoque(Guid produtoId, int quantidade)
        {
            if (!await ReporItemEstoque(produtoId, quantidade))
                return ValidationResult;

            return await PersistirDados(_writeOnlyProdutoRepository.UnitOfWork);
        }

        private async Task<bool> ReporItemEstoque(Guid produtoId, int quantidade)
        {
            var produto = await _readOnlyProdutoRepository.ObterPorId(produtoId);

            if (produto == null)
            {
                AdicionarErro("Estoque", "Produto não encontrado", HttpStatusCode.NotFound);
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
