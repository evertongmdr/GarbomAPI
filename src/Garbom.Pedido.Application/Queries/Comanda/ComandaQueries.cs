using AutoMapper;
using Garbom.Pedido.Application.DTOS;
using Garbom.Pedido.Domain.Interfaces.Repositories;
using Garbom.Pedido.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garbom.Pedido.Application.Queries
{
    public class ComandaQueries : IComandaQueries
    {
        private readonly IMapper _mapper;
        private readonly IReadOnlyComandaRepository _readOnlyComandaRepository;

        public ComandaQueries(IMapper mapper, IReadOnlyComandaRepository readOnlyComandaRepository)
        {
            _mapper = mapper;
            _readOnlyComandaRepository = readOnlyComandaRepository;
        }
        public async Task<ICollection<ComandaDTO>> ObterComandaAbertas()
        {
            var comandasAberta = await _readOnlyComandaRepository
                .ObterTodos<Comanda>(c => c.StatusComanda == EStatusComanda.Aberta, null, true);

            return comandasAberta.Select(ca => _mapper.Map<ComandaDTO>(ca)).ToList();
        }
    }
}
