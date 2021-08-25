using System.ComponentModel;

namespace Garbom.Pedido.Domain.Models
{
    public enum EStatusMesa
    {
        [Description("Disponível")]
        Disponivel = 1,
        [Description("Reservada")]
        Reservada = 3,
        [Description("Ocupada")]
        Ocupada = 6,
    }
}
