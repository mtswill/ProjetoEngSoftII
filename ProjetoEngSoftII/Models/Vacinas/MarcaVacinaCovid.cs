using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEngSoftII.Models.Vacinas
{
    [Table("marca_vacina_covid")]
    public class MarcaVacinaCovid : BaseEntity
    {
        [Column("marca")]
        public string Marca { get; set; }

        [Column("tipo")]
        public string Tipo { get; set; }
    }
}
