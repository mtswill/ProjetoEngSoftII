using Microsoft.AspNetCore.Mvc;
using ProjetoEngSoftII.Helpers;
using ProjetoEngSoftII.Models;
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
        public IActionResult CadastrarVacinador()
        {
            return View();
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
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CadastrarVacinador(Vacinador vacinador)
        {
            if (ModelState.IsValid)
            {
                _covidRepository.CadastrarVacinador(vacinador);
                return RedirectToAction(nameof(CadastrarVacinador));
            }

            var model = new InserirVacinadoViewModel(_covidRepository.GetAllMarcasVacinaCovid());
            return View(model);
        }

        public IActionResult IndexVacinadores()
        {
            var model = _covidRepository.GetAllVacinadores();
            return View(model);
        }

        public IActionResult EditarVacinador(string registroProfissional)
        {
            if (registroProfissional == null)
                return RedirectToAction(nameof(ErrorViewModel), new { message = "Registro profissional não especificado" });

            var vacinador = _covidRepository.GetVacinadorByRegistro(registroProfissional);

            if (vacinador == null)
                return RedirectToAction(nameof(ErrorViewModel), new { message = "Registro profissional não encontrado" });

            return View(vacinador);
        }
        
        public IActionResult DeletarVacinador(string registroProfissional)
        {
            if (registroProfissional == null)
                return RedirectToAction(nameof(ErrorViewModel), new { message = "Registro profissional não especificado" });

            var vacinador = _covidRepository.GetVacinadorByRegistro(registroProfissional);

            if (vacinador == null)
                return RedirectToAction(nameof(ErrorViewModel), new { message = "Registro profissional não encontrado" });

            return View(vacinador);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditarVacinador(Vacinador vacinador)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _covidRepository.UpdateVacinador(vacinador);
                }
                catch (Exception ex)
                {
                    if (!(_covidRepository.ExisteVacinador(vacinador.RegistroProfissional.ToString())))
                    {
                        return RedirectToAction(nameof(ErrorViewModel), new { message = ex.Message });
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            return RedirectToAction(nameof(IndexVacinadores));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletarRegistroVacinador(string registroProfissional)
        {
            if (string.IsNullOrWhiteSpace(registroProfissional))
            {
                try
                {
                    _covidRepository.RemoverVacinador(registroProfissional);
                }
                catch (Exception ex)
                {
                    throw;
                }
            }

            return RedirectToAction(nameof(IndexVacinadores));
        }

        public IActionResult LeitosIndex()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetInformacoesPaciente(string cpf)
        {
            cpf = cpf.RemovePontoEHifem();
            var paciente = _pacienteRepository.FindByCpf(cpf);

            if (paciente == null)
                return BadRequest();

            var model = new
            {
                Valid = true,
                Paciente = new
                {
                    Nome = paciente.Nome,
                    Cpf = paciente.Cpf,
                    Rg = paciente.Rg,
                    Cns = paciente.Cns
                }
            };           

            return Ok(model);
        }
    }
}
