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
}