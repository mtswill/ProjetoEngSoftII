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

        public Vacinado InserirVacinado(Vacinado vacinado)
        {
            try
            {
                _context.Vacinado.Add(vacinado);
                _context.SaveChanges();

                return vacinado;
            }
            catch
            {
                throw;
            }
        }
        
        public Vacinador CadastrarVacinador(Vacinador vacinador)
        {
            try
            {
                _context.Vacinador.Add(vacinador);
                _context.SaveChanges();

                return vacinador;
            }
            catch
            {
                throw;
            }
        }

        public List<MarcaVacinaCovid> GetAllMarcasVacinaCovid()
            => _context.MarcaVacinaCovid.ToList();

        public MarcaVacinaCovid GetMarcaVacinaCovidById(long id)
            => _context.MarcaVacinaCovid.FirstOrDefault(mv => mv.Id.Equals(id));

        public MarcaVacinaCovid GetMarcaVacinaCovidByMarca(string nome)
            => _context.MarcaVacinaCovid.FirstOrDefault(mv => mv.Marca.Contains(nome));
    }
}
