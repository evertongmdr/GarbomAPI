using Garbom.Core.Infrastructure.Data.Mapping;
using Garbom.Pedido.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Garbom.Pedido.Infrastructure.Data.Mappings.Comanda
{
    public class PedidoItemMapping : IEntityTypeConfiguration<PedidoItem>
    {
        public void Configure(EntityTypeBuilder<PedidoItem> builder)
        {
            EntityMapping<PedidoItem>.Configure(builder);
        }
    }
}
