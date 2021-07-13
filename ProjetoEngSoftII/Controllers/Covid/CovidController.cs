using Microsoft.AspNetCore.Mvc;
using ProjetoEngSoftII.Models.Vacinas;
using ProjetoEngSoftII.Models.ViewModels;
using ProjetoEngSoftII.Repositories.CovidRepository;
using ProjetoEngSoftII.Repositories.PacienteRespository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEngSoftII.Controllers.Covid
{
    public class CovidController : Controller
    {
        private readonly CovidRepository _covidRepository;
        private readonly PacienteRepository _pacienteRepository;

        public CovidController(CovidRepository covidRepository, PacienteRepository pacienteRepository)
        {
            _covidRepository = covidRepository;
            _pacienteRepository = pacienteRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult VacinacaoIndex()
        {
            return View();
        }

        public IActionResult InserirVacinado()
        {
            var model = new InserirVacinadoViewModel(_covidRepository.GetAllMarcasVacinaCovid());
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult InserirVacinado(Vacinado vacinado)
        {
            if (ModelState.IsValid)
            {
                _covidRepository.InserirVacinado(vacinado);
                return RedirectToAction(nameof(Index));
            }

            var model = new InserirVacinadoViewModel(_covidRepository.GetAllMarcasVacinaCovid());
            return View(model);
        }

        public IActionResult LeitosIndex()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetInformacoesPaciente(string cpf)
        {
            return View();
        }
    }
}
