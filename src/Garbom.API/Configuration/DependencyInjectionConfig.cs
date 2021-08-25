using Garbom.Catalogo.Application.AppServices;
using Garbom.Catalogo.Application.Interfaces;
using Garbom.Catalogo.Domain.Interfaces.Repositories;
using Garbom.Catalogo.Domain.Interfaces.Services;
using Garbom.Catalogo.Domain.Services;
using Garbom.Catalogo.Infrastructure.Data;
using Garbom.Catalogo.Infrastructure.Data.Repositories;
using Garbom.Core.Domain.Messages.CommonMessages.Notifications;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System;
using Garbom.Pedido.Domain.Interfaces.Repositories;
using Garbom.Pedido.Infrastructure.Data.Repositories;
using Garbom.Core.Communication.Mediator;

namespace Garbom.API.Configuration
{
    public static class DependencyInjectionConfig
    {

        public static void RegisterServices(this IServiceCollection services)
        {

            #region Ferramentas

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddMediatR(typeof(Startup));
            #endregion

            #region Classes de Trabalho

            services.AddScoped<NotificationContext>();
            services.AddScoped<IMediatorHandler, MediatorHandler>();
            #endregion

            #region Contexto Catalogo

            //Context
            services.AddScoped<CatalogoContext>();

            //Repositories
            services.AddScoped<IReadOnlyProdutoRepository, ReadOnlyProdutoRepository>();
            services.AddScoped<IWriteOnlyProdutoRepository, WriteOnlyProdutoRepository>();

            //Domain Services
            services.AddScoped<IEstoqueService, EstoqueService>();

            //Application Serices
            services.AddScoped<IProdutoAppService, ProdutoAppService>();

            #endregion

            #region Contexto Pedido

            //Repositories
            services.AddScoped<IReadOnlyComandaRepository, ReadOnlyComandaRepository>();
            services.AddScoped<IWriteOnlyComandaRepository, WriteOnlyComandaRepository>();
            #endregion

        }

    }
}
