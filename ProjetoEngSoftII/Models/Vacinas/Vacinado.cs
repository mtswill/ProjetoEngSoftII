using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEngSoftII.Models.Vacinas
{
    public class Vacinado : BaseEntity
    {
        [ForeignKey("paciente_cpf")]
        public long PacienteCpf { get; set; }

        [Column("data_vacinacao")]
        public DateTime DataVacinacao { get; set; }

        [ForeignKey("marca_vacina_id")]
        public long MarcaVacinaId { get; set; }

        [Column("dose")]
        public string Dose { get; set; }

        //Classes externas
        [Display(Name = "Marca da Vacina")]
        public MarcaVacina MarcaVacina { get; set; }

        [Display(Name = "Paciente")]
        public Paciente Paciente { get; set; }
    }
}
