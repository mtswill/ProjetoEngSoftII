using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEngSoftII.Models
{
    [Table("vacinas_aplicadas")]
    public class VacinasAplicadas
    {
        public CarteiraVacinacao CarteiraVacinacao { get; set; }
        public Vacina Vacina { get; set; }
    }
}
