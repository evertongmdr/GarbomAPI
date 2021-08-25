using Garbom.Core.Domain.Objects;
using System;
using System.Collections.Generic;

namespace Garbom.Pedido.Domain.Models
{
    public class Comanda : Entity, IAggregateRoot
    {
        public Guid MesaId { get; private set; }
        public long Codigo { get; private set; }
        public DateTime DataAbertura { get; private set; }
        public DateTime DataFechamento { get; private set; }
        public EStatusComanda StatusComanda { get; private set; }
        public decimal ValorTotal { get; private set; }

        private readonly List<Pedido> _pedidos;
        public IReadOnlyCollection<Pedido> Pedidos => _pedidos;

        //EF Rel.
        protected Comanda()
        {
            _pedidos = new List<Pedido>();
        }
        public Mesa Mesa { get; private set; }

        public Comanda(Guid empresaId, Guid mesaId, DateTime dataAbertura, EStatusComanda statusComanda, decimal valorTotal, IList<Pedido> pedidos = null, Guid? id = null) : base(empresaId, id)
        {
            MesaId = mesaId;
            DataAbertura = dataAbertura;
            StatusComanda = statusComanda;
            ValorTotal = valorTotal;

            pedidos = pedidos == null ? new List<Pedido>() : pedidos;

        }

        public override bool EhValido()
        {
            ValidationResult = new ComandaValidator().Validate(this);

            return ValidationResult.IsValid;
        }

        public static class ComandaFactory
        {
            public static Comanda NovaComanda(Guid empresaId, Guid mesaId)
            {
                var comanda = new Comanda
                {
                    MesaId = mesaId,
                    DataAbertura = DateTime.Now,
                    StatusComanda = EStatusComanda.Aberta,
                    ValorTotal = 0
                };
                comanda.AtribuirEmpresaId(empresaId);

                return comanda;
            }
        }
    }


}
