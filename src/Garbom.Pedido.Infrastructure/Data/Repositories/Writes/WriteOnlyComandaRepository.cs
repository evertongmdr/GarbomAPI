using Garbom.Core.Infrastructure.Data.Repository;
using Garbom.Pedido.Domain.Interfaces.Repositories;
using Garbom.Pedido.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Garbom.Pedido.Infrastructure.Data.Repositories
{
    public class WriteOnlyComandaRepository : WriteOnlyRepository<Comanda>, IWriteOnlyComandaRepository
    {
        public WriteOnlyComandaRepository(DbContext context) : base(context)
        {
        }
    }
}
