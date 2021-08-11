using Garbom.Core.Domain.Objects;

namespace Garbom.Pedido.Domain.Models
{
    public class Mesa : Entity
    {
        public int Numero { get; private set; }
        public string Descricao { get; private set; }
        public EStatusMesa StatusMesa { get; private set; }
        public override bool EhValido()
        {
            // TODO
            return true;
        }
    }
}
