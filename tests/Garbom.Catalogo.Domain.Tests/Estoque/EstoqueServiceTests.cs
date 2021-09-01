using Garbom.Catalogo.Domain.Interfaces.Repositories;
using Garbom.Catalogo.Domain.Services;
using Garbom.Catalogo.Domain.Tests.Produto;
using Garbom.Core.Domain.Interfaces.Objects;
using Garbom.Core.Domain.Messages.CommonMessages.Notifications;
using Moq;
using Moq.AutoMock;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Garbom.Catalogo.Domain.Tests.Estoque
{
    [Collection(nameof(ProdutoCollection))]
    public class EstoqueServiceTests
    {
        private readonly AutoMocker _mocker;
        private readonly ProdutoFixture _produtoFixture;

        public EstoqueServiceTests(ProdutoFixture produtoFixture)
        {
            _mocker = new AutoMocker();
            _produtoFixture = produtoFixture;
        }

        [Fact(DisplayName = "Debitar Estoque Produto com sucesso")]
        public async Task Estoque_DebeitarEstoqueProduto_DeveExecutarComSucesso()
        {
            //Arrange
            var produto = _produtoFixture.GerarProdutoComEstoqueValido();
            var estoqueService = _mocker.CreateInstance<EstoqueService>();

            _mocker.GetMock<IReadOnlyProdutoRepository>().Setup(rp => rp.ObterPorId<Domain.Models.Produto>(produto.Id))
               .Returns(Task.FromResult(produto));

            _mocker.GetMock<IWriteOnlyProdutoRepository>().Setup(wp => wp.UnitOfWork.Commit())
                .Returns(Task.FromResult(true));

            //Act
            var result = await estoqueService.DebitarEstoque(produto.Id, 5);

            //Assert
            Assert.True(result);
            _mocker.GetMock<IReadOnlyProdutoRepository>().Verify(rp => rp.ObterPorId<Domain.Models.Produto>(produto.Id), Times.Once);
            _mocker.GetMock<IWriteOnlyProdutoRepository>().Verify(wp => wp.UnitOfWork.Commit(), Times.Once);
        }

        [Fact(DisplayName = "Produto não possui estoque suficiente")]
        public async Task Estoque_ProdutoComEstoqueInsuficiente_DeveRetornarFalso()
        {
            //Arrange
            var produto = _produtoFixture.GerarProdutoComEstoqueValido();
            var estoqueService = _mocker.CreateInstance<EstoqueService>();

            _mocker.GetMock<IReadOnlyProdutoRepository>().Setup(rp => rp.ObterPorId<Domain.Models.Produto>(produto.Id))
               .Returns(Task.FromResult(produto));

            _mocker.GetMock<IWriteOnlyProdutoRepository>().Setup(wp => wp.UnitOfWork.Commit())
                .Returns(Task.FromResult(true));

            //Act
            var result = await estoqueService.DebitarEstoque(produto.Id, 11);

            //Assert
            Assert.False(result);

            _mocker.GetMock<IReadOnlyProdutoRepository>().Verify(rp => rp.ObterPorId<Domain.Models.Produto>(produto.Id), Times.Once);
            _mocker.GetMock<IWriteOnlyProdutoRepository>().Verify(wp => wp.UnitOfWork.Commit(), Times.Never);
        }
        [Fact(DisplayName = "Estoque Produto Reposto com sucesso")]
        public async Task Estoque_ReporEstoqueProduto_DeveRetornarSucesso()
        {
            //Arrange
            var quantidade = 5;
            var produto = _produtoFixture.GerarProdutoComEstoqueValido();
            var estoqueService = _mocker.CreateInstance<EstoqueService>();


            _mocker.GetMock<IReadOnlyProdutoRepository>().Setup(rp => rp.ObterPorId<Domain.Models.Produto>(produto.Id))
              .Returns(Task.FromResult(produto));

            _mocker.GetMock<IWriteOnlyProdutoRepository>().Setup(wp => wp.UnitOfWork.Commit())
                .Returns(Task.FromResult(true));

            //Act
            var result = await estoqueService.ReporEstoque(produto.Id, quantidade);

            //Assert
            Assert.True(true);
            _mocker.GetMock<IReadOnlyProdutoRepository>().Verify(rp => rp.ObterPorId<Domain.Models.Produto>(produto.Id), Times.Once);
            _mocker.GetMock<IWriteOnlyProdutoRepository>().Verify(wp => wp.Atualizar(It.IsAny<Domain.Models.Produto>()), Times.Once);
            _mocker.GetMock<IWriteOnlyProdutoRepository>().Verify(wp => wp.UnitOfWork.Commit(), Times.Once);

        }
    }
}
