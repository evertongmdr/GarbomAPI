using Garbom.Core.Infrastructure.Data.Mapping;
using Garbom.Pedido.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Garbom.Pedido.Infrastructure.Data.Mappings.Comanda
{
    public class MesaMapping : IEntityTypeConfiguration<Mesa>
    {
        public void Configure(EntityTypeBuilder<Mesa> builder)
        {
            EntityMapping<Mesa>.Configure(builder);

            builder.HasIndex(m => new { m.EmpresaId, m.Codigo }).IsUnique();

            builder.Property(m => m.Descricao).HasMaxLength(128);
        }
    }
}
