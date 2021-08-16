using Garbom.Catalogo.Application.AppServices;
using Garbom.Catalogo.Application.Interfaces;
using Garbom.Catalogo.Domain.Interfaces.Repositories;
using Garbom.Catalogo.Infrastructure.Data;
using Garbom.Catalogo.Infrastructure.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Garbom.API.Configuration
{
    public static class DependencyInjectionConfig
    {

        public static void RegisterServices(this IServiceCollection services)
        {

            // Catalogo

            //Data
            services.AddScoped<CatalogoContext>();
            services.AddScoped<IReadOnlyProdutoRepository, ReadOnlyProdutoRepository>();
            services.AddScoped<IWriteOnlyProdutoRepository, WriteOnlyProdutoRepository>();

            //Application
            services.AddScoped<IProdutoAppService, ProdutoAppService>();
        }

    }
}
