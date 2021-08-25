using Garbom.Core.Domain.Interfaces.Objects;
using Garbom.Pedido.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Garbom.Pedido.Infrastructure.Data
{
    public class PedidoContext : DbContext, IUnitOfWork
    {
        public PedidoContext(DbContextOptions options) : base(options) { }
        public DbSet<Comanda> Comandas { get; set; }
        public DbSet<Domain.Models.Pedido> Pedidos { get; set; }
        public DbSet<PedidoItem> PedidoItens { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Mesa> Mesas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigurarSequencias(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PedidoContext).Assembly);

            //Pega as propriedade do tipo string que não teve configuração no tipo.
            var properties = modelBuilder.Model.GetEntityTypes().SelectMany(p => p.GetProperties())
                .Where(p => p.ClrType == typeof(string) && p.GetColumnType() == null);

            foreach (var property in properties)
            {
                property.SetIsUnicode(false);
            }




        }
        public void ConfigurarSequencias(ModelBuilder modelBuilder)
        {

            modelBuilder.HasSequence<long>("CodigoComanda", "comanda")
               .StartsAt(0)
               .IncrementsBy(1);

            modelBuilder.HasSequence<long>("CodigoPedido", "pedido")
                .StartsAt(0)
                .IncrementsBy(1);
        }

        public async Task<bool> Commit()
        {
            return await base.SaveChangesAsync() > 0;
        }
    }
}
