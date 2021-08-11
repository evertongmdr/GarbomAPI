using System.ComponentModel;

namespace Garbom.Pedido.Domain.Models
{
    public enum EStatusComanda
    {
        [Description("Aberta")]
        Aberta = 1,
        [Description("Cancelada")]
        Cancelada = 3,
        [Description("Fechada")]
        Fechada = 6
    }
}
