using Garbom.Catalogo.Domain.Models;
using Garbom.Core.Domain.Interfaces.Objects;
using Garbom.Core.Infrastructure.Data.DatabaseFunctionMapping;
using Microsoft.EntityFrameworkCore;
using System;
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

            var categoria = new Categoria(Guid.Parse("54c11c4a-62e1-488f-a928-fc5b88679fdd"), "Doces", Guid.Parse("0cdd840e-8b1f-4bdb-bd77-b0881ceb04df"));
            modelBuilder.Entity<Categoria>().HasData(new[] { categoria });

            var unidadeMedida = new UnidadeMedida(Guid.Parse("54c11c4a-62e1-488f-a928-fc5b88679fdd"), "Unidade", Guid.Parse("995182c7-c02f-4d10-b409-0f5bb7b231b9"));
            modelBuilder.Entity<UnidadeMedida>().HasData(new[] { unidadeMedida });

            var produto = new Produto(Guid.Parse("54c11c4a-62e1-488f-a928-fc5b88679fdd"), Guid.Parse("0cdd840e-8b1f-4bdb-bd77-b0881ceb04df"), Guid.Parse("995182c7-c02f-4d10-b409-0f5bb7b231b9"), 10, "Bombom", "Bombom da Nestle", 5, false, true, null, Guid.Parse("fd48798c-c675-4ec5-8ca6-ecb3ff358282"));
            modelBuilder.Entity<Produto>().HasData(new[] { produto });
        }
        public async Task<bool> Commit()
        {
            return await base.SaveChangesAsync() > 0;
        }
    }
}
