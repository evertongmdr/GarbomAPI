using Garbom.Core.Application.Objects;
using System;

namespace Garbom.Catalogo.Application.DTOS
{
    public class ProdutoDTO : DTO
    {
        public Guid CategoriaId { get;  set; }
        public Guid UnidadeMedidaId { get;  set; }
        public Guid? MarcaId { get;  set; }
        public int Codigo { get;  set; }
        public string Nome { get;  set; }
        public string Descricao { get;  set; }
        public decimal Valor { get;  set; }
        public int QuantidadeEstoque { get;  set; }
        public bool Ativo { get;  set; }
    }
}
