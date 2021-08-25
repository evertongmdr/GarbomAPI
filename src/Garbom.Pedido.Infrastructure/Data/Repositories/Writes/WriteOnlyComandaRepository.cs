using Garbom.Core.Infrastructure.Data.Repository;
using Garbom.Pedido.Domain.Interfaces.Repositories;
using Garbom.Pedido.Domain.Models;

namespace Garbom.Pedido.Infrastructure.Data.Repositories
{
    public class WriteOnlyComandaRepository : WriteOnlyRepository<Comanda>, IWriteOnlyComandaRepository
    {
        public WriteOnlyComandaRepository(PedidoContext context) : base(context)
        {
        }

        public void AdicionarPedido(Domain.Models.Pedido pedido)
        {
            _context.Set<Domain.Models.Pedido>().Add(pedido);
        }

        public void AtualizarMesa(Mesa mesaAntiga, Mesa mesaNova)
        {
            _context.Entry(mesaAntiga).CurrentValues.SetValues(mesaNova);
        }
    }
}
