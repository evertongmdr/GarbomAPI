using Garbom.Pedido.Domain.Models;
using System;
using System.Collections.Generic;

namespace Garbom.Pedido.Application.DTOS
{
    public class ComandaDTO
    {
        public Guid MesaId { get; set; }
        public long Codigo { get; set; }
        public DateTime DataAbertura { get; set; }
        public DateTime DataFechamento { get; set; }
        public EStatusComanda StatusComanda { get; set; }
        public decimal ValorTotal { get; set; }
        public List<PedidoDTO> Pedidos { get; set; }

        public ComandaDTO()
        {

        }
    }
}
