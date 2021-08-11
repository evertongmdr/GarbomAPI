using Garbom.Catalogo.Domain.Models;
using Garbom.Core.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Garbom.Catalogo.Infrastructure.Data
{
    public class CatalogoContext : DbContext, IUnitOfWork
    {
        protected CatalogoContext(DbContextOptions<CatalogoContext> options) : base(options){}
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<UnidadeMedida> UnidadeMedidas { get; set; }
        public DbSet<Marca> Marcas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CatalogoContext).Assembly);
        }
        public async Task<bool> Commit()
        {
            return await base.SaveChangesAsync() > 0;
        }
    }
}
