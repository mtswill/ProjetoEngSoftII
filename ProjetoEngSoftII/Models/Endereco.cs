using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoEngSoftII.Models
{
    [Table("endereco")]
    public class Endereco
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

        [Column("estado")]
        public UF Estado { get; set; }
    }

    public enum UF
    {
        RO,
        AC,
        AM,
        RR,
        AP,
        TO,
        MA,
        PI,
        CE,
        RN,
        PB,
        PE,
        AL,
        SE,
        BA,
        MG,
        ES,
        RJ,
        SP,
        PR,
        SC,
        RS,
        MS,
        MT,
        GO,
        DF
    }
}