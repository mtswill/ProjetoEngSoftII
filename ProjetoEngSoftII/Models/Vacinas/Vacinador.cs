using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEngSoftII.Models.Vacinas
{
    [Table("vacinador")]
    public class Vacinador
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string RegistroProfissional { get; set; }
    }
}
