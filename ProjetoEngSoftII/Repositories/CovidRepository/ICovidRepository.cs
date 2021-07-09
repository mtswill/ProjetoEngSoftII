using ProjetoEngSoftII.Models.Vacinas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEngSoftII.Repositories.CovidRepository
{
    public interface ICovidRepository
    {
        List<MarcaVacinaCovid> GetAllMarcasVacinaCovid();
        MarcaVacinaCovid GetMarcaVacinaCovidById(long id);
        MarcaVacinaCovid GetMarcaVacinaCovidByMarca(string nome);
        public Vacinado InserirVacinado(Vacinado vacinado);
    }
}
