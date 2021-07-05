using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEngSoftII.Models
{
    public static class Estados
    {
        public const string Acre = "Acre";
        public const string Alagoas = "Alagoas";
        public const string Amapa = "Amapá";
        public const string Amazonas = "Amazonas";
        public const string Bahia = "Bahia";
        public const string Ceara = "Ceará";
        public const string DistritoFederal = "Distrito Federal";
        public const string EspiritoSanto = "Espírito Santo";
        public const string Goias = "Goiás";
        public const string Maranhao = "Maranhão";
        public const string MatoGrosso = "Mato Grosso";
        public const string MatoGrossoDoSul = "Mato Grosso do Sul";
        public const string MinasGerais = "Minas Gerais";
        public const string Para = "Pará";
        public const string Paraiba = "Paraíba";
        public const string Parana = "Paraná";
        public const string Pernambuco = "Pernambuco";
        public const string Paui = "Piauí";
        public const string RioDeJaneiro = "Rio de Janeiro";
        public const string RioGrandeDoNorte = "Rio Grande do Norte";
        public const string RioGrandeDoSul = "Rio Grande do Sul";
        public const string Rondonia = "Rondônia";
        public const string Roraima = "Roraima";
        public const string SantaCatarina = "Santa Catarina";
        public const string SaoPaulo = "São Paulo";
        public const string Sergipe = "Sergipe";
        public const string Tocantins = "Tocantins";

        public static List<string> GetListEstados()
        {
            return new List<string>
            {
                Acre,
                Alagoas,
                Amapa,
                Amazonas,
                Bahia,
                Ceara,
                DistritoFederal,
                EspiritoSanto,
                Goias,
                Maranhao,
                MatoGrosso,
                MatoGrossoDoSul,
                MinasGerais,
                Para,
                Paraiba,
                Parana,
                Pernambuco,
                Paui,
                RioDeJaneiro,
                RioGrandeDoNorte,
                RioGrandeDoSul,
                Rondonia,
                Roraima,
                SantaCatarina,
                SaoPaulo,
                Sergipe,
                Tocantins
            };
        }
    }
}