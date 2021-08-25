using Garbom.Core.Infrastructure.Data.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Garbom.Pedido.Infrastructure.Data.Mappings.Comanda
{
    public class PedidoMapping : IEntityTypeConfiguration<Domain.Models.Pedido>
    {
        public void Configure(EntityTypeBuilder<Domain.Models.Pedido> builder)
        {
            EntityMapping<Domain.Models.Pedido>.Configure(builder);

            builder.Property(p => p.NomeFuncionario)
                .IsRequired().HasMaxLength(128);

            //builder.Property(p => p.DataCadastro).IsRequired();

            builder.Property(p => p.ValorTotal).HasPrecision(8, 2);

            builder.Property(p => p.Codigo)
                .HasDefaultValueSql("NEXT VALUE FOR pedido.CodigoPedido");

        }
    }
}
