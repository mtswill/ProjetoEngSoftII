using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoEngSoftII.Models
{
    [Table("carteira_vacinacao")]
    public class CarteiraVacinacao
    {
        [Column("id")]
        public int Id { get; set; }

        public List<Vacina> Vacinas { get; set; }
    }
}