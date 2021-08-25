using Garbom.Core.Domain.Interfaces.Objects;
using Garbom.Pedido.Domain.Models;

namespace Garbom.Pedido.Domain.Interfaces.Repositories
{
    public interface IWriteOnlyComandaRepository : IWriteOnlyRepository<Comanda>
    {
        void AtualizarMesa(Mesa mesaVelha, Mesa mesaNova);
        void AdicionarPedido(Domain.Models.Pedido pedido);
    }
}
