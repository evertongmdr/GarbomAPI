using Garbom.Pedido.Domain.Models;
using System;

namespace Garbom.Pedido.Application.DTOS
{
    public class PedidoDTO
    {
        public Guid FuncionarioId { get; set; }
        public Guid ComandaId { get; set; }
        public string NomeFuncionario { get; set; }
        public long Codigo { get; set; }
        public DateTime DataCadastro { get; set; }
        public EStatusPedido StatusPedido { get; set; }
        public decimal ValorTotal { get; set; }
    }
}
