using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace Garbom.Core.Helps.Objects
{
    public class ListaPaginadaDinamica : List<dynamic>
    {
        public int PaginaAtual { get; set; }
        public int TotalPaginas { get; set; }
        public int TamanhoPagina { get; set; }
        public int QuantidadeTotal { get; set; }
        public bool TemAnterior => (PaginaAtual > 1);
        public bool TemProxima => (PaginaAtual < TotalPaginas);

        public ListaPaginadaDinamica(List<dynamic> items, int quantidadeTotal, int paginaAtual, int tamanhoPagina)
        {
            QuantidadeTotal = quantidadeTotal;
            PaginaAtual = paginaAtual;
            TamanhoPagina = tamanhoPagina;
            TotalPaginas = (int)Math.Ceiling(quantidadeTotal / (double)tamanhoPagina);
            AddRange(items);
        }
        public static async Task<ListaPaginadaDinamica> CriarDinamico(IQueryable<object> source, int numeroPagina, int tamanhoPagina)
        {
            var quantidade = source.Count();
            var items = await source.Skip((numeroPagina - 1) * tamanhoPagina).Take(tamanhoPagina).ToDynamicListAsync();
            return new ListaPaginadaDinamica(items, quantidade, numeroPagina, tamanhoPagina);
        }
    }
}
