using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEngSoftII.Models.Vacinas
{
    [Table("vacinador")]
    public class Vacinador
    {
        [Display(Name = "Registro profissional")]
        public long RegistroProfissional { get; set; }

        public string Nome { get; set; }
    }
}
