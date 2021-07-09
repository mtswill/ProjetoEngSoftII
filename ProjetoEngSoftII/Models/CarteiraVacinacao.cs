using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoEngSoftII.Models
{
    [Table("carteira_vacinacao")]
    public class CarteiraVacinacao : BaseEntity
    {
        public Paciente Paciente { get; set; }
    }
}