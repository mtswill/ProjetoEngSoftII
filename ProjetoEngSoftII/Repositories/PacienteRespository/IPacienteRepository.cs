using ProjetoEngSoftII.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEngSoftII.Repositories.PacienteRespository
{
    public interface IPacienteRepository
    {
        Paciente Create(Paciente paciente);
        List<Paciente> FindAll();
        Paciente FindByCpf(string cpf);
        Paciente Update(Paciente paciente);
        void Delete(string cpf);
        bool Exists(string cpf);
    }
}
