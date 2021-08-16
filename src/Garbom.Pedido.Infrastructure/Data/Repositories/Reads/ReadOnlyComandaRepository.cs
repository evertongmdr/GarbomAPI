using Garbom.Core.Infrastructure.Data.Repository;
using Garbom.Pedido.Domain.Interfaces.Repositories;
using Garbom.Pedido.Domain.Models;

namespace Garbom.Pedido.Infrastructure.Data.Repositories
{
    public class ReadOnlyComandaRepository : ReadOnlyRepository<Comanda>, IReadOnlyComandaRepository
    {
        public ReadOnlyComandaRepository(PedidoContext context) : base(context) {}
    }
}
