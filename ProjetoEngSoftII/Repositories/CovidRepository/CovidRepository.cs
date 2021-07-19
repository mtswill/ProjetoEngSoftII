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
            if (_context.Vacinador.Any(v => v.RegistroProfissional.Equals(vacinador.RegistroProfissional)))
                return vacinador;

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
        
        public Vacinador UpdateVacinador(Vacinador vacinador)
        {
            var result = _context.Vacinador.SingleOrDefault(v => v.RegistroProfissional.Equals(vacinador.RegistroProfissional));

            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(vacinador);
                    _context.SaveChanges();
                    return result;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                return null;
            }
        }

        public void RemoverVacinador(string registroProfissional)
        {
            var result = _context.Vacinador.SingleOrDefault(v => v.RegistroProfissional.Equals(registroProfissional));

            if (result != null)
            {
                try
                {
                    _context.Vacinador.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public List<MarcaVacinaCovid> GetAllMarcasVacinaCovid()
            => _context.MarcaVacinaCovid.ToList();

        public MarcaVacinaCovid GetMarcaVacinaCovidById(long id)
            => _context.MarcaVacinaCovid.FirstOrDefault(mv => mv.Id.Equals(id));

        public MarcaVacinaCovid GetMarcaVacinaCovidByMarca(string nome)
            => _context.MarcaVacinaCovid.FirstOrDefault(mv => mv.Marca.Contains(nome));

        public List<Vacinador> GetAllVacinadores()
            => _context.Vacinador.ToList();
        
        public Vacinador GetVacinadorByRegistro(string registroProfissional)
            => _context.Vacinador.FirstOrDefault(v => v.RegistroProfissional.Equals(registroProfissional));
    }
}
