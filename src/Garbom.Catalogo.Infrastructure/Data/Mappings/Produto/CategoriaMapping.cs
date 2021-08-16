using Garbom.Catalogo.Domain.Models;
using Garbom.Core.Infrastructure.Data.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Garbom.Catalogo.Infrastructure.Data.Mappings
{
    public class CategoriaMapping : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            EntityMapping<Categoria>.Configure(builder);

            builder.Property(x => x.Nome).IsRequired().HasMaxLength(128);
        }
    }
}
