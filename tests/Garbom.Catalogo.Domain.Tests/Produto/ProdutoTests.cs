using Garbom.Catalogo.Domain.Tests.Produto;
using System;
using Xunit;

namespace Garbom.Catalogo.Domain.Tests
{
    [Collection(nameof(ProdutoCollection))]
    public class ProdutoTests
    {
        private readonly ProdutoFixture _produtoFixture;
        public ProdutoTests(ProdutoFixture produtoFixture)
        {
            _produtoFixture = produtoFixture;
        }
        [Fact(DisplayName = "Produto não possui estoque")]
        public void Produto_ProdutoNaoPossuiEstoque_DeveRetornarFalso()
        {
            //Arrange 
            var produto = _produtoFixture.GerarProdutoComEstoqueValido();
            //Act
            var result = produto.PossuiEstoque(11);
            //Assert
            Assert.False(result);
        }

        [Fact(DisplayName = "Produto possui estoque")]
        public void Produto_ProdutoPossuiEstoque_DeveRetornarVerdade()
        {
            //Arrange 
            var produto = _produtoFixture.GerarProdutoComEstoqueValido();
            //Act
            var result = produto.PossuiEstoque(5);
            //Assert
            Assert.True(result);
        }

        [Fact(DisplayName = "Produto atingiu a quantidade mínima do estoque")]
        public void Produto_ProdutoAtingiuQuantidadeEstoqueMinima_DeveRetornarVerdade()
        {
            //Arrange 
            var produto = _produtoFixture.GerarProdutoComEstoqueValido();

            //Act
            produto.DebitarEstoque(6);

            //Assert
            Assert.True(produto.EstoqueEstaEmQuantidadeMinima());
        }

        [Fact(DisplayName = "Produto não atingiu a quantidade mínima do estoque")]
        public void Produto_ProdutoNaoAtingiuQuantidadeEstoqueMinima_DeveRetornarFalso()
        {
            //Arrange 
            var produto = _produtoFixture.GerarProdutoComEstoqueValido();

            //Act
            produto.DebitarEstoque(4);

            //Assert
            Assert.False(produto.EstoqueEstaEmQuantidadeMinima());
        }
    }
}
