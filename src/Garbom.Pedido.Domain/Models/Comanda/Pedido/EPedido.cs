using System.ComponentModel;

namespace Garbom.Pedido.Domain.Models
{
    public enum EStatusPedido
    {
        [Description("Iniciado")]
        Iniciado = 1,
        [Description("Entregue")]
        Entregue = 3,
        [Description("Cancelado")]
        Cancelado = 6
    }
}
