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
        public string Marca { get; set; }
        public string Tipo { get; set; }
        public int DiasParaSegundaDose { get; set; }
    }
}
