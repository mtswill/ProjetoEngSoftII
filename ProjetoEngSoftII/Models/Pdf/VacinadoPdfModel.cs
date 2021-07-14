using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEngSoftII.Models.Pdf
{
    public class VacinadoPdfModel
    {
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string Dose { get; set; }
        public string MarcaVacina { get; set; }
        public DateTime DataVacinacao { get; set; }
        public DateTime DataRetorno { get; set; }
    }
}
