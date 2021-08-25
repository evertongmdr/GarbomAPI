using Garbom.Core.Domain.Objects;

namespace Garbom.Pedido.Domain.Models
{
    public class Mesa : Entity
    {
        public int Codigo { get; private set; }
        public string Descricao { get; private set; }
        public EStatusMesa StatusMesa { get; private set; }


        //EF Rel.
        protected Mesa() { }

        public void MesaDisponivel() => StatusMesa = EStatusMesa.Disponivel;
        public void MesaReservada() => StatusMesa = EStatusMesa.Reservada;
        public void MesaOcupada() => StatusMesa = EStatusMesa.Ocupada;

        public override bool EhValido()
        {
            throw new DomainException("Nao implementado");
        }

    }
}
