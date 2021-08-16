using Garbom.Catalogo.Domain.Models;
using Garbom.Core.Infrastructure.Data.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Garbom.Catalogo.Infrastructure.Data.Mappings
{
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            EntityMapping<Produto>.Configure(builder);

            builder.Property(p => p.Nome).IsRequired().HasMaxLength(128);

            builder.Property(p => p.Descricao).HasMaxLength(256);

            builder.Property(p => p.Valor).HasPrecision(8, 2);

            builder.HasIndex(p => p.Codigo).IsUnique();

            builder.ToTable("Produtos");
        }
    }
}
