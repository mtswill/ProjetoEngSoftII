using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoEngSoftII.Models
{
    [Table("vacina")]
    public class Vacina : BaseEntity
    {
        [Column("nome")]
        public string Nome { get; set; }

        [Column("descricao")]
        public string Descricao { get; set; }
    }
}