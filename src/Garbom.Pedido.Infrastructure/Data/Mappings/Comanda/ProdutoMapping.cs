using Garbom.Core.Infrastructure.Data.Mapping;
using Garbom.Pedido.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Garbom.Pedido.Infrastructure.Data.Mappings.Comanda
{
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            EntityMapping<Produto>.Configure(builder);
        }
    }
}
