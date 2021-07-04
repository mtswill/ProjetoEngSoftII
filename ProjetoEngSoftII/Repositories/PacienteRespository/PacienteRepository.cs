using ProjetoEngSoftII.Data;
using ProjetoEngSoftII.Models;
using ProjetoEngSoftII.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEngSoftII.Repositories.PacienteRespository
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly ProjectContext _context;

        public PacienteRepository(ProjectContext context)
        {
            _context = context;
        }

        public Paciente Create(Paciente paciente)
        {
            throw new NotImplementedException();
        }

        public void Delete(string cpf)
        {
            throw new NotImplementedException();
        }

        public bool Exists(string cpf)
        {
            throw new NotImplementedException();
        }

        public List<Paciente> FindAll()
        {
            throw new NotImplementedException();
        }

        public Paciente FindByCpf(string cpf)
        {
            throw new NotImplementedException();
        }

        public Paciente Update(Paciente paciente)
        {
            throw new NotImplementedException();
        }
    }
}
