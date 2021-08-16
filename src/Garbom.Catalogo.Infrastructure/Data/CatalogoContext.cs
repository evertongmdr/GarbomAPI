using Garbom.Catalogo.Domain.Models;
using Garbom.Core.Domain.Interfaces;
using Garbom.Core.Infrastructure.Data.DatabaseFunctionMapping;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Garbom.Catalogo.Infrastructure.Data
{
    public class CatalogoContext : DbContext, IUnitOfWork
    {
        public CatalogoContext(DbContextOptions<CatalogoContext> options) : base(options) { }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<UnidadeMedida> UnidadeMedidas { get; set; }
        public DbSet<Marca> Marcas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            GarbomFuncoesBanco.RegistarFuncoes(modelBuilder);

            //Pega as propriedade do tipo string que não teve configuração no tipo.
            var properties = modelBuilder.Model.GetEntityTypes().SelectMany(p => p.GetProperties())
                .Where(p => p.ClrType == typeof(string) && p.GetColumnType() == null);

            foreach (var property in properties)
            {
                property.SetIsUnicode(false);
            }

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CatalogoContext).Assembly);
        }
        public async Task<bool> Commit()
        {
            return await base.SaveChangesAsync() > 0;
        }
    }
}
