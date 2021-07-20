using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEngSoftII.Helpers
{
    public static class ProjectHelper
    {
        public static string RemovePontoEHifem(this string obj)
            => obj.Replace(".", string.Empty).Replace("-", string.Empty);

        public static string InserePontoEHifemCpf(this string obj)
        {
            var primeiraParte = obj.Substring(0, 3);
            var segundaParte = obj.Substring(4, 3);
            var terceiraParte = obj.Substring(7, 3);
            var quartaParte = obj.Substring(9);

            return $"{primeiraParte}.{segundaParte}.{terceiraParte}-{quartaParte}";
        }
        
        public static string InserePontoEHifemRg(this string obj)
        {
            var primeiraParte = obj.Substring(0, 2);
            var segundaParte = obj.Substring(2, 3);
            var terceiraParte = obj.Substring(5, 3);
            var quartaParte = obj.Substring(8);

            return $"{primeiraParte}.{segundaParte}.{terceiraParte}-{quartaParte}";
        }
    }
}
