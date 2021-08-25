using Garbom.Core.Domain.Objects;

namespace Garbom.Catalogo.Domain.Models
{
    public class ProdutoRecursoParametro : RecursoParametro
    {
        public int? Codigo { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public int? QuantidadeEstoque { get; set; }
        public bool Ativo { get; set; }
    }

    /*
    public class ProdutoFilterProduto { }
    */


}
