using Garbom.Pedido.Application.DTOS;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Garbom.Pedido.Application.Queries
{
    public interface IComandaQueries
    {
        Task<ICollection<ComandaDTO>> ObterComandaAbertas();

    }
}
