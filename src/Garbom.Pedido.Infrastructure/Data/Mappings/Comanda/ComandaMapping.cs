using Garbom.Core.Infrastructure.Data.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Garbom.Pedido.Infrastructure.Data.Mappings.Comanda
{
    public class ComandaMapping : IEntityTypeConfiguration<Domain.Models.Comanda>
    {
       
        public void Configure(EntityTypeBuilder<Domain.Models.Comanda> builder)
        {
            EntityMapping<Domain.Models.Comanda>.Configure(builder);

            builder.Property(c => c.ValorTotal).HasPrecision(8, 2);

            builder.Property(c => c.Codigo)
                .HasDefaultValueSql("NEXT VALUE FOR comanda.CodigoComanda");
            

        }
    }
}
