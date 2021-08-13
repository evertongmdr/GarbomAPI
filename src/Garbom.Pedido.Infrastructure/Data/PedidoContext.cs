using Garbom.Core.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Garbom.Pedido.Infrastructure.Data
{
    public class PedidoContext : DbContext, IUnitOfWork
    {
        public PedidoContext(DbContextOptions options): base(options) {}

        protected override void OnModelCreating(ModelBuilder model)
        {
            model.ApplyConfigurationsFromAssembly(typeof(PedidoContext).Assembly);
        }

        public async Task<bool> Commit()
        {
            return await base.SaveChangesAsync() > 0;
        }
    }
}
