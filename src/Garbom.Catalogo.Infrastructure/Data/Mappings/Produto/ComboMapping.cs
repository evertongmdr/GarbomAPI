using Garbom.Catalogo.Domain.Models;
using Garbom.Core.Infrastructure.Data.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Garbom.Catalogo.Infrastructure.Data.Mappings
{
    public class ComboMapping : IEntityTypeConfiguration<Combo>
    {
        public void Configure(EntityTypeBuilder<Combo> builder)
        {
            EntityMapping<Combo>.Configure(builder);

            builder.Property(c =>c.Nome).IsRequired().HasMaxLength(128);
        }
    }
}
