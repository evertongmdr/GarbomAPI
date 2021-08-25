using Garbom.Core.Domain.Objects;
using Garbom.Core.Infrastructure.Data.Repository;
using Garbom.Pedido.Domain.Interfaces.Repositories;
using Garbom.Pedido.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Garbom.Pedido.Infrastructure.Data.Repositories
{
    public class ReadOnlyComandaRepository : ReadOnlyRepository<Comanda>, IReadOnlyComandaRepository
    {
        public ReadOnlyComandaRepository(PedidoContext context) : base(context) { }
    }
}
