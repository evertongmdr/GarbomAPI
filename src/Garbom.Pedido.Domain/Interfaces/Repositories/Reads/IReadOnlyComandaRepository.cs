using Garbom.Core.Domain.Interfaces.Objects;
using Garbom.Core.Domain.Objects;
using Garbom.Pedido.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Garbom.Pedido.Domain.Interfaces.Repositories
{
    public interface IReadOnlyComandaRepository : IReadOnlyRepository<Comanda>
    {
    }
}
