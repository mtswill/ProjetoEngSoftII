using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEngSoftII.Models.Pdf
{
    public class VacinadoPdfModel
    {
        public VacinadoPdfModel(string cpf, string nome, string dose, string marcaVacina, string unidade, string vacinador, string lote, string registroProfissional, string cnes, DateTime dataVacinacao, DateTime? dataRetorno)
        {
            Cpf = cpf;
            Nome = nome;
            Dose = dose;
            MarcaVacina = marcaVacina;
            Unidade = unidade;
            Vacinador = vacinador;
            Lote = lote;
            RegistroProfissional = registroProfissional;
            Cnes = cnes;
            DataVacinacao = dataVacinacao;
            DataRetorno = dataRetorno;
        }

        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string Dose { get; set; }
        public string MarcaVacina { get; set; }
        public string Unidade { get; set; }
        public string Vacinador { get; set; }
        public string Lote { get; set; }
        public string Cnes { get; set; }
        public string RegistroProfissional { get; set; }
        public DateTime DataVacinacao { get; set; }
        public DateTime? DataRetorno { get; set; }
    }
}
