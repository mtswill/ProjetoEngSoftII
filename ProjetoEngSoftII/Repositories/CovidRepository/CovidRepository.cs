using ProjetoEngSoftII.Data;
using ProjetoEngSoftII.Models.Vacinas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEngSoftII.Repositories.CovidRepository
{
    public class CovidRepository : ICovidRepository
    {
        private readonly ProjectContext _context;

        public CovidRepository(ProjectContext context)
        {
            _context = context;
        }

        public List<MarcaVacinaCovid> GetAllMarcasVacinaCovid()
            => _context.MarcaVacinaCovid.ToList();

        public MarcaVacinaCovid GetMarcaVacinaCovidById(long id)
            => _context.MarcaVacinaCovid.FirstOrDefault(mv => mv.Id.Equals(id));

        public MarcaVacinaCovid GetMarcaVacinaCovidByMarca(string nome)
            => _context.MarcaVacinaCovid.FirstOrDefault(mv => mv.Marca.Contains(nome));
    }
}
