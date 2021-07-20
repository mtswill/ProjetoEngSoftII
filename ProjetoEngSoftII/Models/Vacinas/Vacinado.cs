using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEngSoftII.Models.Vacinas
{
    [Table("vacinado")]
    public class Vacinado : BaseEntity
    {
        [ForeignKey("paciente_cpf")]
        [Display(Name = "CPF do paciente")]
        public string PacienteCpf { get; set; }

        [Display(Name = "Data da vacinação")]
        public DateTime DataVacinacao { get; set; }

        [Display(Name = "Data de previsão da segunda dose")]
        public DateTime DataPrevisaoSegundaDose { get; set; }

        [ForeignKey("marca_vacina_covid_id")]
        public long MarcaVacinaCovidId { get; set; }

        public string Dose { get; set; }

        public string Unidade { get; set; }

        public string Lote { get; set; }

        [ForeignKey("VacinadorRegistroProfissional")]
        [Display(Name = "Registro profissional do vacinador")]
        public long VacinadorRegistroProfissional { get; set; }

        //Classes externas
        [Display(Name = "Marca da Vacina")]
        public MarcaVacinaCovid MarcaVacinaCovid { get; set; }

        [Display(Name = "Paciente")]
        public Paciente Paciente { get; set; }

        [Display(Name = "Vacinador")]
        public Vacinador Vacinador { get; set; }
    }
}
