using Garbom.Catalogo.Domain.Models;
using Garbom.Core.Infrastructure.Data.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Garbom.Catalogo.Infrastructure.Data.Mappings
{
    public class MarcaMapping : IEntityTypeConfiguration<Marca>
    {
        public void Configure(EntityTypeBuilder<Marca> builder)
        {
            EntityMapping<Marca>.Configure(builder);

            builder.Property(m => m.Nome).IsRequired().HasMaxLength(128);
        }
    }
}
