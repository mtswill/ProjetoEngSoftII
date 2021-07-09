using ProjetoEngSoftII.Models.Vacinas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEngSoftII.Models.ViewModels
{
    public class InserirVacinadoViewModel
    {
        public InserirVacinadoViewModel()
        {
        }

        public InserirVacinadoViewModel(ICollection<MarcaVacinaCovid> marcasVacinaCovid)
        {
            MarcasVacinaCovid = marcasVacinaCovid;
        }

        public Vacinado Vacinado { get; set; }
        public ICollection<MarcaVacinaCovid> MarcasVacinaCovid { get; set; }
    }
}
