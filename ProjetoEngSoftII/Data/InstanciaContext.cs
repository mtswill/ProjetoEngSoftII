using ProjetoEngSoftII.Repositories.CovidRepository;
using ProjetoEngSoftII.Repositories.PacienteRespository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEngSoftII.Data
{
    public class InstanciaContext
    {
        protected readonly ICovidRepository covidRepository;
        protected readonly IPacienteRepository pacienteRepository;

        public InstanciaContext(CovidRepository covidRepository, PacienteRepository pacienteRepository)
        {
            this.covidRepository = covidRepository;
            this.pacienteRepository = pacienteRepository;
        }
    }
}
