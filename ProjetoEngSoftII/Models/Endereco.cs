using ProjetoEngSoftII.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoEngSoftII.Models
{
    [Table("endereco")]
    public class Endereco : BaseEntity
    {
        [Column("cep")]
        public string Cep { get; set; }

        [Column("logradouro")]
        public string Logradouro { get; set; }

        [Column("bairro")]
        public string Bairro { get; set; }

        [Column("numero")]
        public string Numero { get; set; }

        [Column("cidade")]
        public string Cidade { get; set; }
        
        [Column("descricao")]
        public string Descricao { get; set; }

        [Column("estado")]
        public string Estado { get; set; }
    }

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
    }
}