using Garbom.Catalogo.Domain.Models;
using Garbom.Core.Infrastructure.Data.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Garbom.Catalogo.Infrastructure.Data.Mappings
{
    public class UnidadeMedidaMapping : IEntityTypeConfiguration<UnidadeMedida>
    {
        public void Configure(EntityTypeBuilder<UnidadeMedida> builder)
        {
            EntityMapping<UnidadeMedida>.Configure(builder);

            builder.Property(u => u.Nome).IsRequired().HasMaxLength(128);
        }
    }
}
