using System;
using Xunit;

namespace Garbom.Catalogo.Domain.Tests.Produto
{
    [CollectionDefinition(nameof(ProdutoCollection))]
    public class ProdutoCollection : ICollectionFixture<ProdutoFixture> { }
    public class ProdutoFixture : IDisposable
    {
        public Domain.Models.Produto GerarProdutoComEstoqueValido()
        {
            var produto = new Domain.Models.Produto(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(),
                1, "Coca-Cola Lata 300ml", "Refrigerante com 300ml", 7, true, true, Guid.NewGuid());
            produto.AtribuirQuantidadeEstoque(10);
            produto.AtribuirQuantidadeEstoqueMinima(5);

            return produto;

        }
        public void Dispose()
        {

        }
    }
}
