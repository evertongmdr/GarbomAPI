using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Garbom.Core.Infrastructure.Data.DatabaseFunctionMapping
{
    public static class GarbomFuncoesBanco
    {
        [DbFunction(name: "LEFT", IsBuiltIn = true)]
        public static string Left(string dados, int quantidade)
        {
            throw new NotImplementedException();
        }
        public static void RegistarFuncoes(ModelBuilder modelBuilder)
        {
            //Reflexão traz todo os métodos que tem o atributo  DbFunctionAttribute
            var funcoes = typeof(GarbomFuncoesBanco).GetMethods().Where(p => Attribute.IsDefined(p, typeof(DbFunctionAttribute)));

            //faz a mapeação da funções incorporadas  do banco de dado
            foreach (var funcao in funcoes)
            {
                modelBuilder.HasDbFunction(funcao);
            }
        }
    }
}
